import http from "k6/http";
import { check, sleep } from "k6";
import uri from "../../config/endpoints.js";

export const options = {
  stages: [
    { duration: "10s", target: 100 },
    { duration: "10s", target: 300 },
    { duration: "10s", target: 0 },
  ],
  thresholds: {
    http_req_duration: ["p(95)<500"],
    http_req_failed: ["rate<0.01"],
  },
};

export default function () {
  const params = {
    headers: {
      "Content-Type": "application/json",
      "User-Agent": `k6-performance-test-${__ENV.TEST_TYPE || "dev"}`,
    },
    tags: {
      name: "get_product_by_id", // для агрегации метрик
    },
  };

  let productId = "042c156d-e7ec-419b-8253-8d3100de02d1";
  let endpointUri = uri.productService.products.get_by_id_product(productId);

  let res = http.get(endpointUri, params);

  check(res, {
    "status was 200": (r) => r.status == 200,
    "response time < 500ms": (r) => r.timings.duration < 500,
    "has correct content type": (r) =>
      r.headers["Content-Type"]?.includes("application/json"),
    "response body not empty": (r) => r.body && r.body.length > 0,
  });

  sleep(1);
}

// checks.........................: 100.00% 20568 out of 20568
//      data_received..................: 3.6 MB  117 kB/s
//      data_sent......................: 374 kB  12 kB/s
//      http_req_blocked...............: avg=140.41µs min=0s med=0s max=105.43ms p(90)=0s       p(95)=1.69ms
//      http_req_connecting............: avg=9.15µs   min=0s med=0s max=3.51ms   p(90)=0s       p(95)=0s
//    ✓ http_req_duration..............: avg=392.98µs min=0s med=0s max=151.19ms p(90)=699.98µs p(95)=806.2µs
//        { expected_response:true }...: avg=392.98µs min=0s med=0s max=151.19ms p(90)=699.98µs p(95)=806.2µs
//    ✓ http_req_failed................: 0.00%   0 out of 5142
//      http_req_receiving.............: avg=45.23µs  min=0s med=0s max=1.33ms   p(90)=0s       p(95)=519.29µs
//      http_req_sending...............: avg=17.59µs  min=0s med=0s max=1.58ms   p(90)=0s       p(95)=0s
//      http_req_tls_handshaking.......: avg=124.68µs min=0s med=0s max=103.27ms p(90)=0s       p(95)=1.39ms
//      http_req_waiting...............: avg=330.16µs min=0s med=0s max=149.61ms p(90)=672.89µs p(95)=714.3µs
//      http_reqs......................: 5142    165.924031/s
//      iteration_duration.............: avg=1s       min=1s med=1s max=1.25s    p(90)=1s       p(95)=1s
//      iterations.....................: 5142    165.924031/s
//      vus............................: 2       min=2              max=299
//      vus_max........................: 300     min=300            max=300

//checks.........................: 79.49% 6089 out of 7660
//      data_received..................: 1.6 MB 51 kB/s
//      data_sent......................: 239 kB 7.5 kB/s
//      http_req_blocked...............: avg=68.26ms  min=0s     med=0s    max=1.96s  p(90)=222.13ms p(95)=546.81ms
//      http_req_connecting............: avg=50.1µs   min=0s     med=0s    max=1.97ms p(90)=181.68µs p(95)=506.6µs
//    ✗ http_req_duration..............: avg=1.78s    min=3.75ms med=1.61s max=5.43s  p(90)=3.42s    p(95)=3.66s
//        { expected_response:true }...: avg=1.78s    min=3.75ms med=1.61s max=5.43s  p(90)=3.42s    p(95)=3.66s
//    ✓ http_req_failed................: 0.00%  0 out of 1915
//      http_req_receiving.............: avg=839.92µs min=0s     med=0s    max=1.05s  p(90)=630.9µs  p(95)=849.8µs
//      http_req_sending...............: avg=43.47µs  min=0s     med=0s    max=1.86ms p(90)=0s       p(95)=506.28µs
//      http_req_tls_handshaking.......: avg=68.19ms  min=0s     med=0s    max=1.96s  p(90)=221.9ms  p(95)=546.42ms
//      http_req_waiting...............: avg=1.78s    min=3.75ms med=1.61s max=5.43s  p(90)=3.42s    p(95)=3.66s
//      http_reqs......................: 1915   59.993188/s
//      iteration_duration.............: avg=2.85s    min=1s     med=2.72s max=6.89s  p(90)=4.44s    p(95)=4.81s
//      iterations.....................: 1915   59.993188/s
//      vus............................: 122    min=10           max=300
//      vus_max........................: 300    min=300          max=300

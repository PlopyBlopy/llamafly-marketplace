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
      name: "get_all_categories_min",
    },
  };

  let endpointUri = uri.productService.categories.get_all_categories_min;

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
// with Cache
//checks.........................: 100.00% 16596 out of 16596
//      data_received..................: 33 MB   1.1 MB/s
//      data_sent......................: 512 kB  17 kB/s
//      http_req_blocked...............: avg=163.27µs min=0s med=0s      max=29.99ms  p(90)=0s       p(95)=1.89ms
//      http_req_connecting............: avg=13.9µs   min=0s med=0s      max=734.2µs  p(90)=0s       p(95)=0s
//    ✓ http_req_duration..............: avg=761.3µs  min=0s med=550.1µs max=161.69ms p(90)=1ms      p(95)=1.08ms
//        { expected_response:true }...: avg=761.3µs  min=0s med=550.1µs max=161.69ms p(90)=1ms      p(95)=1.08ms
//    ✓ http_req_failed................: 0.00%   0 out of 4149
//      http_req_receiving.............: avg=145.26µs min=0s med=0s      max=5.11ms   p(90)=617.34µs p(95)=640.1µs
//      http_req_sending...............: avg=21.44µs  min=0s med=0s      max=1.51ms   p(90)=0s       p(95)=0s
//      http_req_tls_handshaking.......: avg=137.27µs min=0s med=0s      max=28.98ms  p(90)=0s       p(95)=1.59ms
//      http_req_waiting...............: avg=594.59µs min=0s med=517.9µs max=156.58ms p(90)=727.62µs p(95)=948.36µs
//      http_reqs......................: 4149    134.966195/s
//      iteration_duration.............: avg=1s       min=1s med=1s      max=1.19s    p(90)=1s       p(95)=1s
//      iterations.....................: 4149    134.966195/s
//      vus............................: 15      min=10             max=299
//      vus_max........................: 300     min=300            max=300

// without Cache
//checks.........................: 79.87% 4406 out of 5516
//      data_received..................: 11 MB  360 kB/s
//      data_sent......................: 277 kB 9.0 kB/s
//      http_req_blocked...............: avg=119.04ms min=0s     med=0s       max=2.1s   p(90)=554.42ms p(95)=872.83ms
//      http_req_connecting............: avg=69.78µs  min=0s     med=0s       max=3.21ms p(90)=504.2µs  p(95)=542.81µs
//    ✗ http_req_duration..............: avg=2.19s    min=4.2ms  med=2.14s    max=5.95s  p(90)=4.53s    p(95)=5.01s
//        { expected_response:true }...: avg=2.19s    min=4.2ms  med=2.14s    max=5.95s  p(90)=4.53s    p(95)=5.01s
//    ✓ http_req_failed................: 0.00%  0 out of 1379
//      http_req_receiving.............: avg=567.91ms min=0s     med=406.74ms max=2.78s  p(90)=1.38s    p(95)=1.87s
//      http_req_sending...............: avg=41.72µs  min=0s     med=0s       max=1.5ms  p(90)=0s       p(95)=506.52µs
//      http_req_tls_handshaking.......: avg=118.95ms min=0s     med=0s       max=2.1s   p(90)=554.42ms p(95)=872.27ms
//      http_req_waiting...............: avg=1.62s    min=3.79ms med=1.52s    max=4.82s  p(90)=3.57s    p(95)=3.89s
//      http_reqs......................: 1379   44.752529/s
//      iteration_duration.............: avg=3.31s    min=1s     med=3.15s    max=7.74s  p(90)=5.82s    p(95)=6.21s
//      iterations.....................: 1379   44.752529/s
//      vus............................: 19     min=10           max=300
//      vus_max........................: 300    min=300          max=300
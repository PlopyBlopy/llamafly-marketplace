// k6 run --env PRODUCT_SERVICE_BASE=https://localhost:7102 .\load-testing\product-service\get_by_id_product.js

const authServiceBase = __ENV.AUTH_SERVICE_BASE;
const profileServiceBase = __ENV.PROFILE_SERVICE_BASE;
const productServiceBase = __ENV.PRODUCT_SERVICE_BASE;

const api = `${productServiceBase}/api/v1`;
const productsBase = `${api}/products`;
const categoriesBase = `${api}/categories`;

const uri = {
  productService: {
    api: api,
    products: {
      base: productsBase,
      get_by_id_product: (productId) => `${productsBase}/${productId}`,
    },
    cards: {},
    categories: {
      base: categoriesBase,
      get_by_id_category: (categoryId) => `${categoriesBase}/${categoryId}`,
      get_all_categories_min: `${categoriesBase}/all/min`,
    },
  },
};

export default uri;

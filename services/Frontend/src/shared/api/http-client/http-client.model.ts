export const API = {
  products: {
    base: "/products",
    GET: {
      detail: (productId: string) => `${API.products.base}/detail/${productId}`,
    },
  },
  productsCards: {
    base: "/products/cards",
    GET: {
      filters: () => `${API.productsCards.base}/filters`,
    },
  },
  categories: {
    base: "/categories",
    GET: {
      categories: () => `${API.categories.base}/all/min`,
    },
  },
};

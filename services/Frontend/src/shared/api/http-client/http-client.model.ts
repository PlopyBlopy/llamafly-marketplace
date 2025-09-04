export const API = {
  products: {
    productsCards: () => "/",
    detail: (productId: string) => `/detail/${productId}`,
  },
  categories: {
    base: "/categories",
    categories: () => `${API.categories.base}/range`,
  },
};

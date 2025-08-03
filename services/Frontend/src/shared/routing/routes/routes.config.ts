export const ROUTES = {
  MAIN: {
    path: "/",
    base: "/",
  },
  LOGIN: {
    path: "/profile/login",
    base: "/profile/login",
  },
  REGISTRATION: {
    path: "/profile/registration",
    base: "/profile/registration",
  },
  PRODUCT: {
    path: (title: string, id: string) => `/product/${title}?id=${id}`,
    base: "/product/:title",
  },
};

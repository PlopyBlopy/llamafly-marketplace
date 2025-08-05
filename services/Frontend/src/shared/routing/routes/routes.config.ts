export const ROUTES = {
  Main: {
    path: "/",
    base: "/",
  },
  Authorization: {
    Login: {
      path: "/profile/login",
      base: "/profile/login",
    },
    Registration: {
      path: "/profile/registration",
      base: "/profile/registration",
    },
  },
  Product: {
    path: (title: string, id: string) => `/product/${title}?id=${id}`,
    base: "/product/:title",
  },
};

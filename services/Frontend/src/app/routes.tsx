import { LoginPage } from "@/pages/login-page";
import { MainPage } from "@/pages/main-page";
import { ProductPage } from "@/pages/product-page";
import { RegistrationPage } from "@/pages/registration-page";
import { ROUTES } from "@/shared/routing/routes/routes.config";
import { PageWrapper } from "@/widgets/layouts/page-wrapper";
import { createBrowserRouter } from "react-router-dom";

export const Router = createBrowserRouter([
  {
    path: ROUTES.Main.base,
    element: <PageWrapper />,
    children: [
      {
        index: true,
        element: <MainPage />,
      },
      {
        path: ROUTES.Authorization.Login.base,
        element: <LoginPage />,
      },
      {
        path: ROUTES.Authorization.Registration.base,
        element: <RegistrationPage />,
      },
      {
        path: ROUTES.Product.base,
        element: <ProductPage />,
      },
    ],
  },
]);

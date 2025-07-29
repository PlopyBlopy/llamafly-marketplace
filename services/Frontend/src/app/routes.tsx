import { LoginPage } from "@/pages/login-page";
import { MainPage } from "@/pages/main-page";
import { RegistrationPage } from "@/pages/registration-page";
import { ROUTES } from "@/shared/routing/routes/routes.config";
import { PageWrapper } from "@/widgets/layouts/page-wrapper";
import { createBrowserRouter } from "react-router-dom";

export const Router = createBrowserRouter([
  {
    path: ROUTES.MAIN.base,
    element: <PageWrapper />,
    children: [
      {
        index: true,
        element: <MainPage />,
      },
      {
        path: ROUTES.LOGIN.base,
        element: <LoginPage />,
      },
      {
        path: ROUTES.REGISTRATION.base,
        element: <RegistrationPage />,
      },
    ],
  },
]);

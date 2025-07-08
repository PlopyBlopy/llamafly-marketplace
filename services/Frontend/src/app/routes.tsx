import { MainPage } from "@/pages/main-page";
import { ROUTES } from "@/shared/routing/routes/config";
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
    ],
  },
]);

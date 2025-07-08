import { RouterProvider } from "react-router-dom";
import { Router } from "./routes";

export const App = () => {
  return <RouterProvider router={Router} />;
};

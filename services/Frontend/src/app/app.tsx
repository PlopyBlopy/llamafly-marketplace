import { RouterProvider } from "react-router-dom";
import { Router } from "./routes";
import { StoreProvider } from "@/shared/contexts/store-context";

export const App = () => {
  return (
    <StoreProvider>
      <RouterProvider router={Router} />
    </StoreProvider>
  );
};

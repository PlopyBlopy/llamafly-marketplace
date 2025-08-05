import { useNavigate } from "react-router-dom";
import { ROUTES } from "./routes.config";
import { TransliterRoute } from "@/shared/transliter-route";

export const useAppNavigate = () => {
  const navigate = useNavigate();

  return {
    goToMain: () => navigate(ROUTES.MAIN.path),
    goToLogin: () => navigate(ROUTES.Authorization.Login.path),
    goToRegistration: () => navigate(ROUTES.Authorization.Registration.path),
    goToProduct: (title: string, id: string) => navigate(ROUTES.Product.path(TransliterRoute(title), id)),
    customNavigate: navigate,
  };
};

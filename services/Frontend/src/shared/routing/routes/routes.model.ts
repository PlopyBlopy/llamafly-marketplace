import { useNavigate } from "react-router-dom";
import { ROUTES } from "./routes.config";

export const useAppNavigate = () => {
  const navigate = useNavigate();

  return {
    goToMain: () => navigate(ROUTES.MAIN.path),
    goToLogin: () => navigate(ROUTES.LOGIN.path),
    goToRegistration: () => navigate(ROUTES.REGISTRATION.path),
  };
};

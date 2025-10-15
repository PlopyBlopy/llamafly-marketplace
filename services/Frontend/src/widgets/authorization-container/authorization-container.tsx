import { PrimaryButton } from "@/shared/components/primary-button";
import { useAppNavigate } from "@/shared/routing/routes";

export const AuthorizationContainer = () => {
  const { goToLogin, goToRegistration } = useAppNavigate();

  const handleLogin = () => {
    goToLogin();
  };

  const handleRegister = () => {
    goToRegistration();
  };

  return (
    <>
      <PrimaryButton onClick={handleLogin} text="Войти" />
      <PrimaryButton onClick={handleRegister} text="Зарегистрироваться" />
    </>
  );
};

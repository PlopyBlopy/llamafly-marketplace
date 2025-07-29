import { ButtonDefault } from "@/shared/button-default";
import { useAppNavigate } from "@/shared/routing/routes";

export const AuthorizationContainer = () => {
  const { goToLogin, goToRegistration } = useAppNavigate();

  const onLogin = () => {
    goToLogin();
  };

  const onRegister = () => {
    goToRegistration();
  };

  return (
    <>
      <ButtonDefault text="Login" onClick={onLogin} />
      <ButtonDefault text="register" onClick={onRegister} />
    </>
  );
};

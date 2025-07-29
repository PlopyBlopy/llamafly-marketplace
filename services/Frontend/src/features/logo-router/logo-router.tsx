import { useAppNavigate } from "@/shared/routing/routes";
import logo from "@/shared/assets/logo/LlamaFly-full-ver1-logo.png";
import { ImgClickable } from "@/shared/img-clickable";

export const LogoRouter = () => {
  const { goToMain } = useAppNavigate();

  return <ImgClickable src={logo} goToPage={goToMain} />;
};

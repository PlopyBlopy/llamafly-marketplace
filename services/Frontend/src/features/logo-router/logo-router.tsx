import { useAppNavigate } from "@/shared/routing/routes";
import logo from "@/shared/assets/logo/LlamaFly-full-ver1-logo.png";
import { ImgClickable } from "@/shared/img-clickable";
import { useStore } from "@/shared/hooks/store-hook";

export const LogoRouter = () => {
  const { goToMain } = useAppNavigate();
  const {
    productCardStore: { loadProductsCards },
  } = useStore();

  const goToPageHandler = () => {
    loadProductsCards(true);
    goToMain();
  };

  return <ImgClickable src={logo} onGoToPage={goToPageHandler} />;
};

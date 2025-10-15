import { useAppNavigate } from "@/shared/routing/routes";
import logo from "@/shared/assets/brand/brand_name.png";
import { ImgClickable } from "@/shared/img-clickable";
import { useStore } from "@/shared/hooks/store-hook";

export const BrandRouter = () => {
  const { goToMain } = useAppNavigate();
  const {
    productCardStore: { loadProductsCards },
  } = useStore();

  const handleGoToPage = () => {
    loadProductsCards(true);
    goToMain();
  };

  return <ImgClickable src={logo} onGoToPage={handleGoToPage} />;
};

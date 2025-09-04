import styles from "./product-card-container.module.css";
import { useAppNavigate } from "@/shared/routing/routes";
import preview from "@/shared/assets/test-preview.jpg";
import type { ProductCard } from "@/shared/api/services/product-service/product-card";

type Props = {
  card: ProductCard;
};

export const ProductCardContainer = ({ card }: Props) => {
  const { goToProduct } = useAppNavigate();
  const goToProductPageHandler = () => {
    goToProduct(card.title, card.id);
  };

  return (
    <div className={styles.container}>
      <img className={styles.imgContainer} onClick={goToProductPageHandler} src={card.img == null ? preview : card.img} alt="product" />
      <div className={styles.bodyContainer}>
        <div className={styles.price}>{card.price} ₽</div>
        <header className={styles.title} onClick={goToProductPageHandler}>
          {card.title}
        </header>
        <div className={styles.ratingItems}>
          <div className={styles.starRating}>★</div>
          <div className={styles.valueRating}>{card.rating}</div>
        </div>
      </div>
    </div>
  );
};

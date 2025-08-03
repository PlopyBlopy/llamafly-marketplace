import styles from "./product-card.module.css";
import type { Card } from "./product-card.model";
import { useAppNavigate } from "@/shared/routing/routes";

type Props = {
  card: Card;
};

export const ProductCard = ({ card }: Props) => {
  const { goToProduct } = useAppNavigate();
  const goToProductPageHandler = () => {
    goToProduct(card.title, card.id);
  };

  return (
    <div className={styles.container}>
      <img className={styles.imgContainer} onClick={goToProductPageHandler} src={card.img} alt="product" />
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

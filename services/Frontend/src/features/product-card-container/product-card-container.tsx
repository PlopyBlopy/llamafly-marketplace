import styles from "./product-card-container.module.css";
import { useAppNavigate } from "@/shared/routing/routes";
import preview from "@/shared/assets/test-preview.jpg";
import type { ProductCard } from "@/shared/api/services/product-service/product-card";
import { Icons } from "@/shared/assets/icons";

type Props = {
  card: ProductCard;
};

export const ProductCardContainer = ({ card }: Props) => {
  const { goToProduct } = useAppNavigate();
  const goToProductPageHandler = () => {
    goToProduct(card.title, card.id);
  };

  const CommentIcon = Icons.elements.comment;
  const StarIcon = Icons.elements.star;
  const number = 12345;

  return (
    <div className={styles.container}>
      <img className={styles.imgContainer} onClick={goToProductPageHandler} src={card.img == null ? preview : card.img} alt="product" />
      <div className={styles.bodyContainer}>
        <div className={styles.inlineContainer}>
          <div className={styles.price}>{card.price} ₽</div>
          <div className={styles.priceOld}>1456 ₽</div>
          <div className={styles.discount}>-20%</div>
        </div>
        <header className={styles.title} onClick={goToProductPageHandler}>
          {card.title}
        </header>
        <div className={styles.inlineContainerBottom}>
          <StarIcon className={styles.star} />
          <div className={styles.valueRating}>{card.rating}</div>
          <CommentIcon className={styles.comment} />
          <div className={styles.valueComment}>{number.toLocaleString("ru-RU")}</div>
        </div>
      </div>
    </div>
  );
};

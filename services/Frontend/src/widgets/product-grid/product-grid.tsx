import styles from "./product-grid.module.css";
import { ProductCard, type Card } from "@/features/product-card";
import preview from "@/shared/assets/test-preview.jpg";

export const ProductGrid = () => {
  const card: Card = { id: "123456789", img: preview, title: "Держатель для обувной ложки настенный ", price: "1000", rating: "4.6" };

  return (
    <div className={styles.gridContainer}>
      <ProductCard card={card} />
      <ProductCard card={card} />
      <ProductCard card={card} />
      <ProductCard card={card} />
      <ProductCard card={card} />
      <ProductCard card={card} />
      <ProductCard card={card} />
      <ProductCard card={card} />
      <ProductCard card={card} />
      <ProductCard card={card} />
      <ProductCard card={card} />
      <ProductCard card={card} />
      <ProductCard card={card} />
      <ProductCard card={card} />
      <ProductCard card={card} />
    </div>
  );
};

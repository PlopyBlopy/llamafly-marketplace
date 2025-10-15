import styles from "./main-page.module.css";
import { ProductGrid } from "@/widgets/product-grid";

export const MainPage = () => {
  return (
    <div className={styles.container}>
      <ProductGrid />
    </div>
  );
};

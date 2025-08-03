import { MainPageFilter } from "@/widgets/main-page-filter";
import styles from "./main-page.module.css";
import { ProductGrid } from "@/widgets/product-grid";

export const MainPage = () => {
  return (
    <div className={styles.container}>
      <div className={styles.filterContainer}>
        <MainPageFilter />
      </div>
      <ProductGrid />
    </div>
  );
};

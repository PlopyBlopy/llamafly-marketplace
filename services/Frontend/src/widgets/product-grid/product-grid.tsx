import { ProductCardContainer } from "@/features/product-card-container";
import styles from "./product-grid.module.css";
import { useStore } from "@/shared/hooks/store-hook";
import { useEffect } from "react";
import { observer } from "mobx-react-lite";

export const ProductGrid = observer(() => {
  const {
    productCardStore: { loadProductsCards, productsCards },
  } = useStore();

  useEffect(() => {
    if (productsCards == null) {
      loadProductsCards();
    }
  }, [productsCards, loadProductsCards]);

  const productsCardsList = productsCards?.map((card) => (
    <div key={card.id}>
      <ProductCardContainer card={card} />
    </div>
  ));

  return <div className={styles.gridContainer}>{productsCardsList}</div>;
});

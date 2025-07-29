import { CategoryButton } from "../category-button";
import styles from "./categories-area.module.css";

type Props = {
  onSelected: () => void;
};

export const CategoriesArea = ({ onSelected }: Props) => {
  const selectedCategoryHandler = (categoryId: string) => {
    // вызов api с фильтром для выбранной категории
    onSelected();
    console.log(categoryId);
  };

  return (
    <div className={styles.container}>
      <CategoryButton
        categoryId="1"
        categoryName="Some category"
        onClickEvent={(value) => {
          selectedCategoryHandler(value);
        }}
      />
    </div>
  );
};

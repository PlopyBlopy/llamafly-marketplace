import { getIconSrc } from "./category-button.config";
import styles from "./category-button.module.css";

type Props = {
  categoryId: string;
  categoryName: string;
  onClickEvent: (categoryId: string) => void;
};

export const CategoryButton = ({ categoryId, categoryName, onClickEvent }: Props) => {
  const onClickHandler = () => {
    onClickEvent(categoryId);
  };

  return (
    <div className={styles.container}>
      <img className={styles.icon} rel="icon" src={getIconSrc(categoryId)} />
      <button className={styles.button} onClick={onClickHandler}>
        {categoryName}
      </button>
    </div>
  );
};

import { getIconSrc } from "./category-button.config";
import styles from "./category-button.module.css";

type Props = {
  categoryId: string;
  categoryName: string;
  onClickEvent: (categoryId: string) => void;
};

export const CategoryButton = ({ categoryId, categoryName, onClickEvent }: Props) => {
  const handleClick = () => {
    onClickEvent(categoryId);
  };

  return (
    <div className={styles.container} onClick={handleClick}>
      <img className={styles.icon} rel="icon" src={getIconSrc(categoryId)} />
      <div className={styles.button}>{categoryName}</div>
    </div>
  );
};

import { Icons } from "@/shared/assets/icons";
import styles from "./primary-flat-button-icon.module.css";

type Props = {
  onClick: () => void;
  IconComponent?: React.ComponentType<{ className?: string }>;
};

export const PrimaryFlatButtonIcon = ({ onClick, IconComponent = Icons.default }: Props) => {
  return (
    <button className={styles.button} onClick={onClick}>
      <IconComponent className={styles.icon} />
    </button>
  );
};

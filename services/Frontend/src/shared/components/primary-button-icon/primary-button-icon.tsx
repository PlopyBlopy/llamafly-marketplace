import { Icons } from "@/shared/assets/icons";
import styles from "./primary-button-icon.module.css";

type Props = {
  onClick: () => void;
  text?: string;
  IconComponent?: React.ComponentType<{ className?: string }>;
};

export const PrimaryButtonIcon = ({ onClick, text = "PBUTTONI", IconComponent = Icons.default }: Props) => {
  return (
    <button className={styles.button} onClick={onClick}>
      <IconComponent className={styles.icon} />
      {text}
    </button>
  );
};

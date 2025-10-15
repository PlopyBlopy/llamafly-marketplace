import styles from "./secondary-button-icon.module.css";
import { Icons } from "@/shared/assets/icons";

type Props = {
  onClick: () => void;
  text?: string;
  IconComponent?: React.ComponentType<{ className?: string }>;
};

export const SecondaryButtonIcon = ({ onClick, text = "SBUTTONI", IconComponent = Icons.default }: Props) => {
  return (
    <button className={styles.button} onClick={onClick}>
      <IconComponent className={styles.icon} />
      {text}
    </button>
  );
};

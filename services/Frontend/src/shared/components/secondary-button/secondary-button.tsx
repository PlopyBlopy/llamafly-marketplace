import styles from "./secondary-button.module.css";

type Props = {
  onClick: () => void;
  text?: string;
};

export const SecondaryButton = ({ onClick, text = "SBUTTON" }: Props) => {
  return (
    <div>
      <button className={styles.button} onClick={onClick}>
        {text}
      </button>
    </div>
  );
};

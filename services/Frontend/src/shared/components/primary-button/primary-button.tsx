import styles from "./primary-button.module.css";

type Props = {
  onClick: () => void;
  text?: string;
};

export const PrimaryButton = ({ onClick, text = "PBUTTON" }: Props) => {
  return (
    <button className={styles.button} onClick={onClick}>
      {text}
    </button>
  );
};

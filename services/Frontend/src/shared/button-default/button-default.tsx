import styles from "./button-default.module.css";

type Props = {
  text: string;
  onClick: () => void;
};

export const ButtonDefault = ({ text, onClick }: Props) => {
  return (
    <button className={styles.buttonDefault} onClick={onClick}>
      {text}
    </button>
  );
};

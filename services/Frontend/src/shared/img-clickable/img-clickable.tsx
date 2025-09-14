import styles from "./img-clickable.module.css";

type Props = {
  src: string;
  onGoToPage: () => void;
  width?: string;
};

export const ImgClickable = ({ src, onGoToPage, width }: Props) => {
  return <img className={styles.logo} onClick={onGoToPage} style={{ cursor: "pointer", width }} src={src} alt="LlamaFly" />;
};

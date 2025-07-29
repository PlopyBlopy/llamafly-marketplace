import styles from "./img-clickable.module.css";

type Props = {
  src: string;
  goToPage: () => void;
  width?: string;
};

export const ImgClickable = ({ src, goToPage, width }: Props) => {
  return <img className={styles.logo} onClick={goToPage} style={{ cursor: "pointer", width }} src={src} alt="LlamaFly" />;
};

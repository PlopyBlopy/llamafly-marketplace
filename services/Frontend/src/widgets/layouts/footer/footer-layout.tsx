import styles from "./footer-layout.module.css";

export const FooterLayout = () => {
  return (
    <div className={styles.items}>
      <text className={styles.inDevText}>In development. </text>
      <text className={styles.descriptionText}>Сайт нереального маркетплейса, в качестве практики Backend, Frontend, DevOps.</text>
    </div>
  );
};

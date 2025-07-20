import { HeaderLayout } from "@/widgets/layouts/header";
import { MainLayout } from "@/widgets/layouts/main";
import { FooterLayout } from "@/widgets/layouts/footer";
import styles from "./page-wrapper.module.css";

export const PageWrapper = () => {
  return (
    <>
      <div className={styles.base}>
        <div className={styles.headerContainer}>
          <div className={styles.headerContent}>
            <HeaderLayout />
          </div>
        </div>

        <div className={styles.mainContainer}>
          <div className={styles.mainContent}>
            <MainLayout />
          </div>
        </div>

        <div>
          <div className={styles.footerContent}>
            <FooterLayout />
          </div>
        </div>
      </div>
    </>
  );
};

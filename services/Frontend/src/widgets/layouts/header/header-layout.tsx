import styles from "./header-layout.module.css";

import { BrandRouter } from "@/features/brand-router";
import { CategoriesMenu } from "@/widgets/categories-menu";
import { SearchHeaderContainer } from "@/widgets/search-container";
import { AuthorizationContainer } from "@/widgets/authorization-container";

export const HeaderLayout = () => {
  return (
    <div className={styles.container}>
      <div className={styles.items}>
        <BrandRouter />
        <CategoriesMenu />
        <SearchHeaderContainer />
        <AuthorizationContainer />
      </div>
    </div>
  );
};

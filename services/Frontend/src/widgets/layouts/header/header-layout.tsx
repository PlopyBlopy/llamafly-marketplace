import styles from "./header-layout.module.css";

import { LogoRouter } from "@/features/logo-router";
import { CategoriesMenu } from "@/widgets/categories-menu";
import { SearchHeaderContainer } from "@/widgets/search-container";
import { AuthorizationContainer } from "@/widgets/authorization-container";

export const HeaderLayout = () => {
  return (
    <div className={styles.container}>
      <LogoRouter />
      <CategoriesMenu />
      <SearchHeaderContainer />
      <AuthorizationContainer />
    </div>
  );
};

import { FooterLayout } from "../footer";
import { HeaderLayout } from "../header";
import { MainLayout } from "../main";

export const PageWrapper = () => {
  return (
    <>
      <HeaderLayout />
      <MainLayout />
      <FooterLayout />
    </>
  );
};

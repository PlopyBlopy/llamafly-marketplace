import { ButtonDefault } from "@/shared/button-default";
import { CategoriesDrawer } from "@/features/categories-drawer";
import { useState } from "react";

export const CategoriesMenu = () => {
  const [isOpen, SetOpen] = useState<boolean>();

  const categoriesOpenHandler = () => {
    SetOpen(!isOpen);
  };

  const selectedHandler = () => {
    categoriesOpenHandler();
  };

  return (
    <>
      <ButtonDefault onClick={categoriesOpenHandler} text="Категории" />
      {isOpen ? <CategoriesDrawer onSelected={selectedHandler} /> : null}
    </>
  );
};

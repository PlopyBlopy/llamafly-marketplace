import { ButtonDefault } from "@/shared/button-default";
import { CategoriesArea } from "@/features/categories-area";
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
      {isOpen ? <CategoriesArea onSelected={selectedHandler} /> : null}
    </>
  );
};

import { ButtonDefault } from "@/shared/button-default";
import { CategoriesDrawer } from "@/features/categories-drawer";
import { useState } from "react";

export const CategoriesMenu = () => {
  const [isOpen, setOpen] = useState<boolean>();

  const handleCategoriesMenuToggle = () => {
    setOpen((prev) => !prev);
  };

  const handleCategorySelect = () => {
    handleCategoriesMenuToggle();
  };

  return (
    <>
      <ButtonDefault onClick={handleCategoriesMenuToggle} text="Категории" />
      {isOpen && <CategoriesDrawer onSelected={handleCategorySelect} />}
    </>
  );
};

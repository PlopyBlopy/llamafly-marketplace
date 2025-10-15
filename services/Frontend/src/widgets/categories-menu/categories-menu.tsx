import { CategoriesDrawer } from "@/features/categories-drawer";
import { useState } from "react";
import { PrimaryButtonIcon } from "@/shared/components/primary-button-icon";
import { Icons } from "@/shared/assets/icons";

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
      <PrimaryButtonIcon onClick={handleCategoriesMenuToggle} text="Категории" IconComponent={Icons.menu.categories} />
      {isOpen && <CategoriesDrawer onSelected={handleCategorySelect} />}
    </>
  );
};

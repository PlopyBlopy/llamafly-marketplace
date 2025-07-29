import type { CategoryIcon } from "./category-button.model";
import defaultIcon from "@/shared/assets/category-icons/defaultIcon.svg";
import sneakersIcon from "@/shared/assets/category-icons/sneakers.svg";

export const getIconSrc = (categoryId: string): string => {
  const icon = icons.find((icon) => icon.categoryId == categoryId);

  if (icon == undefined) return icons[0].src;

  return icon.src;
};

export const icons: CategoryIcon[] = [
  { categoryId: "0", name: "defaultIcon", src: defaultIcon },
  { categoryId: "1", name: "sneakers", src: sneakersIcon },
];

import type { DropDownOption } from "@/features/drop-down-select";

export const priceOptions: DropDownOption[] = [
  { name: "от дешевых", value: "min" },
  { name: "с дорогих", value: "max" },
];

export const ratingOptions: DropDownOption[] = [
  { name: "с высокого", value: "max" },
  { name: "от низкого", value: "min" },
];

export type FilterOptions = {
  price: string;
  rating: string;
};

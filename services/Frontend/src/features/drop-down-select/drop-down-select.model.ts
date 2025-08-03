import type { StringNumber } from "@/shared/union-type";

export type DropDown = {
  name: string;
  options: DropDownOption[];
};

export type DropDownOption = {
  name: string;
  value: StringNumber;
};

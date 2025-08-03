import styles from "./main-page-filter.module.css";
import { DropDownSelect } from "@/features/drop-down-select";
import { priceOptions, ratingOptions, type FilterOptions } from "./main-page-filter.config";
import { ButtonDefault } from "@/shared/button-default";
import { useState } from "react";
import type { StringNumber } from "@/shared/union-type";

export const MainPageFilter = () => {
  const [filter, setFilter] = useState<FilterOptions>({ price: "min", rating: "max" });

  const selectedOptionHandler = (dropDownId: keyof FilterOptions, value: StringNumber) => {
    console.log(dropDownId);
    setFilter((prevFilter) => ({ ...prevFilter, [dropDownId]: value }));
  };
  const submitFiltersHandler = () => {
    //TODO: api request
    console.log(filter);
  };

  return (
    <div className={styles.container}>
      <h1>Фильтры</h1>
      <DropDownSelect
        onSelectedOption={(value) => {
          selectedOptionHandler("price", value);
        }}
        dropDown={{ name: "По цене", options: priceOptions }}
      />
      <DropDownSelect
        onSelectedOption={(value) => {
          selectedOptionHandler("rating", value);
        }}
        dropDown={{ name: "По рейтингу", options: ratingOptions }}
      />
      <ButtonDefault onClick={submitFiltersHandler} text="Применить" />
    </div>
  );
};

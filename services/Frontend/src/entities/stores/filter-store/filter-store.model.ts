import type { FilterParams } from "@/shared/api/services/product-service/product-card";
import { action, makeObservable, observable } from "mobx";
import { defaultFilterParams } from "./filter-store.config";

export class FilterStore {
  public filterParams: FilterParams;

  constructor() {
    this.filterParams = defaultFilterParams;

    makeObservable(this, {
      filterParams: observable,
      setFilterParams: action,
    });
  }

  setFilterParams = (params: FilterParams) => {
    this.filterParams = params;
  };
}

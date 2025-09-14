import { getProductsCards, type ProductCard } from "@/shared/api/services/product-service/product-card";
import type { AxiosInstance } from "axios";
import { action, makeObservable, observable, runInAction } from "mobx";
import { defaultFilterParams, type FilterStore } from "../filter-store";

export class ProductCardStore {
  private readonly api: AxiosInstance;
  private readonly filterStore: FilterStore;

  public productsCards: ProductCard[] | null = null;

  constructor(api: AxiosInstance, filterStore: FilterStore) {
    this.api = api;
    this.filterStore = filterStore;

    makeObservable(this, {
      productsCards: observable,
      loadProductsCards: action,
    });
  }

  loadProductsCards = async (defaultFilters: boolean = false) => {
    if (defaultFilters) {
      this.filterStore.setFilterParams(defaultFilterParams);
    }

    const response: ProductCard[] = await getProductsCards(this.api, this.filterStore.filterParams);
    runInAction(() => {
      if (response != null) this.productsCards = response;
    });
  };

  loadProductsCardsNoFilters = async () => {};
}

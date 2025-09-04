import type { AxiosInstance } from "axios";
import { CreateApi } from "@/shared/api/api-factory";
import { ProductServiceApiConfig } from "@/shared/api/http-client";
import { ProductCardStore } from "../product-card-store";
import { ProductStore } from "../product-store";
import { FilterStore } from "../filter-store";

export class RootStore {
  private readonly productServiceAPI: AxiosInstance;

  filterStore: FilterStore;

  productStore: ProductStore;
  productCardStore: ProductCardStore;

  constructor() {
    this.productServiceAPI = CreateApi(ProductServiceApiConfig);

    this.filterStore = new FilterStore();

    this.productStore = new ProductStore(this.productServiceAPI);
    this.productCardStore = new ProductCardStore(this.productServiceAPI, this.filterStore);
  }
}

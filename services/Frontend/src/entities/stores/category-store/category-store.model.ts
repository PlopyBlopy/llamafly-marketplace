import type { AxiosInstance } from "axios";
import { action, makeObservable, observable, runInAction } from "mobx";
import { getCategories, type Category } from "@/shared/api/services/product-service/category";

export class CategoryStore {
  private readonly api: AxiosInstance;

  public categories: Category[] | null = null;

  constructor(api: AxiosInstance) {
    this.api = api;

    makeObservable(this, {
      categories: observable,
      loadCategories: action,
    });
  }

  loadCategories = async () => {
    const response: Category[] = await getCategories(this.api);
    runInAction(() => {
      if (response != null) this.categories = response;
    });
  };
}

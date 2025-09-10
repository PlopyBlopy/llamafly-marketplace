import type { AxiosInstance } from "axios";

export class ProductStore {
  private readonly api: AxiosInstance;

  constructor(api: AxiosInstance) {
    this.api = api;
  }
}

import type { AxiosInstance } from "axios";
import type { ProductCard, FilterParams } from "./product-card.model";
import { API } from "@/shared/api/http-client";

export const getProductsCards = async (api: AxiosInstance, params: FilterParams): Promise<ProductCard[]> => {
  const response = await api.get(API.productsCards.GET.filters(), { params });
  return response.data as ProductCard[];
};

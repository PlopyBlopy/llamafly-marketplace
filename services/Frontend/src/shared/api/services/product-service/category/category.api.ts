import type { AxiosInstance } from "axios";
import type { Category } from "./category.model";
import { API } from "@/shared/api/http-client";

export const getCategories = async (api: AxiosInstance): Promise<Category[]> => {
  const response = await api.get(API.categories.GET.categories());
  return response.data as Category[];
};

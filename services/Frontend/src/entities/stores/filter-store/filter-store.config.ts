import type { FilterParams } from "@/shared/api/services/product-service/product-card";

export const defaultFilterParams: FilterParams = {
  search: "",
  categoryId: "",
  sortProp: "rating",
  sortOrder: "desc",
};

export type FilterParams = {
  search?: string;
  categoryId?: string;
  sortProp?: "rating" | "price";
  sortOrder?: "desc" | "asc";
};

export type ProductCard = {
  id: string;
  img?: string | null;
  title: string;
  price: number;
  rating: number;
};

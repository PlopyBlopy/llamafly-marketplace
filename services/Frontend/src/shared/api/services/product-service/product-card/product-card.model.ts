export type FilterParams = {
  search?: string;
  categoryId?: string;
  sortProp?: "min" | "max";
  sortOrder?: "price" | "rating";
};

export type ProductCard = {
  id: string;
  img?: string | null;
  title: string;
  price: number;
  rating: number;
};

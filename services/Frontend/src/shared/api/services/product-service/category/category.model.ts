export type Category = {
  id: string;
  title: string;
  parentCategoryId: string;
  subCategories: Category[];
};

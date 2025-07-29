export interface Icon {
  name: string;
  src: string;
}

export interface CategoryIcon extends Icon {
  categoryId: string;
}

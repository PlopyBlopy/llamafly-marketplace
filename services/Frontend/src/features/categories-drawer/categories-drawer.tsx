import { useStore } from "@/shared/hooks/store-hook";
import { CategoryButton } from "../category-button";
import styles from "./categories-drawer.module.css";
import { useEffect, useState } from "react";
import { observer } from "mobx-react-lite";

type Props = {
  onSelected: () => void;
};

export const CategoriesDrawer = observer(({ onSelected }: Props) => {
  const {
    categoryStore: { categories, loadCategories },
    filterStore: { setFilterParams },
    productCardStore: { loadProductsCards },
  } = useStore();

  const [selectedCategory, setSelectedCategory] = useState<string | null>(null);

  useEffect(() => {
    if (categories == null) loadCategories();
  }, [categories, loadCategories]);

  useEffect(() => {
    if (categories != null) setSelectedCategory(categories[0].id);
  }, [categories]);

  const selectedCategoryHandler = (categoryId: string) => {
    onSelected();
    setFilterParams({ categoryId: categoryId });
    loadProductsCards();
  };

  const handleCategoryHover = (categoryId: string) => {
    setSelectedCategory(categoryId);
  };

  const currentCategorySelected = categories?.find((category) => category.id == selectedCategory);

  return (
    <div className={styles.container}>
      <div className={styles.drawerContainer}>
        <div className={styles.leftColumn}>
          {categories?.map((category) => (
            <div onPointerEnter={(event) => handleCategoryHover(category.id)} key={category.id}>
              <button
                onClick={(value) => {
                  selectedCategoryHandler(category.id);
                }}
              >
                {category.title}
              </button>
              {/* <CategoryButton
                categoryId={category.id}
                categoryName={category.title}
                onClickEvent={(value) => {
                  selectedCategoryHandler(value);
                }}
              /> */}
            </div>
          ))}
        </div>
        <div className={styles.rightColumn}>
          {currentCategorySelected ? (
            <div>
              {currentCategorySelected.subCategories?.map((subCategory) => (
                <div key={subCategory.id}>
                  <div>
                    <button
                      onClick={(value) => {
                        selectedCategoryHandler(subCategory.id);
                      }}
                    >
                      {subCategory.title}
                    </button>

                    {/* <CategoryButton
                      categoryId={subCategory.id}
                      categoryName={subCategory.title}
                      onClickEvent={(value) => {
                        selectedCategoryHandler(value);
                      }}
                    /> */}
                  </div>
                  <div className={styles.subList}>
                    {subCategory.subCategories?.map((subSubCategory) => (
                      <div key={subSubCategory.id}>
                        <button
                          onClick={(value) => {
                            selectedCategoryHandler(subSubCategory.id);
                          }}
                        >
                          {subSubCategory.title}
                        </button>

                        {/* <CategoryButton
                          categoryId={subSubCategory.id}
                          categoryName={subSubCategory.title}
                          onClickEvent={(value) => {
                            selectedCategoryHandler(value);
                          }}
                        /> */}
                      </div>
                    ))}
                  </div>
                </div>
              ))}
            </div>
          ) : null}{" "}
        </div>
      </div>
    </div>
  );
});

import { useStore } from "@/shared/hooks/store-hook";
import { SearchBar } from "@/shared/search-bar";

export const SearchHeaderContainer = () => {
  const {
    filterStore: { setFilterParams },
    productCardStore: { loadProductsCards },
  } = useStore();

  const handleSearch = (value: string) => {
    setFilterParams({ search: value });
    loadProductsCards();
  };

  return (
    <>
      <SearchBar
        onSearch={(value) => {
          handleSearch(value);
        }}
      />
    </>
  );
};

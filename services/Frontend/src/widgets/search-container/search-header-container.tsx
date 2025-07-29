import { SearchBar } from "@/shared/search-bar";

export const SearchHeaderContainer = () => {
  const handleSearch = (value: string) => {
    console.log(value);
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

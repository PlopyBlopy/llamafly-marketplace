import { useState } from "react";
import styles from "./search-bar.module.css";
import { ButtonDefault } from "../button-default";

type Props = {
  onSearch: (value: string) => void;
};

export const SearchBar = ({ onSearch }: Props) => {
  const [searchValue, setSearchValue] = useState<string>("");

  const handleSearch = () => {
    if (searchValue != undefined && searchValue != "") {
      onSearch(searchValue);
      setSearchValue("");
    }
  };

  const handleSearchChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchValue(event.target.value);
  };

  const handleClick = () => {
    handleSearch();
  };

  const handleKeyDown = (event: React.KeyboardEvent<HTMLInputElement>) => {
    if (event.key == "Enter") handleSearch();
  };

  return (
    <div className={styles.container}>
      <input
        className={styles.searchInput}
        onChange={handleSearchChange}
        onKeyDown={handleKeyDown}
        value={searchValue}
        type="text"
        name="search"
        maxLength={100}
      />
      <ButtonDefault text="search" onClick={handleClick} />
    </div>
  );
};

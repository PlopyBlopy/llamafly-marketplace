import { useState } from "react";
import styles from "./search-bar.module.css";
import { PrimaryFlatButtonIcon } from "../components/primary-flat-button-icon/primary-flat-button-icon";
import { Icons } from "../assets/icons";

type Props = {
  onSearch: (value: string) => void;
};

export const SearchBar = ({ onSearch }: Props) => {
  const [searchValue, setSearchValue] = useState<string>("");

  const handleSearch = () => {
    if (searchValue != undefined && searchValue != "") {
      onSearch(searchValue);
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
        className={styles.input}
        onChange={handleSearchChange}
        onKeyDown={handleKeyDown}
        value={searchValue}
        placeholder="Искать на JuiceLlama"
        type="text"
        name="text"
        maxLength={100}
      />
      <PrimaryFlatButtonIcon onClick={handleClick} IconComponent={Icons.elements.search} />
    </div>
  );
};

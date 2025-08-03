import styles from "./drop-down-select.module.css";
import { useState } from "react";
import type { DropDown } from "./drop-down-select.model";
import type { StringNumber } from "@/shared/union-type";

type Props = {
  onSelectedOption: (value: StringNumber) => void;
  dropDown: DropDown;
};

export const DropDownSelect = ({ onSelectedOption, dropDown }: Props) => {
  const [selectedOption, setSelectedOption] = useState<StringNumber>(dropDown.options[0].value);

  const changeOptionHandler = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setSelectedOption(event.target.value);
    onSelectedOption(event.target.value);
  };

  return (
    <div className={styles.container}>
      <div>
        <header>{dropDown.name}</header>
        <select className={styles.dropdown} onChange={changeOptionHandler} value={selectedOption}>
          {dropDown.options.map((option) => (
            <option key={option.name} value={option.value}>
              {option.name}
            </option>
          ))}
        </select>
      </div>
    </div>
  );
};

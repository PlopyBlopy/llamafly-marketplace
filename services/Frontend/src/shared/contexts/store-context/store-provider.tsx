import { RootStore } from "@/entities/stores/root-store";
import { StoreContext } from "./store-context.model";

export const StoreProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  const store = new RootStore();

  return <StoreContext.Provider value={store}>{children}</StoreContext.Provider>;
};

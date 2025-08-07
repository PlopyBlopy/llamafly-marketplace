import { RootStore } from "@/entities/root-store";
import { createContext } from "react";

export const StoreContext = createContext<RootStore | null>(null);

import type { AxiosInstance } from "axios";
import axios from "axios";
import type { ServiceApiConfig } from "../axios";

export const CreateApi = (config: ServiceApiConfig): AxiosInstance => {
  return axios.create(config);
};

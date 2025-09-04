import type { ServiceApiConfig } from "../axios";

export const AuthServiceApiConfig: ServiceApiConfig = {
  baseURL: import.meta.env.VITE_AUTH_API_URL,
  withCredentials: true,
};

export const ProfileServiceApiConfig: ServiceApiConfig = {
  baseURL: import.meta.env.VITE_PROFILES_API_URL,
};

export const ProductServiceApiConfig: ServiceApiConfig = {
  baseURL: import.meta.env.VITE_PRODUCTS_API_URL,
};

export const ImageServiceApiConfig: ServiceApiConfig = {
  baseURL: import.meta.env.VITE_IMAGES_API_URL,
};

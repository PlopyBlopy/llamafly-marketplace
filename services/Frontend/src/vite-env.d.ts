/// <reference types="vite/client"/>
interface ImportMetaEnv {
  readonly VITE_AUTH_API_URL: string;
  readonly VITE_PROFILES_API_URL: string;
  readonly VITE_PRODUCTS_API_URL: string;
  readonly VITE_IMAGES_API_URL: string;
}

interface ImportMeta {
  readonly env: ImportMetaEnv;
}

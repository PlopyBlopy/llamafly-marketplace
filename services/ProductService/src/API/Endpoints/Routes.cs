namespace API.Endpoints
{
    public static class Routes
    {
        //default product endpoint value
        public const string DEFAULT = "/api";

        public const string PRODUCTS = $"{DEFAULT}/products";
        public const string UPDATE_PRODUCT = $"{PRODUCTS}";
        public const string REMOVE_PRODUCT = $"{PRODUCTS}";

        public const string GET_BY_ID_PRODUCTS = $"{PRODUCTS}";
        public const string GET_ALL_PRODUCTS = $"{PRODUCTS}/all";

        //default categories endpoint value
        public const string CATEGORIES = "/api/categories";
    }
}
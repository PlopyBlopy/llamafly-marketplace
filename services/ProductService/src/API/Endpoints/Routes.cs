namespace API.Endpoints
{
    public static class Routes
    {
        //default api endpoint value
        public const string API_VERSION = "v1";

        public const string DEFAULT = $"api/{API_VERSION}";

        public const string PING = $"{DEFAULT}/ping";

        //default product endpoint value

        public const string PRODUCTS = $"{DEFAULT}/products";

        public const string UPDATE_PRODUCT = $"{PRODUCTS}";
        public const string REMOVE_PRODUCT = $"{PRODUCTS}";

        public const string GET_BY_ID_PRODUCTS = $"{PRODUCTS}";

        public const string GET_ALL_PRODUCTS = $"{PRODUCTS}/all";

        //default product card endpoint value

        public const string GET_ALL_PRODUCTS_CARDS = $"{PRODUCTS}/cards";
        public const string GET_ALL_PRODUCTS_CARDS_FILTERED = $"{PRODUCTS}/cards/filters";

        //default categories endpoint value

        public const string CATEGORIES = $"{DEFAULT}/categories";

        public const string CREATE_CATEGORY = $"{CATEGORIES}";
        public const string CREATE_CATEGORIES_RANGE = $"{CATEGORIES}/range";

        public const string GET_BY_ID_CATEGORY = $"{CATEGORIES}/{{id}}";
        public const string CATEGORY_EXIST = $"{CATEGORIES}/exist/{{id}}";
    }
}
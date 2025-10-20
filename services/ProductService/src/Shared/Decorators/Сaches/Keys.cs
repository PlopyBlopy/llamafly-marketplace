namespace Shared.Decorators.Сaches
{
    public static class Keys
    {
        // products
        public const string DEFAULT_PRODUCTS = "products";

        public static string ProductById(Guid id) => $"{DEFAULT_PRODUCTS}/{id}";

        // product cards
        public const string DEFAULT_CARDS = "cards";

        // categories
        public const string DEFAULT_CATEGORIES = "categories";

        public const string ALL_CATEGORIES_MIN = $"{DEFAULT_CATEGORIES}/all/min";

        public static string CategoryById(Guid id) => $"{DEFAULT_CATEGORIES}/{id}";
    }
}
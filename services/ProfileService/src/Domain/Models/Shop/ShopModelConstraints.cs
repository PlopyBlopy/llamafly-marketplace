namespace Domain.Models.Shop
{
    public static class ShopModelConstraints
    {
        public const int MIN_NAME_LENGTH = 3;
        public const int MAX_NAME_LENGTH = 30;

        public const int MIN_DESCRIPTION_LENGTH = 0;
        public const int MAX_DESCRIPTION_LENGTH = 300;

        public const double MIN_RATING = 0.0;
        public const double MAX_RATING = 5.0;
    }
}
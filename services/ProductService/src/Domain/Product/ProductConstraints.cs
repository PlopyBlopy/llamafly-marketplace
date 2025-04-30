namespace Domain.Product
{
    public static class ProductConstraints
    {
        public const int MIN_TITLE_LENGTH = 5;
        public const int MAX_TITLE_LENGTH = 200;

        public const int MIN_Description_LENGTH = 0;
        public const int MAX_Description_LENGTH = 6000;

        public const decimal MIN_PRICE = 50;
        public const decimal MAX_PRICE = 10000000;

        public const double MIN_RATING = 0.0;
        public const double MAX_RATING = 5.0;
    }
}
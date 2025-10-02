namespace Shared.Extensions
{
    internal static class ErrorsMessages
    {
        public static readonly string NotNull = "Is required.";
        public static readonly string NotEmpty = "It cannot be empty.";
        public static readonly string NotExist = "It doesn't exist.";
        public static readonly string NotFound = "Not found.";

        public static string CharactersLength(int length)
            => $"Must contain {length} characters.";

        public static string CharactersLength(int minLength, int maxLength)
            => $"Must contain at least {minLength} characters and no more than {maxLength} characters in length.";

        public static string ValueBetween(int minValue, int maxValue)
            => $"It must be between the values of {minValue} and {maxValue}.";

        public static string ValueBetween(double minValue, double maxValue)
            => $"It must be between the values of {minValue} and {maxValue}.";

        public static string ValueBetween(decimal minValue, decimal maxValue)
            => $"It must be between the values of {minValue} and {maxValue}.";
    }
}
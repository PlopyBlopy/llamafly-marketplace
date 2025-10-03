namespace Domain.Models
{
    public static class CommonModelErrors
    {
        public const string INCORRECT_EMAIL_FORMAT = "Incorrect email format";
        public const string INCORRECT_PHONE_NUMBER_FORMAT = "Incorrect phone number format";

        public static string ContainsLetters() => "It can contain only letters!";

        public static string ContainsDigits() => "It can contain only digits!";
    }
}
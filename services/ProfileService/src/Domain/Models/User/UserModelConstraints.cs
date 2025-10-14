namespace Domain.Models.User
{
    public static class UserModelConstraints
    {
        public enum LoginVariants
        {
            Login,
            PhoneNumber,
            Email
        }

        public const int MIN_LOGIN_LENGTH = 5;
        public const int MAX_LOGIN_LENGTH = 20;
    }
}
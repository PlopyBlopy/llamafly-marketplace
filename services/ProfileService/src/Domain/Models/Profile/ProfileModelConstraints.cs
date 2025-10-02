namespace Domain.Models.Profile
{
    public static class ProfileModelConstraints
    {
        public const int MIN_NAME_LENGTH = 3;
        public const int MAX_NAME_LENGTH = 15;

        public const int MIN_SURNAME_LENGTH = 3;
        public const int MAX_SURNAME_LENGTH = 25;

        public const int MIN_PATRONYMIC_LENGTH = 3;
        public const int MAX_PATRONYMIC_LENGTH = 25;

        public const int MIN_AGE = 1;
        public const int MAX_AGE = 100;

        public const bool MALE = true;
        public const bool FEMALE = false;
    }
}
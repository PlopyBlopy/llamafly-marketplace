namespace API.Endpoints
{
    public static class Routes
    {
        //default api endpoint value
        public const string API_VERSION = "v1";

        public const string DEFAULT = $"api/{API_VERSION}";

        public const string PING = $"{DEFAULT}/ping";

        //default ProfileService

        public const string PROFILE_SERVICE = $"{DEFAULT}";

        public const string PROFILE = $"{PROFILE_SERVICE}/profile";
        public const string USER = $"{PROFILE_SERVICE}/user";

        public const string LOGIN = $"{USER}/login";
        public const string REGISTER_USER = $"{USER}/register";

        public const string CREATE_ADMIN = $"{PROFILE}/admin";
        public const string CREATE_SELLER = $"{PROFILE}/seller";
        public const string CREATE_CUSTOMER = $"{PROFILE}/customer";
    }
}
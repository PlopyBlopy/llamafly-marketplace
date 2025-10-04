namespace API.Endpoints
{
    public static class Routes
    {
        //default api endpoint value
        public const string API_VERSION = "v1";

        public const string DEFAULT = $"api/{API_VERSION}";

        public const string PING = $"{DEFAULT}/ping";

        //default product endpoint value

        public const string AUTH = $"{DEFAULT}/auth";

        public const string REGISTER_ADMIN = $"{AUTH}/admin";
        public const string REGISTER_SELLER = $"{AUTH}/seller";
        public const string REGISTER_CUSTOMER = $"{AUTH}/customer";

        public const string LOGIN = $"{AUTH}/user/login";
    }
}
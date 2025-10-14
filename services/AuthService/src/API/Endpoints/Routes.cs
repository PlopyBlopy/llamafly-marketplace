namespace API.Endpoints
{
    public static class Routes
    {
        //default api endpoint value
        public const string API_VERSION = "v1";

        public const string DEFAULT = $"api/{API_VERSION}";

        public const string PING = $"{DEFAULT}/ping";

        //default product endpoint value

        public const string AUTH_SERVICE = $"{DEFAULT}";

        public const string AUTH = $"{AUTH_SERVICE}/auth";

        public const string LOGIN = $"{AUTH}/login";
        public const string REGISTER = $"{AUTH}/register";
    }
}
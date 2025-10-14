using static Domain.Models.CommonConstraints;

namespace Infrastructure.HttpServices
{
    internal static class Routes
    {
        //default api endpoint value
        public const string API_VERSION = "v1";

        public const string DEFAULT = $"api/{API_VERSION}";

        public const string PING = $"{DEFAULT}/ping";

        //default ProfileGrpcService

        public const string PROFILE_SERVICE = $"{DEFAULT}";

        public const string PROFILE = $"{PROFILE_SERVICE}/profile";
        public const string USER = $"{PROFILE_SERVICE}/user";

        public const string LOGIN = $"{USER}/login";
        public const string REGISTER_USER = $"{USER}/register";

        public static string LOGIN_QUERY(string loginValue, LoginVariants loginType) => $"{LOGIN}?loginValue={loginValue}&loginType={Enum.GetName(loginType)}";
    }
}
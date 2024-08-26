namespace Manager.RazorWebApp;

public class Endpoints
{
    public const string AccountBase = "https://localhost:7001";
    public const string ApartmentBase = "https://localhost:7000";


    public class Account
    {
        public const string Login = "/api/user/login";
        public const string Logout = "/api/user/logout";
        public const string GetProfile = "/api/user/getProfile";
        public const string UploadPicture = "/api/user/uploadPicture";
        public const string ChangePassword = "/api/user/changePassword";
        public const string RefreshLogin = "/api/user/refreshLogin";
        public const string UploadPhoto = "/api/user/uploadPhoto";
    }

    public class Apartment
    {
        public const string GetSiteByManagerId = "/api/apartment/site/getSiteByManagerId";
        public const string GetSiteDetailByManagerId = "/api/apartment/site/getSiteDetailByManagerId";
        public const string GetUnitById = "/api/apartment/unit/getUnitById";

    }

}

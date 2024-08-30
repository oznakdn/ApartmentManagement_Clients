namespace Shared;

public class Endpoints
{
    public static class Account
    {
        public const string BaseUrl = "https://localhost:7001";
        /// <summary>
        /// POST - BODY: Email, Password
        /// </summary>
        public const string Login = "/api/user/login";


        /// <summary>
        /// GET - URL PARAM: RefreshToken
        /// </summary>
        public const string RefreshLogin = "/api/user/refreshLogin";


        /// <summary>
        /// GET - URL PARAM: RefreshToken
        /// </summary>
        public const string Logout = "/api/user/logout";


        /// <summary>
        /// GET - URL PARAM: UserId
        /// </summary>
        public const string GetProfile = "/api/user/getProfile";


        /// <summary>
        /// GET - URL PARAM: UserId
        /// </summary>
        public const string GetAccountById = "/api/user/getAccountById";


        /// <summary>
        /// GET
        /// </summary>
        public const string GetAccounts = "/api/user/getAccounts";


        /// <summary>
        /// PUT - BODY: UserId, PictureUrl
        /// </summary>
        public const string UploadPhoto = "/api/user/uploadPhoto";


        /// <summary>
        /// PUT - BODY: UserId
        /// </summary>
        public const string MakeGuardToEmployee = "/api/user/makeGuardToEmployee";


        /// <summary>
        /// PUT - BODY: UserId,CurrentPassword,NewPassword
        /// </summary>
        public const string ChangePassword = "/api/user/changePassword";


        /// <summary>
        /// PUT - BODY: CurrentEmail,NewEmail
        /// </summary>
        public const string ChangeEmail = "/api/user/changeEmail";


        /// <summary>
        /// POST - BODY: FirstName, LastName, Email, Password, PhoneNumber, Address
        /// </summary>
        public const string ManagerRegister = "/api/user/managerRegister";


        /// <summary>
        /// GET
        /// </summary>
        public const string GetManagers = "/api/user/getManagers";

        /// <summary>
        /// GET - URL PARAM: userId
        /// </summary>
        public const string GetManagerById = "/api/user/getManagerById";


        /// <summary>
        /// DELETE - URL PARAM: userId
        /// </summary>
        public const string DeleteManager = "/api/user/deleteManager";

    }


    public static class Apartment
    {
        public const string BaseUrl = "https://localhost:7000";

        /// <summary>
        /// GET - URL PARAM: SiteId
        /// </summary>
        public const string GetSiteById = "/api/apartment/site/getSiteById";


        /// <summary>
        /// GET
        /// </summary>
        public const string GetAllSite = "/api/apartment/site/getAllSite";


        /// <summary>
        /// GET - URL PARAM: string ManagerId
        /// </summary>
        public const string GetSiteByManagerId = "/api/apartment/site/getSiteByManagerId";


        /// <summary>
        /// GET - URL PARAM: string ManagerId
        /// </summary>
        public const string GetSiteDetailByManagerId = "/api/apartment/site/getSiteDetailByManagerId";


        /// <summary>
        /// GET - URL PARAM: string UnitId
        /// </summary>
        public const string GetUnitById = "/api/apartment/unit/getUnitById";


        /// <summary>
        /// POST - BODY: string? ManagerId, string Name, string Address
        /// </summary>
        public const string CreateSite = "/api/apartment/site/create";


        /// <summary>
        /// DELETE - URL: string SiteId
        /// </summary>
        public const string DeleteSite = "/api/apartment/site/delete";


        /// <summary>
        /// PUT - BODY: string UserId, string SiteId
        /// </summary>
        public const string AssignManager = "/api/apartment/site/assignManagerToSite";

        


    }


    public static class Aggrigator
    {

        public const string BaseUrl = "https://localhost:7000";
        /// <summary>
        /// GET
        /// </summary>
        public const string GetApartmentCounts = "/api/aggregator/getApartmentCounts";
    }

}

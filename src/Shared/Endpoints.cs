namespace Shared;

public class Endpoints
{
    public static class Account
    {
        public const string BaseUrl = "https://localhost:7001/api/user";
        /// <summary>
        /// POST - BODY: Email, Password
        /// </summary>
        public const string Login = "/login";


        /// <summary>
        /// GET - URL PARAM: RefreshToken
        /// </summary>
        public const string RefreshLogin = "/refreshLogin";


        /// <summary>
        /// GET - URL PARAM: RefreshToken
        /// </summary>
        public const string Logout = "/logout";


        /// <summary>
        /// GET - URL PARAM: UserId
        /// </summary>
        public const string GetProfile = "/getProfile";


        /// <summary>
        /// GET - URL PARAM: UserId
        /// </summary>
        public const string GetAccountById = "/getAccountById";


        /// <summary>
        /// GET
        /// </summary>
        public const string GetAccounts = "/getAccounts";


        /// <summary>
        /// PUT - BODY: UserId, PictureUrl
        /// </summary>
        public const string UploadPhoto = "/uploadPhoto";


        /// <summary>
        /// PUT - BODY: UserId
        /// </summary>
        public const string MakeGuardToEmployee = "/makeGuardToEmployee";


        /// <summary>
        /// PUT - BODY: UserId,CurrentPassword,NewPassword
        /// </summary>
        public const string ChangePassword = "/changePassword";


        /// <summary>
        /// PUT - BODY: CurrentEmail,NewEmail
        /// </summary>
        public const string ChangeEmail = "/changeEmail";


        /// <summary>
        /// POST - BODY: FirstName, LastName, Email, Password, PhoneNumber, Address
        /// </summary>
        public const string ManagerRegister = "/managerRegister";


        /// <summary>
        /// GET
        /// </summary>
        public const string GetManagers = "/getManagers";

        /// <summary>
        /// GET - URL PARAM: userId
        /// </summary>
        public const string GetManagerById = "/getManagerById";


        /// <summary>
        /// DELETE - URL PARAM: userId
        /// </summary>
        public const string DeleteManager = "/deleteManager";

    }


    public static class Apartment
    {
        public const string BaseUrl = "https://localhost:7000/api/apartment";

        /// <summary>
        /// GET - URL PARAM: SiteId
        /// </summary>
        public const string GetSiteById = "/site/getSiteById";


        /// <summary>
        /// GET
        /// </summary>
        public const string GetAllSite = "/site/getAllSite";

        /// <summary>
        /// POST - BODY: string? ManagerId, string Name, string Address
        /// </summary>
        public const string CreateSite = "/site/create";


        /// <summary>
        /// DELETE - URL: string SiteId
        /// </summary>
        public const string DeleteSite = "/site/delete";


        /// <summary>
        /// PUT - BODY: string UserId, string SiteId
        /// </summary>
        public const string AssignManager = "/site/assignManagerToSite";

        


    }


    public static class Aggrigator
    {

        public const string BaseUrl = "https://localhost:7000/api/aggregator";
        /// <summary>
        /// GET
        /// </summary>
        public const string GetApartmentCounts = "/getApartmentCounts";
    }

}

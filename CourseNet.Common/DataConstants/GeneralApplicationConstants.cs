﻿namespace CourseNet.Common.DataConstants
{
    public static class GeneralApplicationConstants
    {
        public const int DefaultPage = 1;
        public const int EntitiesPerPage = 3;

        public const string RequireErrorMessage = "Полето {0} е задължително за попълване.";
        public const string LengthErrorMessage = "Полето {0} трябва да бъде поне {2} и с максимална дължина {1}.";

        public const string AdminAreaName = "Admin";
        public const string AdministratorRoleName = "Administrator";
        public const string DevelopmentAdminEmail = "admin@coursenet.bg";

        public const string UsersCacheKey = "UsersCacheKey";
        public const string EnrollCacheKey = "EnrollsCacheKey";
        public const int UsersCacheExpirationInMinutes = 5;
        public const int EnrollCacheExpirationInMinutes = 10;

        public const string OnlineUsersCookieName = "OnlineUsers";
        public const int LastActivityBeforeOffline = 10;
    }
}

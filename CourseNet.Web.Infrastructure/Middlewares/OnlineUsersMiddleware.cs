using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;
using CourseNet.Web.Infrastructure.Extensions;
using static CourseNet.Common.DataConstants.GeneralApplicationConstants;

namespace CourseNet.Web.Infrastructure.Middlewares
{
    public class OnlineUsersMiddleware
    {
        private readonly RequestDelegate next;
        private readonly string cookieName;
        private readonly int lastActivityMinutes;
        private static readonly ConcurrentDictionary<string, bool> AllKeys =
            new ConcurrentDictionary<string, bool>();

        public OnlineUsersMiddleware(RequestDelegate next, string cookieName = OnlineUsersCookieName, int lastActivityMinutes = LastActivityBeforeOffline)
        {
            this.next = next;
            this.cookieName = cookieName;
            this.lastActivityMinutes = lastActivityMinutes;
        }

        // Invoke method to handle the request
        public Task InvokeAsync(HttpContext context, IMemoryCache memoryCache)
        {
            if (context.User.Identity?.IsAuthenticated ?? false)
            {
                if (!context.Request.Cookies.TryGetValue(this.cookieName, out string userId))
                {
                    // First login after being offline
                    userId = context.User.GetId()!;

                    // Add the cookie to the response
                    context.Response.Cookies.Append(this.cookieName, userId, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        MaxAge = TimeSpan.FromDays(30)
                    });
                }

                memoryCache.GetOrCreate(userId, cacheEntry =>
                {
                    if (!AllKeys.TryAdd(userId, true))
                    {
                        // Adding key failed to the concurrent dictionary, so we have an error
                        cacheEntry.AbsoluteExpiration = DateTimeOffset.MinValue;
                    }
                    else
                    {
                        // Set the sliding expiration for the user when he is active in the system 
                        cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(lastActivityMinutes);

                        // Register a callback to remove the key from the concurrent dictionary when the user is inactive
                        cacheEntry.RegisterPostEvictionCallback(RemoveKeyWhenExpired);
                    }
                    return string.Empty;
                });
            }
            else
            {
                //User has logged out
                if (context.Request.Cookies.TryGetValue(cookieName, out string userId))
                {
                    // Remove the key from the concurrent dictionary
                    if (!AllKeys.TryRemove(userId, out _))
                    {
                        // If the key is not removed, try to update it
                        AllKeys.TryUpdate(userId, false, true);
                    }
                    // Remove the cookie
                    context.Response.Cookies.Delete(cookieName);
                }
            }
            // Continue to the next middleware
            return next(context);
        }
        // Method to check if the user is online
        public static bool CheckIfUserIsOnline(string userId)
        {
            // Check if the user is online
            bool valueTaken = AllKeys.TryGetValue(userId.ToLower(), out bool success);

            // Return the result
            return success && valueTaken;
        }

        // Callback method to remove the key from the concurrent dictionary
        private void RemoveKeyWhenExpired(object key, object value, EvictionReason reason, object state)
        {
            string keyStr = (string)key; //UserId

            // Remove the key from the concurrent dictionary
            if (!AllKeys.TryRemove(keyStr, out _))
            {
                // If the key is not removed, try to update it
                AllKeys.TryUpdate(keyStr, false, true);
            }
        }
    }
}
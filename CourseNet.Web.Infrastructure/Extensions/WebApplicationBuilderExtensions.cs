using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using CourseNet.Data.Models.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using static CourseNet.Common.DataConstants.GeneralApplicationConstants;

namespace CourseNet.Web.Infrastructure.Extensions
{
    public static class WebApplicationBuilderExtensions
    {

        /// <summary>
        /// The method registers all services from the assembly of the provided service type.
        /// The assembly is taken from the provided service type.
        /// </summary>
        /// <param name="serviceType">Type of any service implementation.</param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);

            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service provided!");
            }

            Type[] servicesTypes = serviceAssembly.GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();

            foreach (Type type in servicesTypes)
            {
                Type? interfaceType = type.GetInterface($"I{type.Name}");
                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"Service {type.Name} does not have a corresponding interface!");
                }

                services.AddScoped(interfaceType, type);
            }
        }

        public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string email)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var serviceProvider = scopedServices.ServiceProvider;

            var userManager = serviceProvider.GetRequiredService<UserManager<CourseUser>>();

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                {
                    return;
                }

                var role = new IdentityRole<Guid>(AdministratorRoleName);

                await roleManager.CreateAsync(role);

                var adminUser = userManager.FindByEmailAsync(email);

                if (adminUser == null)
                {
                    return;
                }

                await userManager.AddToRoleAsync(adminUser.Result, role.Name);
            })
            .GetAwaiter()
            .GetResult();

            return app;
        }
    }
}

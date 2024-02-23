using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
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
    }
}

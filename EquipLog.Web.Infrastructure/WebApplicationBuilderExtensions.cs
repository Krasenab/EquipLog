using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EquipLog.Web.Infrastructure
{
    /*Разшеряваме builder.Services за да инжектираме нашите сървиси.Вместо да се инжектират  директно в Program.cs*/
    public static class WebApplicationBuilderExtensions
    {
        /*За да избегнем забравянето на добавяне на нови сървиси добавяме към метода(функцията) обект Type (servicesType) на сървиса и ще изполваме рефлекшън,
         * за добавянето на всички сървиси и нови такива с техните интерфейси и имплементации  */
        public static void AddAppServices(this IServiceCollection services,Type serviceType) 
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
            if (serviceAssembly ==null)
            {
                throw new InvalidOperationException("Invalid service");
            }
            Type[] serivcesType = serviceAssembly.GetTypes().Where(x=>x.Name.EndsWith("Service") && !x.IsInterface).ToArray();
            foreach (Type type in serivcesType) 
            {
                Type? getTypeInterfaces = type.GetInterface($"I{type.Name}");
                if (getTypeInterfaces == null) 
                {
                    throw new InvalidOperationException("No interface provided for the service.");
                }

                services.AddScoped(getTypeInterfaces, type);
            }
        }
    }
}

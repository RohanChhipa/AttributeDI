using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Lib
{
    public static class InjectionExtensions
    {
        public static void ScanAssembly(this IServiceCollection serviceCollection, Assembly assembly)
        {
            var components = assembly.GetTypes()
                .Select(type => (InjectedType: type,
                    InjectionComponentAttribute: type.GetCustomAttribute<InjectionComponentAttribute>()))
                .Where(tuple => tuple.InjectionComponentAttribute != null)
                .ToList();

            foreach (var (injectedType, injectionComponentAttribute) in components)
            {
                Func<Type, IServiceCollection> addScoped = serviceCollection.AddScoped;

                switch (injectionComponentAttribute.ServiceLifetime)
                {
                    case ServiceLifetime.Scoped:
                        addScoped(injectedType);
                        break;
                    case ServiceLifetime.Singleton:
                        serviceCollection.AddSingleton(injectedType);
                        break;
                    case ServiceLifetime.Transient:
                        serviceCollection.AddTransient(injectedType);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
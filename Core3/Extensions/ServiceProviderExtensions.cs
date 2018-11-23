using Microsoft.Extensions.Logging;
using System;

namespace Core3.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static ILogger GetLogger(this IServiceProvider provider)
        {
            return provider.GetService<ILogger>();
        }

        public static T GetService<T>(this IServiceProvider provider)
        {
            return (T)provider.GetService(typeof(T));
        }
    }
}

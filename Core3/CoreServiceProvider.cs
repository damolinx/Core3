using System;
using System.Collections.Generic;

namespace Core3
{
    public class CoreServiceProvider : IServiceProvider
    {
        private readonly IDictionary<Type, Func<IServiceProvider, object>> _dictionary;

        public CoreServiceProvider()
        {
            _dictionary = new Dictionary<Type, Func<IServiceProvider, object>>();
        }

        public void Add<TService>()
            where TService : new()
        {
            Add<TService>(sp => new TService());
        }

        public void Add<TService>(Func<IServiceProvider, object> factory)
        {
            if (factory == null) throw new ArgumentNullException(nameof(factory));
            _dictionary[typeof(TService)] = factory;
        }

        public void AddSingleton<TService>(object service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            Add<TService>(sp => service);
        }

        public object GetService(Type serviceType)
        {
            return _dictionary.TryGetValue(serviceType, out var factory)
                ? factory(this)
                : null;
        }
    }
}

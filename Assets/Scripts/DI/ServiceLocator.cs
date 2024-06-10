using System;
using System.Collections.Generic;

namespace DI
{
    public class ServiceLocator
    {
        private Dictionary<Type, IService> _services = new Dictionary<Type, IService>();
        
        public static ServiceLocator Instance;

        public ServiceLocator()
        {
        }

        public static void Init()
        {
            if (Instance == null)
                Instance = new ServiceLocator();
        }

        public void RegisterService<TService>(TService service) where TService : IService =>
            _services.Add(typeof(TService), service);


        public TService GetService<TService>() where TService : IService => (TService)_services[typeof(TService)];
        
    }

    public interface IService
    {
    }
}
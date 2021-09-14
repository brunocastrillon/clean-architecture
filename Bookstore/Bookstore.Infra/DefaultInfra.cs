using Bookstore.Core.Entities;
using System.Collections.Generic;
using System.Reflection;
using Module = Autofac.Module;

namespace Bookstore.Infra
{
    public class DefaultInfra : Module
    {
        private readonly bool _isDevelopment = false;
        private readonly List<Assembly> _assemblies = new List<Assembly>();

        public DefaultInfra(bool isDevelopment, Assembly callingAssembly = null)
        {
            _isDevelopment = isDevelopment;

            var coreAssembly = Assembly.GetAssembly(typeof(Author));
            var infrastructureAssembly = Assembly.GetAssembly(typeof(StartupSetup));

            _assemblies.Add(coreAssembly);
            _assemblies.Add(infrastructureAssembly);

            if (callingAssembly != null)
            {
                _assemblies.Add(callingAssembly);
            }
        }
    }
}
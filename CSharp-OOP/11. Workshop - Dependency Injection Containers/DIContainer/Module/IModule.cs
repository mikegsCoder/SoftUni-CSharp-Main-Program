using DIContainer.Attributes;
using System;

namespace DIContainer.Module
{
    public interface IModule
    {
        public void Configure();

        public Type GetMapping(Type interfaceType, Named namedAttribute = null);

        public void CreateMapping<TInterface, TImplementation>();

    }
}

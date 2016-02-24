using Mango.Dependencies.StructureMap;
using StructureMap;

namespace Mango.Dependencies
{
    public static class IoC
    {
        private static IContainer _container;

        public static IContainer Container => _container ?? (_container = Initialize());

        public static IContainer Initialize()
        {
            _container = new Container(c => c.AddRegistry<IocRegistry>());
            IocRegistry.RegisterMappings(_container);
            return _container;
        }
    }
}

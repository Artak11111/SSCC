using Autofac;
using System;
using System.Threading.Tasks;

namespace ControlCenter.Client.ServiceLocators
{
    public static class ServiceLocator
    {
        public static IContainer Container { get; private set; }


        public static void Initialize(IContainer container)
        {
            Container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public static async Task Dispose()
        {
            await Container.DisposeAsync();
        }
    }
}

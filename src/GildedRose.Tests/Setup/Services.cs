using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Test.Setup
{    internal class Services
    {
        private IServiceProvider _services;

        public Services()
        {
            var services = new ServiceCollection();
            GildedRose.Engine.Startup.Initialize(services);
            _services = services.BuildServiceProvider();
        }

        public T GetService<T>() => _services.GetService<T>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Tests.Setup
{
    internal class Services
    {
        private IServiceProvider _services;

        public Services()
        {
            var services = new ServiceCollection();
            GildedRose.Engine.Startup.Initialize(services);
            _services = services.BuildServiceProvider();
        }
    }
}

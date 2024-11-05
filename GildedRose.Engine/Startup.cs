using GildedRose.Interfaces.Engine;
using Microsoft.Extensions.DependencyInjection;

namespace GildedRose.Engine
{
    public static class Startup
    {
        public static void Initialize(IServiceCollection services)
         => _ = services.AddSingleton<IQualityService, QualityService>();

    }
}

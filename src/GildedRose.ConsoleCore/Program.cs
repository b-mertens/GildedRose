// See https://aka.ms/new-console-template for more information
using GildedRose.Engine;
using GildedRose.Interfaces.Engine;
using GildedRose.Models.General;
using GildedRose.Models.Models;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
Startup.Initialize(services);
using var serviceProvider = services.BuildServiceProvider();


System.Console.WriteLine("OMGHAI!");

var items = new List<Item>
        {
            new Item {Name = ProductNames.DexterityVest, SellIn = 10, Quality = 20},
            new Item {Name = ProductNames.AgedBrie, SellIn = 2, Quality = 0},
            new Item {Name = ProductNames.ElixirMongoose, SellIn = 5, Quality = 7},
            new Item {Name = ProductNames.Sulfuras, SellIn = 0, Quality = 80},
            new Item
            {
                Name = ProductNames.BackstagePasses,
                SellIn = 15,
                Quality = 20
            },
            new Item {Name = ProductNames.Conjured, SellIn = 3, Quality = 6}
        };

var qualityService = serviceProvider.GetService<IQualityService>();
var result = await qualityService.UpdateQualityAsync(items);


System.Console.ReadKey();






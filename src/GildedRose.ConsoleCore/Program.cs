// See https://aka.ms/new-console-template for more information
using GildedRose.Engine;
using GildedRose.Interfaces.Engine;
using GildedRose.Models.Models;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
Startup.Initialize(services);
using var serviceProvider = services.BuildServiceProvider();


System.Console.WriteLine("OMGHAI!");

var items = new List<Item>
        {
            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            },
            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
        };

var qualityService = serviceProvider.GetService<IQualityService>();
var result = await qualityService.UpdateQualityAsync(items);


System.Console.ReadKey();






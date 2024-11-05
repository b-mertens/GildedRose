// See https://aka.ms/new-console-template for more information
using GildedRose.Engine;
using GildedRose.Interfaces.Engine;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
Startup.Initialize(services);
using var serviceProvider = services.BuildServiceProvider();


System.Console.WriteLine("OMGHAI!");

var items = GildedRose.Data.Items.ItemList;

var qualityService = serviceProvider.GetService<IQualityService>();
var result = await qualityService.UpdateQualityAsync(items);


System.Console.ReadKey();






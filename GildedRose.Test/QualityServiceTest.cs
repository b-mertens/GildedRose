using GildedRose.Interfaces.Engine;
using GildedRose.Models.Models;
using GildedRose.Tests.Setup;
using Xunit;

namespace GildedRose.Test
{
        public class QualityServiceTest
    {
        [Fact]
        public void ValidateItemsLength()
        {
            var items = new List<Item>{ new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20} };

            var result = new Services().GetService<IQualityService>().UpdateQualityAsync(items).Result;

            Assert.Equal(items.Count, result.Count);
        }
    }
}
using GildedRose.Interfaces.Engine;
using GildedRose.Models.Models;
using GildedRose.Test.Setup;

namespace GildedRose.Test
{
    [TestClass]
    public class BackStagePassesQualityServiceTest
    {

        [TestMethod]
        [DataRow(3)]
        public void ValidateQualityForBackStageIncreaseAbove10(int quality)
        {
            var items = new List<Item>{
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15 , Quality = quality}
            };

            new Services().GetService<IQualityService>().UpdateQuality(items);

            Assert.AreEqual(items[0].Quality, quality + 1);
        }

        [TestMethod]
        [DataRow(3)]
        public void ValidateQualityForBackStageIncreaseLess10(int quality)
        {
            var items = new List<Item>{
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8 , Quality = quality}
            };

            new Services().GetService<IQualityService>().UpdateQuality(items);

            Assert.AreEqual(items[0].Quality, quality + 2);
        }

        [TestMethod]
        [DataRow(3)]
        public void ValidateQualityForBackStageIncreaseLess3(int quality)
        {
            var items = new List<Item>{
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3 , Quality = quality}
            };

            new Services().GetService<IQualityService>().UpdateQuality(items);

            Assert.AreEqual(items[0].Quality, quality + 3);
        }

        [TestMethod]
        [DataRow(3)]
        public void ValidateQualityForBackStageIncreaseAfterSellin(int quality)
        {
            var items = new List<Item>{
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0 , Quality = quality}
            };

            new Services().GetService<IQualityService>().UpdateQuality(items);

            Assert.AreEqual(items[0].Quality, 0);
        }

    }
}
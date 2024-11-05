using GildedRose.Interfaces.Engine;
using GildedRose.Models.Models;
using GildedRose.Test.Setup;

namespace GildedRose.Test
{
    [TestClass]
    public class QualityServiceTest
    {
        [TestMethod]
        public void ValidateLengthOfItemList()
        {
            var items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}
            };

            new Services().GetService<IQualityService>().UpdateQuality(items); 

            Assert.AreEqual(items.Count, 1);
        }

        [TestMethod]    
        [DataRow(3)]
        public void ValidateSellInForNormalItem(int sellIn)
        {
            var items = new List<Item>{
                new Item { SellIn = sellIn}
            };

            new Services().GetService<IQualityService>().UpdateQuality(items);

            Assert.AreEqual(items[0].SellIn, sellIn - 1);
        }

        [TestMethod]
        [DataRow(3)]
        public void ValidateQualityForNormalItem(int quality)
        {
            var items = new List<Item>{
                new Item { SellIn = 1, Quality = quality}
            };

            new Services().GetService<IQualityService>().UpdateQuality(items);

            Assert.AreEqual(items[0].Quality, quality - 1);
        }

        [TestMethod]
        [DataRow(3)]
        public void ValidateDoubleQualityDecreasePastSellIn(int quality)
        {
            var items = new List<Item>{
                new Item { SellIn = 0, Quality = quality}
            };

            new Services().GetService<IQualityService>().UpdateQuality(items);

            Assert.AreEqual(items[0].Quality, quality - 2);
        }

        [TestMethod]
        [DataRow(0)]
        public void ValidateNegativeQuality(int quality)
        {
            var items = new List<Item>{
                new Item { Quality = quality}
            };

            new Services().GetService<IQualityService>().UpdateQuality(items);

            Assert.AreEqual(items[0].Quality, quality);
        }
    }
}
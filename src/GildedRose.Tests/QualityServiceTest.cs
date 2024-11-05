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

        [TestMethod]
        public void ValidateFixedProgramData()
        {
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
            new Services().GetService<IQualityService>().UpdateQuality(items);

            //"+5 Dexterity Vest"
            Assert.AreEqual(items[0].Quality, 19);
            Assert.AreEqual(items[0].SellIn, 9);
            //"Aged Brie"
            Assert.AreEqual(items[1].Quality, 1);
            Assert.AreEqual(items[1].SellIn, 1);
            // "Elixir of the Mongoose"
            Assert.AreEqual(items[2].Quality, 6);
            Assert.AreEqual(items[2].SellIn, 4);
            // "Sulfuras, Hand of Ragnaros"
            Assert.AreEqual(items[3].Quality, 80);
            Assert.AreEqual(items[3].SellIn, 0);
            // "Backstage passes to a TAFKAL80ETC concert"
            Assert.AreEqual(items[4].Quality, 21);
            Assert.AreEqual(items[4].SellIn, 14);
            // "Conjured Mana Cake"
            Assert.AreEqual(items[5].Quality, 4); //Changed from 5 to 4 because of the CR
            Assert.AreEqual(items[5].SellIn, 2);
        }
    }
}
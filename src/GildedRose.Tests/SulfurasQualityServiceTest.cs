using GildedRose.Interfaces.Engine;
using GildedRose.Models.Models;
using GildedRose.Test.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Test
{
    [TestClass]
    public class SulfurasQualityServiceTest
    {
        [TestMethod]
        [DataRow(3)]
        public void ValidateUnchangeSellIn(int sellIn)
        {
            var items = new List<Item>{
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = 20}
            };

            new Services().GetService<IQualityService>().UpdateQuality(items);

            Assert.AreEqual(items[0].SellIn, sellIn);
        }

        [TestMethod]
        [DataRow(3)]
        public void ValidateUnchangeQuality(int quality)
        {
            var items = new List<Item>{
                new Item {Name = "Sulfuras, Hand of Ragnaros", Quality = quality}
            };

            new Services().GetService<IQualityService>().UpdateQuality(items);

            Assert.AreEqual(items[0].Quality, quality);
        }
    }
}

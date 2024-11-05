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
    public class AgedBrieQualityServiceTest
    {

        [TestMethod]
        [DataRow(10)]
        public void ValidateQualityIncrease(int quality)
        {
            var items = new List<Item>{
                new Item { Name = "Aged Brie", SellIn = 10, Quality = quality}
            };

            new Services().GetService<IQualityService>().UpdateQuality(items);

            Assert.AreEqual(items[0].Quality, quality + 1);
        }

        [TestMethod]
        [DataRow(50)]
        public void ValidateQualityAbove50(int quality)
        {
            var items = new List<Item>{
                new Item { Name = "Aged Brie", Quality = quality}
            };

            new Services().GetService<IQualityService>().UpdateQuality(items);

            Assert.AreEqual(items[0].Quality, quality);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Models.Models
{
    public class SmartItem : Item
    {
        public SmartItem(Item item)
        {
            Name = item.Name;
            SellIn = item.SellIn;
            Quality = item.Quality;
        }

        /// <summary>
        /// "Aged Brie" actually increases in Quality the older it gets
        /// </summary>
        public bool IncreaseQualityWhenOlder
        {
            get
            {
                return Name?.Equals("Aged Brie", StringComparison.OrdinalIgnoreCase) ?? false;
            }
        }
        /// <summary>
        /// "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        /// </summary>
        public bool IsLegendary
        {
            get
            {
                return Name?.Equals("Sulfuras, Hand of Ragnaros", StringComparison.OrdinalIgnoreCase) ?? false;
            }
        }

        /// <summary>
        /// "Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches; Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but Quality drops to 0 after the concert
        /// </summary>
        public bool IsTimeSensitive
        {
            get
            {
                return Name?.Equals("Backstage passes to a TAFKAL80ETC concert", StringComparison.OrdinalIgnoreCase) ?? false;
            }
        }

        /// <summary>
        /// "Conjured" items degrade in Quality twice as fast as normal items
        /// </summary>
        public bool IsDegradingFast
        {
            get
            {
                return Name?.Equals("Conjured Mana Cake", StringComparison.OrdinalIgnoreCase) ?? false;
            }
        }


        /// <summary>
        /// Github copilot proposal on the UpdateQuality after adding these partical getters*/
        /// </summary>
        /*public void UpdateQuality()
        {
            if (IsLegendary)
            {
                return;
            }

            if (IncreaseQualityWhenOlder)
            {
                Quality++;
            }
            else
            {
                Quality--;
            }

            if (IsTimeSensitive)
            {
                if (SellIn < 0)
                {
                    Quality = 0;
                }
                else if (SellIn < 5)
                {
                    Quality += 3;
                }
                else if (SellIn < 10)
                {
                    Quality += 2;
                }
            }

            if (IsDegradingFast)
            {
                Quality -= 2;
            }
        }*/
    }
}

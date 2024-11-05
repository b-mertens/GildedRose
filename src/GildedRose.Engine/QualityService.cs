using GildedRose.Interfaces.Engine;
using GildedRose.Models.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Engine
{
    internal class QualityService : IQualityService
    {
        public void UpdateQuality(List<Item> Items)
        {
            _ = UpdateQualityAsync(Items).Result; 
        }

        [Obsolete("This method is obsolete, use UpdateQualityAsync instead")]
        public async Task<bool> UpdateQualityOldAsync(List<Item> Items)
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
            return true;
        }
        public async Task<bool> UpdateQualityAsync(List<Item> Items)
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];
                var smartItem = new SmartItem(item);

                if (smartItem.IsLegendary)
                {
                    continue;
                }
                else {
                    item.SellIn--;
                }

                if (smartItem.IsTimeSensitive)
                {
                    // Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but Quality drops to 0 after the SellIn
                    if (item.SellIn < 0)
                    {
                        item.Quality = 0;
                    }
                    else if (item.SellIn <= 5)
                    {
                        item.Quality += 3;
                    }
                    else if (item.SellIn <= 10)
                    {
                        item.Quality += 2;
                    }
                    else
                    {
                        item.Quality++;
                    }
                }
                else
                {
                    if (smartItem.IncreaseQualityWhenOlder)
                    {
                        item.Quality++;
                    }
                    else
                    {
                        item.Quality -= (item.SellIn < 0 ? 2 : 1);
                    }
                }
                // The Quality of an item is never negative
                if (item.Quality < 0) item.Quality = 0;
                // The Quality of an item is never more than 50
                if (item.Quality > 50) item.Quality = 50;
                
            }
            return true;
        }
    }
}

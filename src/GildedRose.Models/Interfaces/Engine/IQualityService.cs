using GildedRose.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Interfaces.Engine

{
    public  interface IQualityService
    {
        Task<bool> UpdateQualityAsync(List<Item> Items);

        void UpdateQuality(List<Item> Items);
    }
}

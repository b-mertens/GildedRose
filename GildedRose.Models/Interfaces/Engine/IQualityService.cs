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
        Task<List<Item>> UpdateQualityAsync(List<Item> Items);
    }
}

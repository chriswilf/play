using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotsOfLinq
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public Item(int n, DateTime date)
        {
            Id = n;
            Name = $"Item-{n}";
            Date = date.AddHours(-n);
        }

        public static Item[] GetItems()
        {
            var now = new DateTime(2022, 1, 1);
            return Enumerable.Range(1, 10000).Select(n => new Item(n, now)).ToArray();
        }
    }


    public class LookUpGroups
    {
        private Item[] items;
        private Dictionary<int, IEnumerable<string>> dict;
        private ILookup<int, string> lookup;


        [GlobalSetup]
        public void Setup()
        {
            items = Item.GetItems();
            
            dict = items
                .GroupBy(i => i.Date.Month)
                .ToDictionary(g => g.Key, g => g.Select(i => i.Name).AsEnumerable());
            
            lookup = items.ToLookup(i => i.Date.Month, i => i.Name);
        }

        [Benchmark]
        public List<string> GetFromArray()
        {
            return items.Where(i => i.Date.Month == 2)
                .Select(i => i.Name)
                .ToList();
        }

        [Benchmark]
        public List<string> GetFromDictionary()
        {
            return dict[2].ToList();
        }

        [Benchmark]
        public List<string> GetFromLookup()
        {
            return lookup[2].ToList();
        }
    }
}

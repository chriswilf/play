using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotsOfLinq
{
    public static class YieldIt
    {
        private const int Million = 1000000;
        

        public static IEnumerable<string> YieldItems()
        {
            IEnumerable<string> databaseItems = DataGenerator.GetListOfStrings(Million);

            foreach(var s in databaseItems)
            {
                yield return s;
            }

        }

        public static IEnumerable<string> ToListItems()
        {
            IEnumerable<string> databaseItems = DataGenerator.GetListOfStrings(Million);

            return databaseItems.ToList();

        }

        public static IEnumerable<string> GetYieldedItems(int amount)
        {
            int num = 0;

            var list = new List<string>();
            foreach (var item in YieldItems())
            {
                num++;
                if (num == amount)
                    break;
                list.Add(item.ToString());
            }

            return list;
        }

        public static IEnumerable<string> GetToListItems(int amount)
        {
            int num = 0;

            var list = new List<string>();
            foreach (var item in ToListItems())
            {
                num++;
                if (num == amount)
                    break;
                list.Add(item.ToString());
            }

            return list;
        }

    }
}

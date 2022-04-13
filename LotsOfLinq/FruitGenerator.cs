using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LotsOfLinq
{
    //[SimpleJob(launchCount: 3, warmupCount: 10, targetCount: 30)]
    public class FruitGenerator
    {
        private static string[] fruits = new[] { "apple", "cherry", "bananna", "orange", "plum", "peach" };
        private static readonly Random getrandom = new Random();
        private List<string> fruits2 = new List<string>();
        private List<string> fruits3 = new List<string>();





        [Benchmark]
        [Arguments(5000000)]
        public string FindMostPopular(int num)
        {
            fruits2 = GenerateFruits(num);

           var fruitDict = new Dictionary<string, int>();

            foreach (var fruit in fruits2)
            {
                if (fruitDict.ContainsKey(fruit))
                {
                    fruitDict[fruit] = fruitDict[fruit] + 1;
                }
                else
                {
                    fruitDict.Add(fruit, 1);
                }
            }

            return fruitDict.OrderByDescending(kvp => kvp.Value).FirstOrDefault().Key;
        }


        [Benchmark]
        [Arguments(5000000)]
        public string FindMostPopularLinq(int num)
        {

            fruits3 = GenerateFruits(num);
        
            var result = fruits3
                          .GroupBy(s => s)
                          .OrderByDescending(g => g.Count())
                          .Select(g => g.Key);

            return result.FirstOrDefault();

        }




        private List<string>
            GenerateFruits(int num)
        {
            List<string> fruitList = new List<string>();

            for (int i = 0; i < num; i++)
            {
                var randomFruit = GetRandomNumber(0, fruits.Length);
                fruitList.Add(fruits[randomFruit]);
            }

            return fruitList;
        }

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom)
            {
                return (int)getrandom.Next(min, max);
            }
        }
    }
}


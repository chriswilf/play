// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using LotsOfLinq;
using System.Diagnostics;
using System.Text.Json;

Console.WriteLine("Hello, World!");

UserPortfolio userPortfolio = DataGenerator.GeneratePortfolio(50);
PortfolioLinqServices portfolioServices = new PortfolioLinqServices(userPortfolio);

var jsonString = JsonSerializer.Serialize(portfolioServices);

Console.WriteLine(jsonString + "\n\n");
Console.WriteLine(portfolioServices.GetFundCount() +"\n");
Console.WriteLine(portfolioServices.GetFundHoldingsCount("F3") + "\n");
Console.WriteLine(userPortfolio.PortfolioValue);


var s = YieldIt.GetYieldedItems(20);
var s1 = YieldIt.GetToListItems(20);


//var summary = BenchmarkRunner.Run<LookUpGroups>();



FruitGenerator gen = new FruitGenerator();

var mostPopularFruit = gen.FindMostPopular(50);

Console.WriteLine(mostPopularFruit);

var mostPopularFruit1 = gen.FindMostPopularLinq(50);

Console.WriteLine(mostPopularFruit1);



var summary = BenchmarkRunner.Run<FruitGenerator>();






//foreach(var st in s)
//{
//    Console.WriteLine(st);
//}

//Console.WriteLine("then");

//foreach (var st in s1)
//{
//    Console.WriteLine(st);
//}


//var t = DataGenerator.RandomSequence(1, 500).ToList();
//foreach(var num in DataGenerator.RandomSequence(1,500))
//{
//    Console.WriteLine(num);
//}

//Console.WriteLine(DataGenerator.RandomSequence(1, 500).First());

Console.ReadLine();

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1586 (21H2)
Intel Core i5-7300U CPU 2.60GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.200
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT


```
|            Method |       Mean |     Error |     StdDev |
|------------------ |-----------:|----------:|-----------:|
|      GetFromArray | 146.672 μs | 5.5711 μs | 16.4265 μs |
| GetFromDictionary |   9.851 μs | 0.6856 μs |  1.7821 μs |
|     GetFromLookup |   1.455 μs | 0.1810 μs |  0.5337 μs |

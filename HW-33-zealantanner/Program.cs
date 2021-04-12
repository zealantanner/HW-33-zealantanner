using System;
using System.Collections.Generic;

class Program
{
    private static void Print(IEnumerable<KeyValuePair<string, ConsoleColor>> items)
    {
        foreach (KeyValuePair<string, ConsoleColor> item in items)
        {
            Console.ForegroundColor = item.Value;
            Console.Write(item.Key);
            Console.ResetColor();
        }
        Console.WriteLine();
    }
    private static void BackPrint(IEnumerable<KeyValuePair<string, ConsoleColor>> items)
    {
        foreach (KeyValuePair<string, ConsoleColor> item in items)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = item.Value;
            Console.Write(item.Key);
            Console.ResetColor();
        }
        Console.WriteLine();
    }
    static void Main()
    {
        var textcolorMap = new Dictionary<string, ConsoleColor>
        {
            ["Error"] = ConsoleColor.Red,
            ["Warning"] = ConsoleColor.Yellow,
            ["Information"] = ConsoleColor.Green
        };
        textcolorMap.Add("Verbose", ConsoleColor.White);
        textcolorMap["Error"] = ConsoleColor.Cyan;

        BackPrint(textcolorMap);
        Print(textcolorMap);
    }
}

interface IPair<T>
{
    T First { get; }
    T Second { get; }
    T this[PairItem index] { get; }
}

public enum PairItem
{ First, Second }
public struct Pair<T> : IPair<T>
{
    public Pair(T first, T second)
    {
        First = first;
        Second = second;
    }
    public T First { get; }
    public T Second { get; }
    public T this[PairItem index]
    {
        get
        {
            switch (index)
            {
                case PairItem.First: return First;
                case PairItem.Second: return Second;
                default: throw new NotImplementedException($"The enum {index.ToString() }has not been implemented");
            }
        }
    }
}

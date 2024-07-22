using System;
using System.Collections.Generic;

namespace ONP_konwerter;

public class EqualitionReader
{
    public void ReadEquation(List<string> output)
    {
        Console.WriteLine("Final: ");
        foreach (var item in output)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }
}
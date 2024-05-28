using System;
using System.Collections.Generic;

namespace ONP_konwerter
{
    internal static class Program
    {
        private static string _op;
        private static Dictionary<char, int> _marksPriorities= new();

        static List<String> _outPut = new List<string>();
        static List<char> _operators = new List<char>();

        public static void Main(string[] args)
        {
            DefineDict();
            Console.WriteLine("Wprowadź działanie");
            _op = Console.ReadLine();

            ODP(_op);
        }

        
        private static void ODP(string operation)
        {
            SplitSigns(operation);
            PlaceSignsForOdp();
        }

        private static void PlaceSignsForOdp()
        {
            Console.WriteLine("Numbers:");
            foreach (var item in _outPut)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Operators:");
            foreach (var op in _operators)
            {
                Console.WriteLine(op);
            }
        }

        private static void SplitSigns(string operation)
        {
                
            char lastValue = '\0';
            string num = null;

            for (int i = 0; i < operation.Length; i++) 
            {
                char sign = operation[i];

                if (_marksPriorities.ContainsKey(sign))
                {
                    if (!_marksPriorities.ContainsKey(lastValue))
                    {
                        _outPut.Add(num);
                        // Console.WriteLine(num);
                        num = string.Empty;
                    }
                    _operators.Add(sign);
                    // Console.WriteLine($"{sign}({_marksPriorities[sign]})");
                }
                else
                {
                    num += sign;
                    if (i == operation.Length- 1)
                    {
                        _outPut.Add(num);
                        // Console.WriteLine(num);
                    }
                }
                lastValue = sign;
            }
    
        }

        private static void DefineDict()
        {
            _marksPriorities.Add('-', 1);
            _marksPriorities.Add('+', 1);
            _marksPriorities.Add('*', 2);
            _marksPriorities.Add('/', 2);
            _marksPriorities.Add('[', 3);
            _marksPriorities.Add(']', 3);
            _marksPriorities.Add('(', 4);
            _marksPriorities.Add(')', 4);
        }
    }
    
}
using System;
using System.Collections.Generic;

namespace ONP_konwerter
{
    internal static class Program
    {
        private static string _op;
        private static Dictionary<char, int> _marksPriorities = new();

        static List<string> _ingridients = new List<string>();
        static List<char> _operators = new List<char>();
        static List<string> _operation = new List<string>();
        static List<string> _output = new List<string>();

        public static void Main(string[] args)
        {
            DefineDict();
            Console.WriteLine("Wprowadź działanie");
            _op = Console.ReadLine();

            ODP(_op);
        }

        private static void ODP(string operation)
        {
            _ingridients.Clear();
            _operators.Clear();
            _operation.Clear();
            _output.Clear();
            
            SplitSigns(operation);
            PlaceSignsForOdp();
        }

        private static void PlaceSignsForOdp()
        {
            for (int i = 0; i < _ingridients.Count; i++)
            {
                _output.Add(_ingridients[i]);
            }

            for (int i = _operators.Count - 1; i >= 0; i--)
            {
                if (_operators[i] != ')' && _operators[i] != '(' && _operators[i] != ']' && _operators[i] != '[')
                {
                    _output.Add(_operators[i].ToString());
                }
            }

            Console.WriteLine("Final:");
            foreach (var item in _output)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine(); // For better formatting
        }

        private static void SplitSigns(string op)
        {
            char lastValue = '\0';
            string num = string.Empty;

            for (int i = 0; i < op.Length; i++)
            {
                char sign = op[i];

                if (_marksPriorities.ContainsKey(sign))
                {
                    if (!_marksPriorities.ContainsKey(lastValue))
                    {
                        _ingridients.Add(num);
                        _operation.Add(num);
                        num = string.Empty;
                    }
                    _operators.Add(sign);
                    _operation.Add(sign.ToString());
                }
                else
                {
                    num += sign;
                    if (i == op.Length - 1)
                    {
                        _ingridients.Add(num);
                        _operation.Add(num);
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

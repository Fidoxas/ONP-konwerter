using System;
using System.Collections.Generic;

namespace ONP_konwerter
{
    internal static class Program
    {
        private static string _op;
        private static Dictionary<char, int> _marksPriorities = new Dictionary<char, int>();
        static Stack<char> _operators = new Stack<char>();
        static List<string> _output = new List<string>();

        public static void Main(string[] args)
        {
            Prepare();
            ReadEquation();
           
        }

        private static void Prepare()
        {
            DefineDict();
            Console.WriteLine("insert value:");
            _op = Console.ReadLine();
        }

        private static void ReadEquation()
        {
            bool readable = true;
            foreach (var sign in _op)
            {
                if (!char.IsDigit(sign) && !_marksPriorities.ContainsKey(sign))
                {
                    readable = false;
                }
            }
            if (readable)
            {
                ODP(_op);
                
                Console.WriteLine("Final:");
                foreach (var item in _output)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine(); 
            }
            else
            {
                Console.WriteLine("i can't use those values.You could use only digits and operators:");
                foreach (var op in _marksPriorities)
                {
                    Console.Write(op.Key + " ");
                }
            }
        }

        private static void ODP(string operation)
        {
            _output.Clear();
            PrerpareOperation(operation);
        }

        private static void PrerpareOperation(string operation)
        {
            string num = string.Empty;

            for (int i = 0; i < operation.Length; i++)
            {
                char sign = operation[i];

                if (_marksPriorities.ContainsKey(sign))
                {
                    if (!string.IsNullOrEmpty(num))
                    {
                        _output.Add(num);
                        num = string.Empty;
                    }

                    HandleOperator(sign);
                }
                else
                {
                    num += sign;
                    if (i == operation.Length - 1)
                    {
                        _output.Add(num);
                    }
                }

            }

            while (_operators.Count > 0)
            {
                _output.Add(_operators.Pop().ToString());
            }
        }

        private static void HandleOperator(char op)
        {
            if (op == '(' || op == '[')
            {
                _operators.Push(op);
            }
            else if (op == ')'|| op == ']')
            {
                while (_operators.Peek() != '(' &&  _operators.Peek() != '[')
                {
                    _output.Add(_operators.Pop().ToString());
                }
                _operators.Pop(); 
            }
            else
            {
                while (_operators.Count > 0 && _marksPriorities[_operators.Peek()] >= _marksPriorities[op])
                {
                    _output.Add(_operators.Peek().ToString());
                    _operators.Pop();
                }
                Console.WriteLine("dodano operator: " + op);
                _operators.Push(op);
            }
        }

        private static void DefineDict()
        {
            _marksPriorities.Add('-', 1);
            _marksPriorities.Add('+', 1);
            _marksPriorities.Add('*', 2);
            _marksPriorities.Add('/', 2);
            _marksPriorities.Add('(', 0); 
            _marksPriorities.Add(')', 0);
            _marksPriorities.Add(']', 0);
            _marksPriorities.Add('[', 0);
        }
    }
}

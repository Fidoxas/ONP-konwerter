using System;
using System.Collections.Generic;

namespace ONP_konwerter.Scripts
{
    public class InputChecker
    {
        private Dictionary<char, int> _dict = EqualitionDefiner.MarksPriorities;
        private string op = InputReader.Op;

        public bool AccetableOperation()
        {
            if (string.IsNullOrEmpty(op))
            {
                return false;
            }
            foreach (var sign in op)
            {
                if (!isAcceptable(sign))
                {
                    return false;
                }
            }

            return true;
        }

        private bool isAcceptable(char a)
        {
            return _dict.ContainsKey(a) || char.IsDigit(a);
        }

        public void PrintAllowedOperators()
        {
            Console.WriteLine("You need to use only digits or one of these operators: ");
            foreach (var op in _dict)
            {
                Console.Write(op.Key + " ");
            }
            Console.WriteLine();
        }
    }
}
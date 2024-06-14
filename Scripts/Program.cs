using System;
using System.Collections.Generic;
using ONP_konwerter.Properties;
using ONP_konwerter.Scripts;

namespace ONP_konwerter
{
    internal static class Program
    {
        private static string Op;
        private static List<string> _output;

        private static void Main(string[] args)
        {
            InputReader inputReader = new InputReader();
            EqualitionDefiner definer = new EqualitionDefiner();
            InputChecker inputChecker = new InputChecker();
            Converter converter = new Converter();
            EqualitionReader er = new EqualitionReader();

            definer.DefineDict();
            Op = inputReader.TakeOp();
            Console.WriteLine("your operation "+ Op);

            if (inputChecker.AccetableOperation(Op))
            {
                _output = converter.PrerpareOperation(Op);
                er.ReadEquation(_output);
            }
            else
            {
                inputChecker.PrintAllowedOperators();
            }
        }
    }
}

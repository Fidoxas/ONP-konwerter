using System;
using System.Collections.Generic;
using ONP_konwerter.Properties;
using ONP_konwerter.Scripts;

namespace ONP_konwerter
{
    internal static class Program
    {

        private static void Main(string[] args)
        {
            InputReader inputReader = new InputReader();
            EqualitionDefiner definer = new EqualitionDefiner();
            InputChecker inputChecker = new InputChecker();
            Converter converter = new Converter();
            EqualitionReader er = new EqualitionReader();

            definer.DefineDict();
            var op = inputReader.TakeOp();
            Console.WriteLine("your operation "+ op);

            if (inputChecker.AccetableOperation(op))
            {
                var output = converter.PrerpareOperation(op);
                er.ReadEquation(output);
            }
            else
            {
                inputChecker.PrintAllowedOperators();
            }
        }
    }
}

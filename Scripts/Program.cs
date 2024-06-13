using System;
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
            inputReader.TakeOp();
            Console.WriteLine("your operation "+ inputReader.Op);

            if (inputChecker.AccetableOperation(inputReader.Op))
            {
                converter.PrerpareOperation(inputReader.Op);
                er.ReadEquation(converter.Output);
            }
            else
            {
                inputChecker.PrintAllowedOperators();
            }
        }
    }
}

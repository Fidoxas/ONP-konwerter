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

            inputReader.TakeOp();
            definer.DefineDict();

            if (inputChecker.AccetableOperation())
            {
                converter.PrerpareOperation();
                er.ReadEquation(converter.Output);
            }
            else
            {
                inputChecker.PrintAllowedOperators();
            }
        }
    }
}

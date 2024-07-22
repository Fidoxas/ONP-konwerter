using ONP_konwerter;
using ONP_konwerter.Scripts;

var inputReader = new InputReader();
var definer = new EqualitionDefiner();
var inputChecker = new InputChecker();
var converter = new Converter();
var er = new EqualitionReader();

definer.DefineDict();
var op = inputReader.TakeOp();
Console.WriteLine("your operation " + op);

if (inputChecker.AccetableOperation(op))
{
    var output = converter.PrerpareOperation(op);
    er.ReadEquation(output);
}
else
{
    inputChecker.PrintAllowedOperators();
}
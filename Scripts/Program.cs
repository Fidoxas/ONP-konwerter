using System;
using ONP_konwerter;
using ONP_konwerter.Scripts;

var inputReader = new InputReader();
var inputChecker = new InputChecker();
var converter = new Converter();
var er = new EqualitionReader();

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
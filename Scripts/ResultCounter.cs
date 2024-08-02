using System;
using System.Collections.Generic;
using System.Linq;

namespace ONP_konwerter;

public class ResultCounter
{
    public static string ResultOnpDefiner(List<String> OnpEq)
    {
        List<String> Output = new List<string>(OnpEq);;
        while (Output.Count > 1)
        {
            for (int i = 0; i < Output.Count; i++)
            {
                if (EqualitionDefiner.MarksPriorities.ContainsKey(Output[i].First()))
                {
                    string result = CalculateResult(Output.GetRange(i - 2, 3));
                    Output.RemoveRange(i - 2, 3);
                    Output.Insert(i - 2, result);
                    break;
                }
            }
        }
        return Output.First();
    }

    static string CalculateResult(List<String> operation)
    {
        int operand1 = int.Parse(operation[0]);
        int operand2 = int.Parse(operation[1]);
        char operatorChar = operation[2].First();
        
        int result = operatorChar switch
        {
            '+' => operand1 + operand2,
            '-' => operand1 - operand2,
            '*' => operand1 * operand2,
            '/' => operand1 / operand2,
            _ => throw new InvalidOperationException("Niepoprawny operator")
        };

        return result.ToString();
    }
}
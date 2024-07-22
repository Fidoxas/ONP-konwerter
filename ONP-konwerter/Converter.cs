using System;
using System.Collections.Generic;

namespace ONP_konwerter;

public class Converter
{
    private Stack<char> _operators = new Stack<char>();
    private List<string> _output = new List<string>();
    private Dictionary<char, int> _mp = EqualitionDefiner.MarksPriorities;

    public List<string> Output => _output;

    public List<string> PrerpareOperation(string operation)
    {
        string num = string.Empty;

        for (int i = 0; i < operation.Length; i++)
        {
            char sign = operation[i];

            if (_mp.ContainsKey(sign))
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

        return _output;
    }

    private void HandleOperator(char op)
    {
        if (op == '(' || op == '[')
        {
            _operators.Push(op);
        }
        else if (op == ')' || op == ']')
        {
            while (_operators.Peek() != '(' && _operators.Peek() != '[')
            {
                _output.Add(_operators.Pop().ToString());
            }

            _operators.Pop();
        }
        else
        {
            while (_operators.Count > 0 && _mp[_operators.Peek()] >= _mp[op])
            {
                _output.Add(_operators.Pop().ToString());
            }

            Console.WriteLine("Added operator: " + op);
            _operators.Push(op);
        }
    }
}
namespace ONP_konwerter;

public class InputChecker
{
    private Dictionary<char, int> _dict = EqualitionDefiner.MarksPriorities;

    public bool AccetableOperation(string operation)
    {
        if (string.IsNullOrEmpty(operation))
        {
            return false;
        }

        foreach (var sign in operation)
        {
            if (!IsAcceptable(sign))
            {
                return false;
            }
        }

        return true;
    }

    private bool IsAcceptable(char a)
    {
        if (_dict.ContainsKey(a))
        {
            return true;
        }
        else if (char.IsDigit(a))
        {
            return true;
        }
        else
        {
            Console.WriteLine("I Dont understand " + a);
            return false;
        }
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
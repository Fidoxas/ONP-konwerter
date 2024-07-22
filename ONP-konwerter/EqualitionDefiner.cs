using System.Collections.Generic;

namespace ONP_konwerter;

public class EqualitionDefiner
{
    public static Dictionary<char, int> MarksPriorities { get; private set; } = new Dictionary<char, int>();

    public void DefineDict()
    {
        MarksPriorities.Clear(); // Ensure dictionary is empty before adding
        MarksPriorities.Add('-', 1);
        MarksPriorities.Add('+', 1);
        MarksPriorities.Add('*', 2);
        MarksPriorities.Add('/', 2);
        MarksPriorities.Add('(', 0);
        MarksPriorities.Add(')', 0);
        MarksPriorities.Add(']', 0);
        MarksPriorities.Add('[', 0);
    }
}
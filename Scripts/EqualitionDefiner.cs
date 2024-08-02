using System.Collections.Generic;

namespace ONP_konwerter;

public class EqualitionDefiner
{
    public static Dictionary<char, int> MarksPriorities { get; private set; } = new Dictionary<char, int>()
    {
        {'-', 1}, 
        {'+', 1}, 
        {'*', 2}, 
        {'/', 2}, 
        {'(', 0}, 
        {')', 0}, 
        {'[', 0}, 
        {']', 0}, 
    };
}
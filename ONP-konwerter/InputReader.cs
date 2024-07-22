namespace ONP_konwerter;

public class InputReader
{
    private string Op;

    public string TakeOp()
    {
        Console.WriteLine("Insert value:");
        Op = Console.ReadLine();
        return Op;
    }
}
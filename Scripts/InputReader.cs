using System;

namespace ONP_konwerter
{
    public class InputReader
    {
        public string Op { get; private set; }

        public void TakeOp()
        {
            Console.WriteLine("Insert value:");
            Op = Console.ReadLine();
        }
    }
}
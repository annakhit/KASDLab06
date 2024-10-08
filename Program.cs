using System;

namespace KASDLab06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyVector<int> vector = new MyVector<int>();

            vector.AddAll(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            vector.Print();

            vector.RemoveRange(0, 5);

            vector.Print();

            Console.ReadKey();
        }
    }
}

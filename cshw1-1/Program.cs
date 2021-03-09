using System;

namespace cshw1_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var a = Convert.ToDouble(Console.ReadLine());
            var o = Console.ReadLine();
            var b = Convert.ToDouble(Console.ReadLine());
            double c;
            switch (o)
            {
                case "+":
                    c = a + b;
                    break;
                case "-":
                    c = a - b;
                    break;
                case "*":
                    c = a * b;
                    break;
                case "/":
                    c = a / b;
                    break;
                default:
                    Console.WriteLine("invalid");
                    return;
            }
            Console.WriteLine(c);
        }
    }
}
namespace Stage0
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome4911();
            Welcome1005();
            Console.ReadKey();
        }
        static partial void Welcome1005();
        private static void Welcome4911()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("{0} , welcome to my first console application", name);
        }
    }
}
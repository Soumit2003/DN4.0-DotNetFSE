namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger logger1 = Logger.Instance;
            Logger logger2 = Logger.Instance;

            if (ReferenceEquals(logger1, logger2))
            {
                Console.WriteLine("Singleton is successful");
            }
            else
            {
                Console.WriteLine("Singleton is unsuccessful!");
            }

        }
    }
}
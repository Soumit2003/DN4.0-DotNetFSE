class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("1. Producer\n2. Consumer");
        var choice = Console.ReadLine();

        if (choice == "1")
        {
            var p = new Producer();
            await p.RunAsync();
        }
        else if (choice == "2")
        {
            var c = new Consumer();
            c.Run();
        }
    }
}

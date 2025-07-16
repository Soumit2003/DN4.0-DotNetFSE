namespace E_commerce_Platform_Search_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] product = new Product[]
            {
                new Product(101,"Toothbrush","Personal Care"),
                new Product(102, "Soap", "Personal Care"),
                new Product(103, "Toothpaste", "Personal Care"),
                new Product(104, "Shampoo", "Hair Care"),
                new Product(105, "Bread", "Grocery")
            };
            string target = Console.ReadLine()??"Soap";
            string found1 = SearchOperation.linearSearch(product,target);
            Array.Sort(product, (a, b) => a.productName.CompareTo(b.productName));
            string found2 = SearchOperation.binearSearch(product,target);

            Console.WriteLine(found1==target? "Found": "Not Found");
            Console.WriteLine(found2 == target ? "Found" : "Not Found");
        }
    }
}
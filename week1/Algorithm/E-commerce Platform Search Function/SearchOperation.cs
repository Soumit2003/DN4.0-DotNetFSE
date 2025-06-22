using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Platform_Search_Function
{
    internal class SearchOperation
    {
        public static string linearSearch(Product[] products, string target) 
        {
            int count = 0;
            foreach(var product in products)
            {
                count += 1;
                if (product.productName == target)
                {
                    Console.WriteLine($"No of iteration takes for linear Search: {count}");
                    return product.productName;
                }
            }
            return null;
        }
        public static string binearSearch(Product[] products, string target)
        {
            int low = 0, high = products.Length - 1 , count=0;

            while (low <= high)
            {
                count += 1;
                int mid = (low + high) / 2;
                int comparison = string.Compare(products[mid].productName, target, true);

                if (comparison == 0)
                {
                    Console.WriteLine($"No of iteration takes for binear Search: {count}");
                    return products[mid].productName; 
                }
                else if (comparison < 0) low = mid + 1;
                else high = mid - 1;
            }

            return null;
        }
    }
}


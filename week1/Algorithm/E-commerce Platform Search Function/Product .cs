using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Platform_Search_Function
{
    public class Product
    {
        public int productId;
        public string productName;
        public string category;
        public Product(int Id,string Name,string Category )
        {
            productId = Id;
            productName = Name;
            category = Category;
        }
    }
}

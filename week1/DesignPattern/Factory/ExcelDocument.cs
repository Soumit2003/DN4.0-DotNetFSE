using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPatternExample
{
    internal class ExcelDocument :IDocument
    {
        public void open() 
        {
            Console.WriteLine("Excel Document opened");
        }
    }
}

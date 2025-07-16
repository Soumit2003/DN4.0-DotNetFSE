namespace FactoryMethodPatternExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which document do you want to open? (word/pdf/excel)");
            string input = Console.ReadLine()??"word";

            DocumentFactory factory = input switch
            {
                "word" => new WordDocumentFactory(),
                "pdf" => new PdfDocumentFactory(),
                "excel" => new ExcelDocumentFactory(),
                _ => new WordDocumentFactory()
            };

            if (factory == null)
            {
                Console.WriteLine("Invalid document type.");
                return;
            }

            IDocument document = factory.CreateDocument();
            document.open();

        }
    }
}
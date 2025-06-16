public class Main {
    public static void main(String[] args) {
        DocumentFactory factory = new DocumentFactory();

        Document doc1 = factory.createDocument("pdf");
        Document doc2 = factory.createDocument("word");

        doc1.open();
        doc2.open();
    }
}

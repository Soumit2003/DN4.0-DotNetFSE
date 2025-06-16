public class DocumentFactory {
    public Document createDocument(String type) {
        if (type.equalsIgnoreCase("pdf")) {
            return new PdfDocument();
        } else if (type.equalsIgnoreCase("word")) {
            return new WordDocument();
        } else {
            throw new IllegalArgumentException("Unknown document type");
        }
    }
}

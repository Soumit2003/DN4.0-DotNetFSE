public class Main {
    public static void main(String[] args) {
        Image img1 = new ProxyImage("design-patterns.png");

        // Image is not loaded yet
        System.out.println("First call:");
        img1.display(); // loads and displays

        System.out.println("\nSecond call:");
        img1.display(); // displays only, no reload
    }
}

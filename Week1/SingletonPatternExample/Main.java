public class Main {
    public static void main(String[] args) {
        Logger logger1 = Logger.getInstance();
        Logger logger2 = Logger.getInstance();

        logger1.log("Starting app...");
        logger2.log("Still logging...");

        if (logger1 == logger2) {
            System.out.println("Singleton works! Only one instance.");
        } else {
            System.out.println("Singleton failed! Different instances.");
        }
    }
}

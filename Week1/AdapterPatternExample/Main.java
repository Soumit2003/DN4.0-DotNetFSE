public class Main {
    public static void main(String[] args) {
        PaymentProcessor paypal = new PayPalAdapter();
        paypal.processPayment(2500.00);

        PaymentProcessor stripe = new StripeAdapter();
        stripe.processPayment(1800.00);
    }
}

public class PayPalAdapter implements PaymentProcessor {
    private PayPalGateway gateway = new PayPalGateway();

    @Override
    public void processPayment(double amount) {
        gateway.sendPayment(amount);
    }
}

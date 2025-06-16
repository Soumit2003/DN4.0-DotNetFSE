public class Main {
    public static void main(String[] args) {
        PaymentContext context = new PaymentContext();

        context.setStrategy(new CreditCardPayment());
        context.payBill(1250.00);

        context.setStrategy(new PayPalPayment());
        context.payBill(800.00);
    }
}

public class PaymentContext {
    private PaymentStrategy strategy;

    public void setStrategy(PaymentStrategy strategy) {
        this.strategy = strategy;
    }

    public void payBill(double amount) {
        if (strategy == null) {
            throw new IllegalStateException("Payment method not set!");
        }
        strategy.pay(amount);
    }
}

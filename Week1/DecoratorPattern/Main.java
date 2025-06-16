public class Main {
    public static void main(String[] args) {
        Notifier notifier = new EmailNotifier(); // base
        notifier = new SMSNotifier(notifier);    // add SMS
        notifier = new SlackNotifier(notifier);  // add Slack

        notifier.send("Server down alert!");
    }
}

public class Main {
    public static void main(String[] args) {
        StockMarket market = new StockMarket();
        Observer mobile = new MobileApp();
        Observer web = new WebApp();

        market.register(mobile);
        market.register(web);

        market.setStockPrice("CompanyA", 3510.75);
        market.setStockPrice("CompanyB", 1420.50);
    }
}

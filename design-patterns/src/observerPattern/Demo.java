package observerPattern;

public class Demo {

	public static void main(String[] args) {
		
		Stock s1 = new Stock("Tesla", 10);
		Stock s2 = new Stock("Apple", 20);
		
		Broker b1 = new Broker("Broker 1");
		Broker b2 = new Broker("Broker 2");
		
		StockExchange se = new StockExchange();
		System.out.println("*****Adding brokers to stock exchange*****");
		se.addObserver(b1);
		se.addObserver(b2);
		
		System.out.println("*****Adding stocks to stock exchange*****"); //all observers will be notified of the addition of these stocks
		se.addStock(s1); 
		se.addStock(s2);
		
		System.out.println("*****Removing a stock from the stock exchange*****"); //all observers will be notified of the removal of this stock
		se.removeStock(s1);
		
	
		
	}

}

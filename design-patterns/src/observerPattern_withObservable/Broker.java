package observerPattern_withObservable;

public class Broker implements Observer{
	
	String name;
		
	public Broker(String name) {
		this.name = name;
	}
	
	

	public void getNotified(Event e, Stock s) {
		switch(e) {
		case ADDED: System.out.println("New stock added!"); s.display(); break;
		// display the new stock
		// view options to buy
		// suggest a strategy to sell in the future
		case DELETED: System.out.println("A stock was removed!"); s.display(); break;
		case UPDATED: System.out.println("A stock was updated!"); s.display(); break;
		// Display the new price vs the old price
		// Calculate profit or loss
		// use AI to predict whether to sell or not 
		}
	}
	
}

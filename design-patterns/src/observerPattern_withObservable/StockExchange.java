package observerPattern_withObservable;

import java.util.ArrayList;

public class StockExchange implements Observable{

	ArrayList<Observer> observers;
	ArrayList<Stock> stocks;
	
	public StockExchange() {
		this.observers = new ArrayList<Observer>();
		this.stocks = new ArrayList<Stock>();
	}

	public void addObserver(Observer o) {
		this.observers.add(o);
		System.out.println("Observer added! ");
	}
	
	public void notifyObservers(Event e, Stock s) {
		for(Observer o: observers)
			o.getNotified(e, s);
	}
	
	public void addStock(Stock s) {
		stocks.add(s);
		notifyObservers(Event.ADDED,s);
	}


	public void updateStock(Stock oldStock, Stock newStock) {
		int indexOfStock = stocks.indexOf(oldStock);
		stocks.add(indexOfStock, newStock);
		notifyObservers(Event.UPDATED,newStock);
	}

	
	public void removeStock(Stock s) {
		stocks.remove(s);
		notifyObservers(Event.DELETED,s);
	}
	
	public ArrayList<Stock> getStocks() {
		return this.stocks;
	}


}

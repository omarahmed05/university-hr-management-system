package observerPattern;

import java.util.ArrayList;

public class StockExchange implements Subject {

	// where all observers are added/removed and all stocks are added/removed

	ArrayList<Observer> observers;
	ArrayList<Stock> stocks;
	
	public StockExchange() {
		this.observers = new ArrayList<Observer>();
		this.stocks = new ArrayList<Stock>();
	}
	
	public void addObserver(Observer o) {
		this.observers.add(o);
	}
	
	public void addStock(Stock s) {
		stocks.add(s);
		this.notifyObservers(s);
	}

	public void updateStock(Stock oldStock, Stock newStock) {
		int indexOfStock = stocks.indexOf(oldStock);
		stocks.add(indexOfStock, newStock);
		this.notifyObservers(newStock);
	}
	
	public void removeStock(Stock s) {
		stocks.remove(s);
		this.notifyObservers(s);
	}
	
	public ArrayList<Stock> getStocks() {
		return this.stocks;
	}

	public void notifyObservers(Stock s) {
		for(Observer o: this.observers)
			o.getNotified(s);
		
	}
	
	

}

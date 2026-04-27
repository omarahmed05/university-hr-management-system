package observerPattern_withObservable;

public class Stock {
	
	String name;
	int price;
	
	public Stock(String name, int price) {
		this.name = name;
		this.price = price;
	}
	
	public void setName(String newName) {
		this.name = newName;
	}
	public String getName() {
		return this.name;
	}
	public void setPrice(int newPrice) {
		this.price = newPrice;
	}
	public int getPrice() {
		return this.price;
	}
	
	public void display() {
		System.out.println("Stock " +this.name + " priced at " + this.price);
	}

}

package observerPattern;

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
	
	public String display() {
		return this.name + " priced at " + this.price;
	}

}

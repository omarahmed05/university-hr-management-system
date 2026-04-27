package decorator;

public abstract class Beverage {

	String description;
	int cost;
	
	public abstract String getDescription();
	public abstract int getCost();
	public void display() {
		System.out.println(this.getDescription() + " and it costs " + this.getCost());
	}
	


}

package decorator;

public class RegularMilk extends Decorator {

	public RegularMilk(Beverage toBeDecorated) {
		this.toBeDecorated = toBeDecorated;
	}
	
	public String getDescription() {
		return toBeDecorated.getDescription() + " with Regular Milk";
	}

	public int getCost() {
		return toBeDecorated.getCost() + 5;
	}

}

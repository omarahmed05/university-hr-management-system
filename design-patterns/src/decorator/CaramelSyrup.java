package decorator;

public class CaramelSyrup extends Decorator {

	public CaramelSyrup(Beverage toBeDecorated) {
		this.toBeDecorated = toBeDecorated;
	}
	
	public String getDescription() {
		return toBeDecorated.getDescription() + " with Caramel Syrup";
	}

	public int getCost() {
		return toBeDecorated.getCost() + 10;
	}

}

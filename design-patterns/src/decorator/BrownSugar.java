package decorator;

public class BrownSugar extends Decorator {

	public BrownSugar(Beverage toBeDecorated) {
		this.toBeDecorated = toBeDecorated;
	}
	
	public String getDescription() {
		return toBeDecorated.getDescription() + " with Brown Sugar";
	}

	public int getCost() {
		return toBeDecorated.getCost() + 3;
	}

}

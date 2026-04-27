package decorator;

public class ExtraDarkShot extends Decorator {

	public ExtraDarkShot(Beverage toBeDecorated) {
		this.toBeDecorated = toBeDecorated;
	}
	
	public String getDescription() {
		return toBeDecorated.getDescription() + " with Extra Dark Shot";
	}

	public int getCost() {
		return toBeDecorated.getCost() + 30;
	}

}

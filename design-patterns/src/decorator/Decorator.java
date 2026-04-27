package decorator;

public abstract class Decorator extends Beverage {
	
	Beverage toBeDecorated;
	
	public abstract String getDescription();
	public abstract int getCost();

}

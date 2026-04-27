package decorator;

public class Demo {

	public static void main(String[] args) {
		// Normal dark roast
		Beverage firstOrder = new DarkRoast();
		// Espresso with regular milk
		Beverage secondOrder = new RegularMilk(new Espresso());
		// triple shot dark roast with milk, double caramel shots and 2 brown sugars
		Beverage thirdOrder = new DarkRoast();
		thirdOrder = new ExtraDarkShot(thirdOrder);
		thirdOrder = new ExtraDarkShot(thirdOrder);
		thirdOrder = new RegularMilk(thirdOrder);
		thirdOrder = new CaramelSyrup(thirdOrder);
		thirdOrder = new CaramelSyrup(thirdOrder);
		thirdOrder = new BrownSugar(thirdOrder);
		thirdOrder = new BrownSugar(thirdOrder);
		
		System.out.println("*********First Order*********");
		firstOrder.display();
		System.out.println("*********Second Order********");
		secondOrder.display();
		System.out.println("*********Third Order*********");
		thirdOrder.display();
		
	}
	
}

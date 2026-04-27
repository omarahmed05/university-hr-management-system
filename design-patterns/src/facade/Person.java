package facade;

public class Person {
		
	HomeFacade home;
	
	public Person (){
		this.home = new HomeFacade(new Bathroom(), new Bedroom(), new Microwave(), new CoffeeMachine(), new Car());
	}

	public void wakeup() {
		System.out.println("Waking up");
	}
	
	public void brushTeeth() {
		System.out.println("Brushing teeth");
	}
	
	public void putOnClothes() {
		System.out.println("Putting on clothes");
	}
	
	public void takeOffClothes() {
		System.out.println("Taking off clothes");
	}	
	
	public void goToWork() {
		this.wakeup();
		home.takeShower();
		this.brushTeeth();
		home.haveBreakfast();
		home.goToWork();
	}
	
	public void goHomeAndSleep() {
		System.out.println("Getting ready to go back home");
		home.goToHome();
		home.haveDinner();
		home.takeShower();
		this.brushTeeth();
		home.readyToSleep();
		System.out.println("Currently sleeping");
		System.out.println("--------------");
	}
	
}

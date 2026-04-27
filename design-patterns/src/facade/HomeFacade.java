package facade;

public class HomeFacade {
	
	Bathroom bathroom;
	Bedroom bedroom;
	Microwave microwave;
	CoffeeMachine coffeeMachine;
	Car car;
	
	public HomeFacade(Bathroom bathroom, Bedroom bedroom, Microwave microwave, CoffeeMachine coffeeMachine, Car car) {
		this.bathroom = bathroom;
		this.bedroom = bedroom;
		this.microwave = microwave;
		this.coffeeMachine = coffeeMachine;
		this.car = car;
	}
	
	
	public void takeShower() {
		bathroom.showerOn();
		bathroom.adjustShowerTemperature();
		bathroom.showerOff();
	}
	
	public void haveBreakfast() {
		coffeeMachine.putCoffeeBeans();
		coffeeMachine.turnOn();
		microwave.open();
		microwave.putFood();
		microwave.cookFood();
		microwave.takeFood();
	}
	
	public void haveDinner() {
		microwave.open();
		microwave.putFood();
		microwave.cookFood();
		microwave.takeFood();
	}
	
	public void goToWork() {
		car.openDoor();
		car.startEnginer();
		car.setNavigationToWork();
	}
	
	public void goToHome() {
		car.openDoor();
		car.startEnginer();
		car.setNavigationToHome();
	}
	
	public void readyToSleep() {
		bedroom.turnLightsOff();
		bedroom.closeCurtains();
		bedroom.turnOnAC();
	}
		

}

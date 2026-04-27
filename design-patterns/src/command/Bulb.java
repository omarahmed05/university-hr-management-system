package command;

public class Bulb {
	
	String name;
	
	public Bulb(String name) {
		this.name = name;
	}
	
	public void lightsOn() {
		System.out.println("light of bulb " + this.name + " is on!");
	}
	
	public void lightsOff() {
		System.out.println("light of bulb " + this.name + " is off!");
	}

}

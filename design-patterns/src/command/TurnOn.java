package command;

public class TurnOn implements Command {

	Bulb bulb;
	
	public TurnOn(Bulb b) {
		this.bulb = b;
	}
	
	public void execute() {
		this.bulb.lightsOn();
	}

}

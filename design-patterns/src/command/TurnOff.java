package command;

public class TurnOff implements Command {

	Bulb bulb;
	
	public TurnOff(Bulb b) {
		this.bulb = b;
	}
	
	public void execute() {
		this.bulb.lightsOff();
	}

}

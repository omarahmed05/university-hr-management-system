package command;

public class Demo {

	public static void main(String[] args) {
		Bulb b = new Bulb("Single bulb");
		Radio r = new Radio("Vintage Radio");
		
		Command turnOnLight = new TurnOn(b);
		Command turnOffLight = new TurnOff(b);
		Command turnUp = new VolumeUp(r);
		Command turnDown = new VolumeDown(r);
		
		RemoteController rc = new RemoteController();

		System.out.println("*****Light Commands*****");
		rc.setFirstButton(turnOnLight); //set first command on the remote controller to turn on the bulb
		rc.setSecondButton(turnOffLight); //set second command on the remote controller to turn off the bulb
		
		rc.pressFirstButton(); //execute the first command
		rc.pressSecondButton(); //execute the second command
		
		System.out.println("*****Radio Commands*****");
		rc.setThirdButton(turnUp); //set third command on the remote controller to turn up the radio
		rc.setFourthButton(turnDown); //set fourth command on the remote controller to turn down the radio
		
		rc.pressThirdButton();
		rc.pressFourthButton();
	}
}

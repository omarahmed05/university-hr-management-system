package command;

public class RemoteController {
	
	Command c1;
	Command c2;
	Command c3;
	Command c4;
	
	//set the commands called bu the buttons
	public void setFirstButton(Command c) {
		this.c1 = c;
	}
	
	public void setSecondButton(Command c) {
		this.c2 = c;
	}

	public void setThirdButton(Command c) {
		this.c3 = c;
	}

	public void setFourthButton(Command c) {
		this.c4 = c;
	}
	
	//execute the commands called by the buttons
	public void pressFirstButton() {
		this.c1.execute();
	}
	
	public void pressSecondButton() {
		this.c2.execute();
	}

	public void pressThirdButton() {
		this.c3.execute();
	}
	
	public void pressFourthButton() {
		this.c4.execute();
	}
}

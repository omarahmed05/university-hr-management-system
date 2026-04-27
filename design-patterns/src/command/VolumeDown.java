package command;

public class VolumeDown implements Command {

	Radio radio;
	
	public VolumeDown(Radio r) {
		this.radio = r;
	}
	
	public void execute() {
		this.radio.decreaseVolume();
	}

}
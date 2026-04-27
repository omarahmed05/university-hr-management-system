package command;

public class VolumeUp implements Command {

	Radio radio;
	
	public VolumeUp(Radio r) {
		this.radio = r;
	}
	
	public void execute() {
		this.radio.increaseVolume();
	}

}
package command;

public class Radio {

    String name;
	
	public Radio(String name) {
		this.name = name;
	}
	
	public void increaseVolume() {
		System.out.println("volume of " + this.name + " has increased!");
	}
	
	public void decreaseVolume() {
		System.out.println("volume of " + this.name + " has decreased!");
	}

}

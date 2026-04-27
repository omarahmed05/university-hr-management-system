package observerPattern;

public class Broker implements Observer {
	
	String name;

	public Broker(String name) {
		this.name = name;
	}

	public void getNotified(Stock s) {
		System.out.println(this.name + " got notified " + s.display());
		
	}
	
}


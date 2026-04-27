package adapter;

public class HotChocolateAdapter implements Coffee{

	//used to add "hot chocolate" to our system WITHOUT modifying the pre-existing code
	//makes HotChocolate compatible with Coffee
	
	HotChocolate hotchocolate;

	public HotChocolateAdapter(HotChocolate hotchocolate) {
		this.hotchocolate = hotchocolate;
	}

	public void makeCoffee() {
		hotchocolate.makeHotChocolate();
	}
	
}

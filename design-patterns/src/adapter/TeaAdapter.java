package adapter;

public class TeaAdapter implements Coffee {
	
	//used to add "tea" to our system WITHOUT modifying the pre-existing code
	//makes Tea compatible with Coffee

	Tea tea;
	
	public TeaAdapter(Tea tea) {
		this.tea = tea;
	}
	
	public void makeCoffee() {
		tea.makeTea();
		
	}

}

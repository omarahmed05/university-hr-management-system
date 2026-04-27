package adapter;
public class Demo {

	//An adapter is a wrapper class that takes an input of type A and makes it 
	//compatible (without altering its behavior) with something of type B.
	
	public static void main(String[] args) {
		
		Coffee c1 = new BrazilianCoffee(); 
		Coffee c2 = new ColombianCoffee(); 
		Barista b = new Barista();
		
		b.serveDrink(c1);
		b.serveDrink(c2);
		
		//we CANNOT typecast Tea nor HotChocolate into Coffee because this will cause an exception
		//and we CANNOT let class Tea nor class HotChocolate implement the Coffee interface because it 
		//is logically wrong
		
		Tea tea = new Tea();
		Coffee ta = new TeaAdapter(tea);
		b.serveDrink(ta);
		
		HotChocolate hotchocolate = new HotChocolate();
		Coffee hc = new HotChocolateAdapter(hotchocolate);
		b.serveDrink(hc);

	}

}

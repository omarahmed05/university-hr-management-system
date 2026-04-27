package singleton;

public class Singleton {
	
	private static Singleton instance;
	
	private Singleton() {
	}
	
	public static Singleton getInstance() {
		if (instance == null) { 
			//if no instance exists create a new instance
			instance = new Singleton();
		}
		
		return instance;
	}

	public static void main(String[] args) {
		Singleton s1 = Singleton.getInstance(); //creating the first object of type Singleton
		System.out.println(s1);
		Singleton s2 = Singleton.getInstance(); //attempting to create a new object of type Singleton
		System.out.println(s2);
		System.out.println(s1.equals(s2)); //proves that the same instance is invoked the second time - no new object is created
		
	}
	
}


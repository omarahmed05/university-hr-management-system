package facade;

public class Demo {

	Person person;
	
	public Demo(Person person) {
		this.person = person;
	}
	
	public void drawAnimationOfGoingToWork() {
		person.goToWork();
	}
	
	public void drawAnimationOfGoingHomeAndSleeping() {
		person.goHomeAndSleep();
	}
	
	public static void main(String[] args) {
	
		Person person = new Person();
		Demo animator = new Demo(person);
		System.out.println();
		System.out.println("*********Person is going to work*********");
		animator.drawAnimationOfGoingToWork();
		
		System.out.println();
		System.out.println("*********Person is going home to sleep*********");
		animator.drawAnimationOfGoingHomeAndSleeping();
	}
}

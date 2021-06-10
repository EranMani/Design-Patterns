07/06/21
feature/Observer_Pattern
* Object communication by broadcasting messages to objects who choose to listen and do something based on the message
* With the observer pattern, we can turn the object into a 'notifier' and the other items are turned into 'observers' without knowing about the existence of others.
* If any item is interseted in the state of that object, it can then become a listener that monitors messages in the environment and acts upon the ones that it is interseted in.
* This pattern decouples the code, such that you can have multiple notifiers and multiple listeners and you cann add and take away any of these without disrupting the program and requiring massive refactoring
* This should not be mixed with the game logic code!
* EVENT and EVENT LISTENER - need to have two generic scripts, one that will hold the event itself and the other will be the response for the event when occured
	* For example, there is an egg spawner in the scene and an event is needed to detect when the egg spawned and do a certain response to that event.
	* By using the UNITY EVENT library, a response invoke can be created when the event occured. The response method can pass gameobjects and other stuff.
	* Each listener response will be added to the event listener list when is enabled and will be removed from the list when it will be disabled
	* The spawner will call the occured method in the generic event script which will run in loop all the listener responses it have
	* Finally, the spawner should pass its game object prefab to the listener events to do something with it everytime it is being created
* Use cases for this pattern:
	* Update UI elements when data is changed
	* Build an achievement system that will unlock achievements when player colleceted or did certain things
	
* Delegates: 
	------------------------------------------------------------------
	* variables that can be assigned a function as a value
		exampleDelegate = MyFunction; // subscribes function to the delegate
	------------------------------------------------------------------
	------------------------------------------------------------------
	* Invoked to call functions
		exampleDelegate?.Invoke; // check if there is a subscriber, if there is we invoke
	------------------------------------------------------------------
	------------------------------------------------------------------
	* They are multicast - multiple functions assigned
		exampleDelegate += MuFunction; // add a function
		exampleDelegate -= MyFunction; // remove a function
	------------------------------------------------------------------	
	------------------------------------------------------------------
	** To define a delegate:
		public delegate void ExampleDelegate(); // defines the delegate
		public ExampleDelegate exampleDelegate; // instance of the delegate
		
		public void Start(){
			exampleDelegate = MyFunction; // subscribes function to the delegate
		}
		
		private void Update(){
			exampleDelegate?.Invoke(); // check if there is a subscriber, if there is we invoke
		}
		
		private void MyFunction(){
			Debug.Log("This will get called!");
		}
	------------------------------------------------------------------
	------------------------------------------------------------------
	* Delegates can have inputs and can return data
		public delegate int IReturnAnInt();
		private int FunctionReturnInt(){
			return 42;
		}
		
		public delegate void IHaveInputs(int number, string text);
		private void FunctionWithTwoInputs(int number, string text){
			Debug.Log("I got a number " + number + " And a string " + string);
		}
	------------------------------------------------------------------
	------------------------------------------------------------------
	* Adding functions to a delegate should be on the "OnEnable" and "OnDisable" functions to avoid later issues
		private void OnEnable(){
			exampleDelegate += MuFunction; // add a function
			exampleDelegate += MyOtherFunction; // add another function
		}
		private void OnDisable(){
			exampleDelegate -= MyFunction; // remove a function
			exampleDelegate -= MyOtherFunction; // remove another function
		}
	------------------------------------------------------------------
	------------------------------------------------------------------
	* Delegates can be static as well, which make them very easy to call
		public class StaticDelegateClass : MonoBehaviour{
			public delegate void MyStaticDelegate(); // normal delegate definition
			public static MyStaticDelegate myStaticDelegate; // static instance
		}
		
		private void OnEnable(){
			StaticDelegateClass.myStaticDelegate += MyFunction; // subscribe to static delegate
		}
	------------------------------------------------------------------
		
* Events:
	* Are delegates! the difference is when we create an event it will actually create an instance of a delegate, but with the keyword "Event" in front of the delegate instance
	* Use events to prevent overriding subscribed functions and do public invoking
	
* Actions and Funcs:
	* They inherit from delegate
	* They are shortcuts to create delegates
	* Actions has inputs but no return values
		public static Action myStaticEvent; // static instance
		public static Action<int> myStaticEventWithInt;
	* Funcs has inputs and return values
		public static Func<int> myStaticFunc; // returns an int
		public static Func<int, string> myStaticFuncWithInput; // returns a string
		
* HOW ALL THIS LOOK LIKE TOGETHER?
	------------------------------------------------------------------
	public class StaticEvenetClassWithAction : MonoBehaviour{
		public static event Action myStaticEvent; //static instance
		public static event Action<int> myStaticEventWithInt;
	
		void Update(){
			myStaticEvent?.Invoke();
			myStaticEventWithInt?.Invoke(12);
		}
	}
	------------------------------------------------------------------
	------------------------------------------------------------------
	public class StaticEventWithActionSubscriber : MonoBehaviour{
		void OnEnable(){
			StaticEvenetClassWithAction.myStaticEvent += MyFunction; // subscribe to static delegate
			StaticEvenetClassWithAction.myStaticEventWithInt += MyFunctionWithAnInt;
		}
		
		void OnDisable(){
			StaticEvenetClassWithAction.myStaticEvent -= MyFunction; // unsubscribe to static delegate
			StaticEvenetClassWithAction.myStaticEventWithInt -= MyFunctionWithAnInt;
		}
		
		void MyFunction() {}
		
		void MyFunctionWithAnInt(int number){
			Debug.Log("I got a number: " + number);
		}				
	}
	------------------------------------------------------------------
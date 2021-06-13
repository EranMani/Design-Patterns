feature/State_Pattern
* States allow game objects to take on different behaviors when required, making them look like they are controlled
  by a completely different class. 
* Unity using states in the mechanim system
* The embodiment of this design pattern is the FSM -> Finite State Machine
* The FSM is a conceptual machine that can be in exactly one of any given number of finite states
  at any time.
* FSM is used in the field of Artifical Intelligence to define the behaviours of computer controlled 
  characters.
* Once a state has been entered, the NPC stays in that state until a condition on the transition is met
* Any te machine has 3 processes that it runs at different times:
	* Enter -> runs as soon as the state is transitioned to
	* Update -> enters the endless loop of the update. Update continues to run until the 'transition out
				of the state' is triggered.
	* Exit -> at the point before leaving the state, the exit method is run
* The state comes into play where a state is defined as a contained piece of code that deals with 
  all of the behaviours and only the behaviors that belong to that particular state.
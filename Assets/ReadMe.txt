07/06/21
feature/Observer_Pattern
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
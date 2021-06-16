* Other design patterns that are not specified and is already implemented by Unity

* Design Pattern -> The Game Loop
	* The premise of the Game Loop is to keep the program running until the user is finished or decides to quit.
	* Basically, each loop of the game produces one drawn frame of graphics on the screen but in order to draw that image, a lot of processing needs to take place.
	  For example, animations are updated, physics is updated, user input is processed and much, much more.
	* we then have to process the user input, update all of the game objects that are in there, update the environment and then actually render the scene before.
	  the loop begins again 
	* when you finally finish playing the game and you quit out of that while-loop, then some cleanup gets performed, which then removes all of the stuff from memory, 
	  saves files and the kinds of things you would expect the END of a program to do before it finishes executing.

* Design Pattern -> The Update
	* It runs from inside the Game Loop and the Update method inside Unity's MonoBehaviour class is a perfect example of the Update Pattern.
	* Within the game, there are many game objects that all need updating and possibly need updating in many and varied ways.
	  The Update within the Game Loop takes a collection of all the game objects and looks for and finds all of their Update methods
	* In Unity, game objects with a MonoBehaviour provide you with access to 3 Update types - FixedUpdate, Update and LateUpdate.
		* FixedUpdate can actually occur more frequently than the Update. All physics calculations are done after the FixedUpdates for all of the game objects have been run.
		  This is where you'd put code relating to the physics system.
		* Update is fixed, so there's no need to multiply movement inside it by Time.deltaTime. The Update method always runs once per game loop.
		* Most of your code you do put into this actual method and inside of here you'd put things like translations or rotations that occur (without physics), capturing key presses,
		  artificial intelligence code and that type of thing.
		* It makes sense to try and put as much of your behavioural code into the Update as possible because you know it's only going to run once before the scene is rendered.
		  It would make no sense, for example, to test for the spacebar being pressed inside of FixedUpdate, as it would get tested many times per loop
		* LateUpdate occurs immediately after the Update. This can be used for things that require all the object's calculations to be finished before they should take place.
		  One example is placing in the LateUpdate any camera-following behavior
		  
* Design Pattern -> The Object
	* allows for the creation of new classes from a base behavior class, that works with the game engine and yet the new classes. Can represent completely different objects.
	* 'UnityEngine.Object' is the base class for all built-in Unity objects and the base class for all. Entities in a Unity scene are game objects.
	* When you create an empty game object, you get the basic vanilla version of the game object class, where you can see clearly all of its properties in the Inspector. 
	  Then what makes these game objects different from each other is the addition of 'Components'.
	  
* Design Pattern -> Components
	* Unity objects become other types of game objects by adding components that dramatically change their behavior.
	* These include all of the components that you can add to a game object in the Inspector, including meshes, particles, physics attributes,
	  audio, rendering methods, scripts and other miscellaneous things.
	  
* Design Pattern -> Services
	* This pattern insists we separate out the functionality of the game engine and compartmentalize it.
	* In a way, this decouples the entire engine, just the way we've been using other patterns to decouple our code.











































 












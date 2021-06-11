feature/Singleton_Pattern
* The singleton pattern is a way to ensure a class has only a single globally accessible instance available at all times
* This is very useful for making global manager type classes that hold global variables and functions that many other classes need to access
* Singleton advantages are:
	* Globally accessible. No need to search for or maintain a reference to the class.
	* Persistent data. Can be used to maintain data across scenes.
	* Supports interfaces. Static classes can not implement interfaces.
	* Supports inheritance. Static classes can not inherent for another class.
* Singleton disadvantages are:
	* Must use the Instance keyword (e.g. <ClassName>.Instance) to access the singleton class.
	* There can only ever be one instance of the class active at a time.
	* Tight connections. Modifying the singleton can easily break all other code that depends on it. Requiring a lot of refactoring.
	* No polymorphism.
Not very testable.
* The advantage of using singletons in Unity, rather than static parameters and methods, 
  is that static classes are lazy-loaded when they are first referenced, but must have an empty static constructor. 
  This means it's easier to mess up and break code if you're not careful and know what you're doing.
  
* Here is a template for creating a singleton instance
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sealed - this class can't be used to create other classes
// No other classes can inherit from this class
public sealed class GameEnvironment
{
    private static GameEnvironment instance;
    private List<GameObject> obstacles = new List<GameObject>();

    public List<GameObject> Obstacles { get { return obstacles; } }

    public static GameEnvironment Singleton
    {
        get
        {
            if (instance == null)
            {	
				// This singleton will be created once upon first call. Can be attached to a game object or call it first time
				// from a different script
                instance = new GameEnvironment();
            }

            return instance;
        }
    }

    public void AddObstacles(GameObject go)
    {
        obstacles.Add(go);
    }

    public void RemoveObstacles(GameObject go)
    {
        int index = obstacles.IndexOf(go);
        obstacles.RemoveAt(index);
    }
}

05/06/21
- feature/Flyweight_Pattern
* Flyweight is a software design pattern. It is an object that minimizes memory use by sharing as much data as possible with other similar objects
* The basis is coservation use of memory
* Pointing data that is the same, wherever it is needed, rather then duplicating it and having many copies of it sitting in memory
* It is way more efficient to point at objects in memory that are the same wherever you want to use them, rather then having multiple copies of things all over the place, cluttering up the memory
* It is a way to use objects in large numbers when a simple repeated representation would use an unacceptable amount of memory
* When having many objects in the game. These objects have to share some data which is the same for all objects. If they share some data, then it is possible to create the data once and then store a reference to the data
  in the object.
* EXAMPLE: creating a scene with 400 cubes. Instead of creating and storing each cube object in memory, we will store one cube object that will be passed to the other cubes. This will make the cube objects 
           point to the same cube object in memory instead of pointing to 400 cubes in memory.
* SCRIPTABLE OBJECTS - follows the flyweight pattern because they are a really great way of storing(bundle) up the data for any particular thing and take it out of any code that youve got attached to the actual prefab
	* To use a scriptable object in unity it must be an asset of the menu system
	* Scriptable object type is an asset
	* In order to hook up the scriptable object data into a prefab, the scriptable object must sit in a generic script, and that script will be attached as a component to the prefab itself
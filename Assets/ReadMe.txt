03/06/21
- feature/Command_Pattern branch
* Commands are an object orientated replacement for callbacks. They are method calls wrapped in an object
* Command pattern encapsulates a request as an object, thereby letting us parameterize other objects with different requests, queue or log requests, and support undoable operations
* They are particulary useful in games for binding user inputs to game actions
* They will be used for input handling, since it is one of the most popular places to use commands patterns in game programming
* The player will issue the inputs, and they will be stored with the command pattern
* The Command pattern is also useful if you want to create Undo and Redo functionalities in a strategy game.
* Simply put, a Command class will have an Execute method which can accept an object (on which the command acts) called the Receiver as an input parameter
* The multiple instances of a Command class can be passed around as regular objects, which means that they can be stored in a data structure, such as a queue, stack, etc.
* To execute any command, its Execute method will need to be called. The class that triggers the execution is called the Invoker.

07/06/21
feature/Observer_Pattern
* With the observer pattern, we can turn the object into a 'notifier' and the other items are turned into 'observers' without knowing about the existence of others.
* If any item is interseted in the state of that object, it can then become a listener that monitors messages in the environment and acts upon the ones that it is interseted in.
* This pattern decouples the code, such that you can have multiple notifiers and multiple listeners and you cann add and take away any of these without disrupting the program and requiring massive refactoring
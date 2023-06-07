[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/Ow0_BDFJ)

# Portfolio Of Evidence (POE) Part 1 by ST10042763 (Cameron Stocks)

## Whats the Code?

### MainClass.cs

Our MainClass.cs File holds the main method for the program 

### Application.cs

Our Application.cs Contains all the necessary methods for the app loop and lifespan of 
the application

### Recipe.cs

This Is a class to hold an entire recipe in one class and make it a callable object with non-static members

### UnitOfMeasurement.cs

This is just a class that contains the unit of measurement to allow for standardised measurement 
and easy conversion in the [Recipe.cs](#recipecs)

### CConsole.cs 

This is the custom console I made to add some color for the warning in Calorie Count

### DebugClass.cs

This class holds the pre loaded classes for the necessary debugging

### Recipe_Unit_Tests

This class holds the unit tests for the calorie counter and converter

## How does it work?

1. [outRecipe](#appstateoutrecipe)
2. [inRecipe](#appstateinrecipe)

These states govern the mainloop of our application and determine the output menus and event handling for the program

These 2 states are important as the decide which part of the menu to run

### AppState.outRecipe

This state makes a menu giving the user 3 options

1. The first option is to add a new recipe. This allows the user to add a recipe.

2. The second option is to view recipes. If there are none to view then it is displayed. Otherwise all the recipes are displayed in an ordered list.
it also switches the statet to `AppState.inRecipe`

3. The third Option is to exit the program. It exits the program


### AppState.inRecipe

This state gives the user more options based on the recipes they have entered.
There are 7 total options.

1. The first option is to view the recipe. It displays the recipe

2. The second option is to adjust the recipe quantities. It allows the user to scale the recipes if needed

3. The third opton is to reset the quantities. This resets the recipe to the default quantities of the application.

4. The fourth option is to clear data. This deletes all recipes in the application

5. The fith option is to delete the current recipe your busy with

6. The sixth option is to go back to the previous screen and set the AppState to `AppState.outRecipe`

7. The seventh option is to exit the application. It exists the application

## Debug class. 

The application is made in such a way that you can use CLI arguments to run the application in the necessary state
If you wish to run it from Visual Studio with the debug Class you need to go to:

`Project > Properties > Debug` 

And in the "Commmand Line Arguments" box add: `init-class-debug` and the default recipe class will be loaded

Otherwise to run from the terminal make sure you are in the correct directory
` SolutionDir\bin\ ` 

in the `command prompt` or `powershell` cli run the following command `POE.exe init-class-debug`

This will run the application with the default loaded class 


Otherwise just run the application without the cla (Command Line Arguments) to run the application from the beginning

## Unit Tests

The application is made in such a way that you can use CLI arguments to run the application in the necessary state
If you wish to run it from Visual Studio with the Unit Tests you need to go to:

`Project > Properties > Debug` 

And in the "Commmand Line Arguments" box add: `run-unit-test` and the unit test will begin

Otherwise to run from the terminal make sure you are in the correct directory
` SolutionDir\bin\ ` 

in the `command prompt` or `powershell` cli run the following command `POE.exe run-unit-test`

This will run the application in the Unit Test


Otherwise just run the application without the cla (Command Line Arguments) to run the application from the beginning

## Lecturer Feedback
I did not recieve feedback on where I lost my marks, therefore it is unreasonable to reduce marks based on this.

The Word Document Containing my feedback is attatched to my POE

﻿using System;
using System.Collections.Generic;
using System.Linq;

// |========================================================================|
// |========================================================================|
// |========================================================================|
// |                                PLEASE NOTE                             |
// |Bytes were used instead of ints for memory management and my 100 % :D   |
// |========================================================================|
// |========================================================================|
// |========================================================================|


// |===============================================|
// |            IMPORTANT FACTORS                  |
// | Abbreviations where used for leasure          |
// | and readability:                              |
// | Abbreviations explained:                      |
// | STDIN  => Standard Input  (The Console Input) |
// | STDOUT => Standard Output (The Console Output)|
// | ==============================================|

namespace POE {

    internal class Application {
        private List<Recipe> recipes;
        private int? active_recipe;
        //Small enum that tells the app what state to be in to determine what logical operators to perform
        //The value of the enum refers to the maximum options of each state
        //Enum is defined in the class as it local to this class only
        private enum AppState {
            outRecipe = 3,
            inRecipe = 7
        }
        //Get the state of the application
        private AppState state;
        //The application loop
        private bool appFinished = false;
        public Application() {
            //Showing the application has no recipe therefore no persitance
            this.state = AppState.outRecipe;
            //Shpwing the apploop has continued
            this.appFinished = false;
            //Initilise the recipe list
            this.recipes = new List<Recipe>();
            //Set the active Recipe to null
            this.active_recipe = null;
        }
        /// <summary>
        /// This is the default debug class
        /// This was made because i got tired of making recipes with 1 ingredient called Pizza
        /// #LAZY
        /// </summary>
        public void RunDebug() {
            //Make the default recipe class
            this.recipes = new DebugClass().Recipes;
            //Call the RunApp method to run the app normally
            this.RunApp();
        }
        /// <summary>
        /// The actual run application of this class
        /// </summary>
        public void RunApp() {
            //Main App loop
            do {
                //The users option defined for the do while scope 
                byte option;
                //predefine the validity of the users input defined for the do while scope
                bool optionValid = false;

                do {
                    //Display the menu
                    this.Menu(this.state);
                    //Get the users option
                    option = this.GetBytes();

                    //Determine the validity of the option using a guard claus
                    if (option == 0 || option > (int)this.state) {
                        //Alert the user of thier invalid option
                        Console.Write("Option Invalid!\nPress Any Key to Continue...");
                        Console.ReadKey();
                        //Clear the console for readability purposes
                        Console.Clear();
                        continue;
                    }

                    //state the option is valid as it does not continue through the guard clause statement
                    optionValid = true;
                    //Continue the loop if there is no valid option added
                } while (!optionValid);

                //Handle the users valid input given the current state
                this.HandleEvent(this.state, option);
                //Clear the console for the users use
                Console.Clear();

                //Exit the app if the apploop is finished
            } while (!this.appFinished);
            //Say goodbye to the user as they are finished with the application
            Console.WriteLine("Come Again Soon!");
            //Tell the user how to close
            Console.WriteLine("Press any key to close...");
            //Wait for the user to close the application
            Console.ReadKey();
        }
        /// <summary>
        /// This method writes the menu to the STDOUT
        /// </summary>
        /// <param name="state">The state the application is in</param>
        private void Menu(AppState state) {
            //set the defualt prompt to an empty string for compiler warnings
            string prompt = string.Empty;

            //Swtich the current state
            switch (state) {
                //Select the prompt if there is no recipe
                case AppState.outRecipe: {
                    //Set the no recipe prompt
                    prompt = "(1) Add your recipe\n(2) View Recipes\n(3) Exit";
                    //Break out the case
                    break;
                }

                //Select the prompt if there is a recipe
                case AppState.inRecipe: {
                    //Set the has recipe prompt
                    prompt = "(1) View recipe\n(2) Adjusted recipe quantities\n(3) Reset quantities\n(4) Clear Data\n(5) Delete Recipe\n(6) << Back\n(7) Exit";
                    //Break out the case statement
                    break;
                }
            }

            //output the appropriate prompt
            Console.WriteLine(prompt);
            //Write a line for the users input
            Console.Write("Enter option: ");
        }

        /// <summary>
        /// This method handles the users enter option
        /// </summary>
        /// <param name="state">The current state of the app</param>
        /// <param name="option">The users selected option</param>
        private void HandleEvent(AppState state, byte option) {
            //Switch on the current state
            switch (state) {
                //Case if there is no recipe
                case AppState.outRecipe: {
                    //Go to the method that handles the events related to entering a recipe
                    this.EnterRecipeEventHandler(option);
                    //Break this current case
                    break;
                }

                //Case if there is a recipe
                case AppState.inRecipe: {
                    //Go to the method that handles the events related to having a current recipe
                    this.RecipeEventHandler(option);
                    //Break the current case
                    break;
                }
            }
        }

        #region General Methods
        //here are General Functions
        /// <summary>
        /// This method is responsible for getting and validating the users input
        /// </summary>
        /// <returns>0 if there is an exception throw or the value the user entered</returns>
        private byte GetBytes() {
            byte userInput;
            try {
                userInput = Convert.ToByte(Console.ReadLine());
            } catch (OverflowException) {
                return 0;
            } catch (FormatException) {
                return 0;
            }
            return userInput;
        }
        /// <summary>
        /// This method gets bytes from the user
        /// </summary>
        /// <param name="r">r = user_in.ToLower() == "r";</param>
        /// <returns>A Byte the user entered</returns>
        private byte GetBytes(out bool r) {
            r = false; // Default restart;
            string userInput; // Define the user input
            try { // Create a try Catch
                userInput = Console.ReadLine(); // Assign the user input
                if (userInput == "r") { // Check it for R
                    r = true; // If 'r' then r = true;
                }
                return Convert.ToByte(userInput); // Else we return the bytes
            } catch (OverflowException) {
                return 0;
            } catch (FormatException) {
                return 0;
            }
            //We return 0 if there is an error
        }
        /// <summary>
        /// This method gets a double from the user from the STDIN
        /// </summary>
        /// <param name="pressedR">Checks to see if the user pressed 'r'</param>
        /// <returns>A Double</returns>
        private double GetDouble(out bool pressedR) {
            string userInput; // Make a variable for user input
            userInput = Console.ReadLine(); // Get the input from the STDIN
            pressedR = userInput.ToLower() == "r"; // Check to see if it is 'r'
            try {  // Create a try catch because users break things
                if (userInput.Contains(".")) { // Check to see if there is a full stop '.'
                    userInput = userInput.Replace('.', ','); // if there is we make it a commma ','
                    //The reason we do this is due to geolocation and location settings 
                    // The .NET compiler knows we make number like this 1 234,56
                    // Not like the yanks that do it like this: 1,234.56
                    //Thank you!
                }
                return Convert.ToDouble(userInput); // Then we attempt to return it
            } catch (OverflowException) {
                return 0;
            } catch (FormatException) {
                return 0;
            }
            //If an exception is thrown we return 0
        }

        /// <summary>
        /// This method is used to set the appFinished field to true to exit the apploop
        /// </summary>
        private void Exit() {
            //Sets appfinished to true
            this.appFinished = true;
        }
        #endregion

        #region Out Recipe Methods
        //Here are the events of the app without a recipe
        /// <summary>
        /// This method Handles the users option event for when there is no recipe
        /// </summary>
        /// <param name="option">The users option that was chosen</param>
        private void EnterRecipeEventHandler(byte option) {
            switch (option) { // Check the option for 1 or 2
                case (1): {
                    this.EnterRecipe(); // if its we let the user make a recipe
                    break;
                }

                case (2): {
                    this.ViewRecipes();
                    break;
                }

                case (3): {
                    this.Exit(); // if its 2 we close the app!
                    break;
                }
            }
        }
        /// <summary>
        /// Allows the user to enter the recipe of their choice
        /// </summary>
        private void EnterRecipe() {
            Console.Clear();
            bool restart = default;
            string name = string.Empty;
            string[] names = default;
            UnitOfMeasurement[] UoMs = default;
            double[] quantities = default;
            ushort[] calories = default;
            string[] foodgroups = default;
            string[] steps = default;
            bool namevalid = false;
            do {
                
                if (!namevalid) {//Added scope for memory management
                    do {
                        Console.Write("Enter the name of your recipe: ");
                        name = Console.ReadLine() ?? "none";
                        if (name == "none") {
                            Console.WriteLine("Name is invalid!");
                        } else {
                            bool exists = false;
                            if (this.recipes.Count != 0) {
                                foreach (Recipe recipe in this.recipes) {
                                    if (recipe.Name.ToLower() == name.ToLower()) {
                                        exists = true;
                                    }
                                }
                            }

                            if (exists) {
                                Console.WriteLine($"Recipe {name} Already Exists");
                            } else {
                                namevalid = true;
                            }
                        }
                    } while (!namevalid);
                }

                //Tell the user what we are doing
                Console.WriteLine("Lets start with the amount of ingredients you want to add!");
                Console.WriteLine("You can always restart by typing 'r'");
                //Ask the user for the number of ingredients that needs to be entered
                Console.Write("Enter the amount of ingredients for your recipe: ");
                //Get the number of ingredients
                //that need to be entered
                byte numIngredients = this.GetBytes();
                if (numIngredients == 0) {
                    Console.WriteLine("Please enter a valid amount of ingredients");
                    restart = true;
                    continue;
                }

                (names, UoMs, quantities, calories, foodgroups) = this.GetIngredients(out restart, numIngredients);

                if (!restart) {
                    Console.Write("Enter the number of steps for your recipe: ");
                    byte numSteps = this.GetBytes(out restart);
                    if (!restart) {
                        steps = this.GetSteps(out restart, numSteps);
                    }
                }

                if (restart) {
                    namevalid = false;
                    Console.WriteLine("Lets restart then\nPress any key to continue...");
                    Console.Clear();
                }

            } while (restart);
            this.recipes.Add(new Recipe(name, names, UoMs, quantities, calories, foodgroups, steps));
            this.recipes = this.recipes.OrderBy(x => x.Name).ToList();
        }
        /// <summary>
        /// This method gets the ingredients from the the user
        /// </summary>
        /// <param name="restart">We check to see if the user wants to restart</param>
        /// <param name="count"> The amount of ingredients</param>
        /// <returns>the names units and quantites for each ingredient</returns>
        private (string[] ing_names, UnitOfMeasurement[] UoMs, double[] quantities, ushort[] calories, string[] foodgroups)
            GetIngredients(out bool restart, int count) {
            restart = false;
            //Make an array of Ingredient names unit of measurements and quantities for the users recipe
            string[] ingredientNames = new string[count];
            UnitOfMeasurement[] UoM = new UnitOfMeasurement[count];
            double[] quantity = new double[count];
            ushort[] calories = new ushort[count];
            string[] foodgroups = new string[count];
            //Do a for loop for the number of ingredients the user entered
            for (int i = 0; i < count; i++) {
                //Get the ingredient name
                ingredientNames[i] = this.GetIngredientName(out restart, i + 1);
                if (restart) {
                    return (null, null, null, null, null);
                }
                UoM[i] = this.GetUnitOfMeasurement(out restart);
                if (restart) {
                    return (null, null, null, null, null);
                }
                quantity[i] = this.GetIngredientQuantity(UoM[i], out restart);
                if (restart) {
                    return (null, null, null, null, null);
                }
                calories[i] = this.GetCalories(out restart);
                if (restart) {
                    return (null, null, null, null, null);
                }
                foodgroups[i] = this.GetIngredientFoodGroup(out restart);
                if (restart) {
                    return (null, null, null, null, null);
                }
            }
            return (ingredientNames, UoM, quantity, calories, foodgroups);
        }
        /// <summary>
        /// This method gets the steps the user wants to add
        /// </summary>
        /// <param name="pressedR">Check to see if the user pressed R</param>
        /// <param name="count">The amount total amount of steps</param>
        /// <returns>An array of all the steps</returns>
        private string[] GetSteps(out bool pressedR, int count) {
            string[] steps = new string[count];
            for (int i = 0; i < count; i++) {
                bool validStep;
                do {
                    Console.WriteLine($"Enter step {i + 1}");
                    pressedR = (steps[i] = Console.ReadLine()).ToLower() == "r";
                    if (steps[i] == string.Empty) {
                        Console.WriteLine("Invalid Step!");
                        validStep = false;
                    } else {
                        validStep = true;
                    }
                } while (!validStep);

                if (pressedR) {
                    return null;
                }
            }
            pressedR = false;
            return steps;
        }
        /// <summary>
        /// This method gets the name of the ingredient and validates the user input
        /// </summary>
        /// <param name="pressedR"></param>
        /// <returns>The Ingredient Name</returns>
        private string GetIngredientName(out bool pressedR, int num) {
            pressedR = false;
            string name;
            bool validName;
            do {
                Console.Write($"Enter ingredient {num} name: ");
                name = Console.ReadLine();
                if (name == string.Empty) {
                    Console.WriteLine("Invalid Ingredient name entered!");
                    validName = false;
                } else {
                    validName = true;
                }
            } while (!validName);
            if (name.ToUpper() == "R") {
                pressedR = true;
            }
            return name;
        }
        /// <summary>
        /// This method allows for the user to enter a unit of measurement for their ingredient
        /// </summary>
        /// <param name="pressedR">Checks to see if a user pressed R to restart the program</param>
        /// <returns>Unit of measurment</returns>
        private UnitOfMeasurement GetUnitOfMeasurement(out bool pressedR) {
            pressedR = false;
            bool validUoM = false;
            UnitOfMeasurement returns = UnitOfMeasurement.None;
            do {
                Console.WriteLine("Select your unit of measurement");
                Console.Write("(1) Tsp\n(2) Tbsp\n(3) Cup\n(4) G\n(5) KG\n(6) Ml\n(7) L\nEnter unit here: ");
                string UserInput = Console.ReadLine();
                if (UserInput.ToUpper() == "R") {
                    pressedR = true;
                    return 0;
                }
                byte UoM;
                try {
                    UoM = Convert.ToByte(UserInput);
                    if (UoM <= 0 || UoM >= 8) {
                        Console.WriteLine("Invalid Option Selected");
                        validUoM = false;
                        continue;
                    } else {
                        returns = (UnitOfMeasurement)UoM;
                        validUoM = true;
                    }
                } catch (OverflowException) {
                    Console.WriteLine("That number is too big!");
                } catch (FormatException) {
                    Console.WriteLine("Enter a valid Number!");
                }
            } while (!validUoM);
            return returns;
        }

        private double GetIngredientQuantity(UnitOfMeasurement uom, out bool pressedR) {
            Console.Write($"Enter amount of {UoMConversions.UoMToNameM(uom)}: ");
            double qty = this.GetDouble(out pressedR);
            if (pressedR) {
                return 0;
            }
            return qty;
        }

        private ushort GetCalories(out bool restart) {
            restart = false;
            bool validCalories = false;
            ushort calories = default;
            do {
                Console.Write("Enter Amount Of Calories: ");
                string s = Console.ReadLine();
                if (s.ToLower() == "r") {
                    restart = true;
                    break;
                }
                try {
                    calories = Convert.ToUInt16(s);
                    validCalories = true;
                } catch (FormatException) {
                    Console.WriteLine("Invalid Calories entered");
                } catch (OverflowException) {
                    Console.WriteLine("Invalid Calories entered");
                }
            } while (!validCalories);
            return calories;
        }

        private string GetIngredientFoodGroup(out bool restart) {
            restart = false;
            Console.Write(
                "Select food Group:\n(1) Starchy Fruits\n(2) Fruits and Veg\n(3) Grains\n(4) Protein\n(5) Dairy\n(6) Fats and Oils\n(7) Water\nEnter Unit: "
               );
            string[] groups = { "Frut", "Vegetable", "Grain", "Protein", "Dairy", "N/A" };
            bool fg_valid = false;
            string foodGroupName = default;
            do {
                byte selected_group = this.GetBytes(out restart);
                if (restart) {
                    return null;
                }

                if (selected_group == 0) {
                    Console.WriteLine("Invalid Option selected!");
                }

                try {
                    foodGroupName = groups[selected_group - 1];
                    fg_valid = true;
                } catch (IndexOutOfRangeException) {
                    Console.WriteLine("Invalid Option Selected");
                }
            } while (!fg_valid);
            return foodGroupName;
        }

        private void ViewRecipes() {
            Console.Clear();
            if (this.recipes.Count == 0) {
                Console.WriteLine("There are no recipes\nPress any key to continue . . .");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            bool validByte = false;
            do {
                Console.Clear();
                for (int i = 0; i < this.recipes.Count; i++) {
                    Console.WriteLine($"({i + 1}) {this.recipes[i].Name}");
                }

                Console.WriteLine($"({this.recipes.Count + 1}) << Back");
                byte option = this.GetBytes();

                if (option == 0) {
                    Console.WriteLine("Invalid Option");
                    continue;
                }

                if (option > this.recipes.Count + 1) {
                    Console.WriteLine("Invalid Option");
                    continue;
                }

                if (option == this.recipes.Count + 1) {
                    break;
                }

                this.active_recipe = option - 1;
                this.state = AppState.inRecipe;
                validByte = true;
            } while (!validByte);
        }

        #endregion


        #region In Recipe Methods
        //Here are the events of the app with a recipe
        /// <summary>
        /// This method handles the events if there is a recipe
        /// </summary>
        /// <param name="option">the users entered option</param>
        private void RecipeEventHandler(byte option) {
            switch (option) {
                case (1): {
                    this.PrintRecipe();
                    break;
                }

                case (2): {
                    this.ScaleRecipe();
                    break;
                }

                case (3): {
                    this.ResetRecipe();
                    break;
                }

                case (4): {
                    this.ClearData();
                    break;
                }

                case (5): {
                    this.DeleteRecipe();
                    break;
                }

                case (6): {
                    this.state = AppState.outRecipe;
                    break;
                }

                case (7): {
                    this.Exit();
                    break;
                }
            }
        }
        /// <summary>
        /// Allow the user to view the recipe
        /// </summary>
        private void PrintRecipe() {
            Console.Clear();
            this.recipes[this.active_recipe.Value].PrintRecipe();
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }

        /// <summary>
        /// Allow the user to scale the recipe
        /// </summary>
        private void ScaleRecipe() {
            Console.Clear();
            Console.WriteLine("Enter the amount of which you wish to scale your recipe");
            Console.Write("(1) Half recipe\n(2) Double recipe\n(3) Triple recipe\n(4) << Back\nEnter option here: ");

            bool validOpt;
            do {
                byte opt = this.GetBytes();
                if (opt == 4) {
                    validOpt = true;
                    return;
                } else if (opt == 0 || opt > 3) {
                    Console.WriteLine("Select a valid Option!");
                    validOpt = true;
                } else {
                    switch (opt) {
                        case (1): {
                            this.recipes[this.active_recipe.Value].Scale(0.5);
                            break;
                        }

                        case (2): {
                            this.recipes[this.active_recipe.Value].Scale(2);
                            break;
                        }

                        case (3): {
                            this.recipes[this.active_recipe.Value].Scale(3);
                            break;
                        }
                    }
                    validOpt = true;
                }
            } while (!validOpt);

            if (this.recipes[this.active_recipe.Value].TotalCalories > 300) {
                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine("Recipe scaled accurately.\nSelect option '(1) View recipe' to view the recipe");
            Console.ReadKey();
        }
        /// <summary>
        /// Allow the user to reset the recipe to the default values
        /// </summary>
        private void ResetRecipe() {
            Console.Clear();
            Console.WriteLine("Recipe has been reset to default quantities\nSelect option '(1) View recipe' to view the recipe");
            this.recipes[this.active_recipe.Value].ResetRecipe();
            Console.ReadKey();
        }
        /// <summary>
        /// Delete the recipe
        /// </summary>
        private void ClearData() {
            this.recipes = new List<Recipe>();
            this.state = AppState.outRecipe;
            Console.WriteLine("Recipe deleted.\nPress any key to continue . . .");
            Console.ReadKey();
        }

        private void DeleteRecipe() {
            this.recipes.Remove(this.recipes[this.active_recipe.Value]);
            this.state = AppState.outRecipe;
        }
        #endregion
    }
}
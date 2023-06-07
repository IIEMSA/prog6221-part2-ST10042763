using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POE {
    /// <summary>
    /// This is the recipe class! WOOHOO!!!
    /// </summary>
    internal class Recipe {
        private string name;
        public string Name {
            get => this.name;
            set => this.name = value;
        }
        private readonly List<string> ingredients;
        private readonly List<UnitOfMeasurement> UoM;
        private readonly List<string> convertedUoM;
        private List<double> quantity;
        private readonly List<string> foodGroup;
        private List<ushort> calories;
        private readonly List<double> origionalQuantity;
        private readonly List<string> steps;
        private double totalCalories;

        public double TotalCalories {
            get => this.totalCalories;
        }

        private delegate void CaloricIntakeWarning(double calories);

        private CaloricIntakeWarning CalorieWarning = new CaloricIntakeWarning(calories => {
            if (calories > 300) {
                CConsole.Print("WARNING! Calorie Count Exceeeds 300 Calories!!", CColor.Black, CColor.Yellow, true, true);
                return;
            }
        });

        /// <summary>
        /// This is the default constructor
        /// </summary>
        /// <param name="ingredients">The array of ingredients</param>
        /// <param name="UoM">Array of unit of measurements</param>
        /// <param name="quantity">Array of quantities</param>
        /// <param name="steps">Array of steps</param>
        public Recipe(string name, string[] ingredients, UnitOfMeasurement[] UoM, double[] quantity, ushort[] calories, string[] foodGroup, string[] steps) {
            this.name = name;

            this.ingredients = new List<string>(ingredients);

            this.UoM = new List<UnitOfMeasurement>(UoM);

            this.quantity = new List<double>(quantity);
            this.origionalQuantity = new List<double>();
            this.quantity.ForEach(item => this.origionalQuantity.Add(item));

            this.foodGroup = new List<string>(foodGroup);

            this.calories = new List<ushort>(calories);
            this.calories.ForEach(calorie => this.totalCalories += calorie);
            this.CalorieWarning(this.totalCalories);

            this.steps = new List<string>(steps);

            this.convertedUoM = new List<string>();
            for (int i = 0; i < this.ingredients.Count; i++) {
                this.convertedUoM.Add(this.ConvertNecessary(this.quantity[i], this.UoM[i]));
            }

        }
        /// <summary>
        /// Resets the recipe to its default values
        /// </summary>
        public void ResetRecipe() {
            for (int i = 0; i < this.origionalQuantity.Count; i++) {
                this.quantity[i] = this.origionalQuantity[i];
                this.convertedUoM[i] = this.ConvertNecessary(this.quantity[i], this.UoM[i]);
            }
        }
        /// <summary>
        /// Scales the recipe by N factor
        /// </summary>
        /// <param name="factor">The factor at which to scale the recipe</param>
        public void Scale(double factor) {
            for (int i = 0; i < this.ingredients.Count; i++) {
                this.quantity[i] *= factor;
                this.convertedUoM[i] = this.ConvertNecessary(this.quantity[i], this.UoM[i]);
            }
            this.totalCalories *= factor;
            this.CalorieWarning(this.totalCalories);

        }
        /// <summary>
        /// This method returns the recipe as a string
        /// </summary>
        /// <returns>A formatted view of the recipe</returns>
        public void PrintRecipe() {
            string msg = $"Recipe: {this.name}\nIngredients:\n";
            for (int i = 0; i < this.ingredients.Count; i++) {
                msg += $"{this.convertedUoM[i]} of {this.ingredients[i]} ({this.calories[i]} Calories) [Food Group: {this.foodGroup[i]}]\n";
            }
            msg += "\nSteps:\n";
            for (int i = 0; i < this.steps.Count; i++) {
                msg += $"Step {i + 1}: {this.steps[i]}\n";
            }

            Console.WriteLine(msg);

            this.CalorieWarning(this.totalCalories);

            if (this.totalCalories > 300) {
                Console.WriteLine($"Total Calories: {this.totalCalories}");
                Console.ResetColor();
            } else {
                Console.WriteLine($"Total Calories: {this.totalCalories}");
            }
        }

#pragma warning disable
        /// <summary>
        /// This is a recursive method that scales the units and quantities appropriately
        /// and calls itself until there is no more scaling to be done
        /// </summary>
        /// <param name="qty">The quantities</param>
        /// <param name="UoM">This units of measurement</param>
        /// <returns>The converted quantites as a string for output</returns>
        private string ConvertNecessary(double qty, UnitOfMeasurement UoM) {
            string convUoM = string.Empty;
            bool converted = false;

            switch (UoM) {
                case UnitOfMeasurement.Tsp: {
                    if (qty >= 3) {
                        int n = Convert.ToInt32(Math.Floor(qty / 3));
                        convUoM += $"{n} {(n == 1 ? "tbsp" : "tbsp's")}";
                        convUoM = this.ConvertNecessary(n, UnitOfMeasurement.Tbsp);
                        converted = true;
                    }
                    if (qty % 3 > 1 && converted) {
                        convUoM += $" {this.ConvertNecessary(qty % 3, UnitOfMeasurement.Tsp)}";
                    }
                    break;
                }
                case UnitOfMeasurement.Tbsp: {
                    if (qty >= 16) {
                        int n = Convert.ToInt32(Math.Floor(qty / 16));
                        convUoM += $"{n} {(n == 1 ? "cup" : "cup's")}";
                        convUoM = this.ConvertNecessary(n, UnitOfMeasurement.Cup);
                        converted = true;
                    }
                    if (qty % 16 > 1 && converted) {
                        convUoM += $" {this.ConvertNecessary(qty % 16, UnitOfMeasurement.Tbsp)}";
                    }
                    break;
                }
                case UnitOfMeasurement.G: {
                    if (qty >= 1000) {
                        int n = Convert.ToInt32(Math.Floor(qty / 1000));
                        convUoM += $"{n} {(n == 1 ? "kg" : "kg's")}";
                        converted = true;
                    }
                    if (qty % 1000 > 1 && converted) {
                        convUoM += $" {this.ConvertNecessary(qty % 1000, UnitOfMeasurement.G)}";
                    }
                    break;
                }
                case UnitOfMeasurement.Ml: {
                    if (qty >= 1000 && !converted) {
                        int n = Convert.ToInt32(Math.Floor(qty / 1000));
                        convUoM += $"{n} {(n == 1 ? "l" : "l's")}";
                        converted = true;
                    }
                    if (qty % 1000 > 1 && converted) {
                        convUoM += $" {this.ConvertNecessary(qty % 1000, UnitOfMeasurement.Ml)}";
                    }
                    break;
                }
            }

            if (!converted) {
                return $"{qty} {(qty == 1 ? $"{UoM}" : $"{UoM}'s")}";
            }

            return convUoM;
        }
    }
#pragma warning restore
}
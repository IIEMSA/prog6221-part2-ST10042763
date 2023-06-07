using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE {
    internal class DebugClass {
    private List<Recipe> recipes;
        public List<Recipe> Recipes {
        get {
                return recipes; 
            } 
        }
        public DebugClass() {
            this.recipes = new List<Recipe>();
            this.recipes.Add(new Recipe(
                "Cams bred",
                new string[] {
                    "Water",
                    "Flour",
                    "Baking Soda",
                    "Sugar",
                    "Castor Sugar",
                    "Milk"
                },
                new UnitOfMeasurement[] {
                    UnitOfMeasurement.Ml,
                    UnitOfMeasurement.Cup,
                    UnitOfMeasurement.Tsp,
                    UnitOfMeasurement.Tbsp,
                    UnitOfMeasurement.G,
                    UnitOfMeasurement.Ml
                },
                new double[] {
                    3,
                    4,
                    2,
                    6,
                    400,
                    450
                },
                new ushort[] {
                    0,
                    50,
                    20,
                    60,
                    100,
                    50
                },
                new string[] {
                    "Water",
                    "Grain",
                    "Grain",
                    "Fats and Oils",
                    "Fats and Oils",
                    "Dairy"
                },
                new string[] {
                    "Put water in bowl",
                    "Put flour in bowl",
                    "Put baking soda in bowl",
                    "Put sugar in bowl",
                    "Add Castor Sugar",
                    "Add Milk",
                    "Mix into a dough",
                    "Kneed the dough",
                    "Cut into desired shapes and sizes",
                    "Bake for 30 minutes at 200 degrees Celcius",
                    "Let cool for 15 minutes",
                    "Enjoy your sweet bread"
                }
            ));

            this.recipes.Add(new Recipe(
                "Cams Coffee",
                new string[] {
                    "Water",
                    "Coffee",
                    "Sugar",
                    "Milk",
                },
                new UnitOfMeasurement[] {
                    UnitOfMeasurement.Ml,
                    UnitOfMeasurement.Tsp,
                    UnitOfMeasurement.Tsp,
                    UnitOfMeasurement.Ml,
                },
                new double[] {
                    430,
                    1,
                    2,
                    20,
                },
                new ushort[] { 
                    0,
                    5,
                    20,
                    10
                },
                new string[] { 
                    "Water",
                    "Fats and Oils",
                    "Fats and Oils",
                    "Dairy"
                },
                new string[] {
                    "Put water in bowl",
                    "Put flour in bowl",
                    "Put baking soda in bowl",
                    "Put sugar in bowl",
                    "Add Castor Sugar",
                    "Add Milk",
                    "Mix into a dough",
                    "Kneed the dough",
                    "Cut into desired shapes and sizes",
                    "Bake for 30 minutes at 200 degrees Celcius",
                    "Let cool for 15 minutes",
                    "Enjoy your sweet bread"
                }
            ));

            this.recipes.Add(new Recipe(
                "Cams Tea",
                new string[] {
                    "Water",
                    "Tea",
                    "Sugar",
                    "Milk",
                },
                new UnitOfMeasurement[] {
                    UnitOfMeasurement.Ml,
                    UnitOfMeasurement.Tsp,
                    UnitOfMeasurement.Tsp,
                    UnitOfMeasurement.Ml,
                },
                new double[] {
                    430,
                    1,
                    2,
                    20,
                },
                new ushort[] {
                    0,
                    5,
                    20,
                    10
                },
                new string[] {
                    "Water",
                    "Grain",
                    "Fats and Oils",
                    "Dairy"
                },
                new string[] {
                    "Put water in bowl",
                    "Put flour in bowl",
                    "Put baking soda in bowl",
                    "Put sugar in bowl",
                    "Add Castor Sugar",
                    "Add Milk",
                    "Mix into a dough",
                    "Kneed the dough",
                    "Cut into desired shapes and sizes",
                    "Bake for 30 minutes at 200 degrees Celcius",
                    "Let cool for 15 minutes",
                    "Enjoy your sweet bread"
                }
            ));
            
            this.recipes.Add(new Recipe(
                "Cams Chicken",
                new string[] {
                    "Chicken",
                },
                new UnitOfMeasurement[] {
                    UnitOfMeasurement.Kg,
                },
                new double[] {
                    430,
                },
                new ushort[] {
                    299
                },
                new string[] {
                    "Protien"
                },
                new string[] {
                    "Buy Chicken",
                    "Cook Chicken",
                    "Eat Chicken"
                }
            ));
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace POE {
    internal class Recipe_Unit_Test {
        public void RunUnitTest() {
            // This is the unit test class.
            // The Recipe Unit Test will consist of 5 recipes 
            // Each Recipe Name will be the name of the unit test eg Test Recipe 1
            // all strings and values will be assigned string.empty or 0 or will be casted to 0
            // The Recipies will be given specific numbers and are evaluated to specific constance
            // Should the unit test fail. Then the recipe class is not adequte.
            // Link to console.setOut
            // https://stackoverflow.com/questions/34920124/read-values-already-printed-to-the-consol
            this.Timer("Initialising Unit Tests");

            var Test_Recipe_One = new Recipe(
                "Test Recipe 1",
                new string[] {
                        "",
                        "",
                        "",
                        "",
                },
                new UnitOfMeasurement[] {
                        (UnitOfMeasurement)0,
                        (UnitOfMeasurement)0,
                        (UnitOfMeasurement)0,
                        (UnitOfMeasurement)0
                },
                new double[] {
                        0,
                        0,
                        0,
                        0,
                },
                new ushort[] {
                        53,
                        20,
                        95,
                        112
                },
                new string[] {
                        "",
                        "",
                        "",
                        "",
                },
                new string[] { "" }
            );

            var Test_Recipe_Two = new Recipe(
                "Test Recipe 2",
                new string[] {
                        "",
                        "",
                        "",
                        "",
                },
                new UnitOfMeasurement[] {
                        (UnitOfMeasurement)0,
                        (UnitOfMeasurement)0,
                        (UnitOfMeasurement)0,
                        (UnitOfMeasurement)0
                },
                new double[] {
                        0,
                        0,
                        0,
                        0,
                },
                new ushort[] {
                        100,
                        50,
                        60,
                        100
                },
                new string[] {
                        "",
                        "",
                        "",
                        "",
                },
                new string[] { "" }
            );

            var Test_Recipe_Three = new Recipe(
                "Test Recipe 3",
                new string[] {
                        "",
                        "",
                        "",
                        "",
                },
                new UnitOfMeasurement[] {
                        (UnitOfMeasurement)0,
                        (UnitOfMeasurement)0,
                        (UnitOfMeasurement)0,
                        (UnitOfMeasurement)0
                },
                new double[] {
                        0,
                        0,
                        0,
                        0,
                },
                new ushort[] {
                        32,
                        61,
                        54,
                        17
                },
                new string[] {
                        "",
                        "",
                        "",
                        "",
                },
                new string[] { "" }
            );

            Dictionary<int, Dictionary<int, bool>> Results = new Dictionary<int, Dictionary<int, bool>>();

            Results.Add(1, new Dictionary<int, bool>());
            const double RECIPE_ONE_DEFAULT_RESULT = 280;
            const double RECIPE_ONE_TRIPPLED_RESULT = 840;
            bool Test_One_Result_One = this.EvalTest(Test_Recipe_One.TotalCalories, RECIPE_ONE_DEFAULT_RESULT);
            Results[1].Add(1, Test_One_Result_One);
            Test_Recipe_One.Scale(3);
            bool Test_One_Result_Two = this.EvalTest(Test_Recipe_One.TotalCalories, RECIPE_ONE_TRIPPLED_RESULT);
            Results[1].Add(2, Test_One_Result_Two);

            Results.Add(2, new Dictionary<int, bool>());
            const double RECIPE_TWO_DEFALT_RESULT = 310;
            const double RECIPE_TWO_HALVED_RESULT = 155;
            bool Test_Two_Result_One = this.EvalTest(Test_Recipe_Two.TotalCalories, RECIPE_TWO_DEFALT_RESULT);
            Results[2].Add(1, Test_Two_Result_One);
            Test_Recipe_Two.Scale(0.5);
            bool Test_Two_Result_Two = this.EvalTest(Test_Recipe_Two.TotalCalories, RECIPE_TWO_HALVED_RESULT);
            Results[2].Add(2, Test_Two_Result_Two);

            Results.Add(3, new Dictionary<int, bool>());
            const double RECIPE_THREE_DEFALT_RESULT = 164;
            const double RECIPE_THREE_DOUBLED_REDSULT = 328;
            bool Test_Three_Result_One = this.EvalTest(Test_Recipe_Three.TotalCalories, RECIPE_THREE_DEFALT_RESULT);
            Results[3].Add(1, Test_Three_Result_One);
            Test_Recipe_Three.Scale(2);
            bool Test_Three_Result_Two = this.EvalTest(Test_Recipe_Three.TotalCalories, RECIPE_THREE_DOUBLED_REDSULT);
            Results[3].Add(2, Test_Three_Result_Two);

            Console.Clear();
            this.UnitPrint("Classes Initialised. Beginning test in ".PadLeft(Console.WindowWidth / 2), ConsoleColor.Cyan);
            int counter = 5;
            for (; counter > 0; counter--) {
                this.UnitPrint($"{counter}", ConsoleColor.Green);
                Thread.Sleep(1000);
                Console.Write("\b");
            }
            Console.Clear();

            for (int i = 0; i < 3; i++) {
                this.UnitPrint($"Running Unit test {i + 1}".PadRight(25), ConsoleColor.DarkYellow);
                char[] chars = { '[', '-', '-', '-', '-', '-', ']' };
                int loader_pointer = 1;
                for (int j = 0; j < 6; j++) {
                    for (int k = 0; k < chars.Length; k++) {
                        this.UnitPrint(chars[k].ToString(), ConsoleColor.Magenta);
                    }
                    for (int k = 0; k < chars.Length; k++) {
                        Console.Write("\b");
                    }
                    Thread.Sleep(200);
                    chars[loader_pointer] = '#';
                    if (loader_pointer != 5) {
                        loader_pointer++;
                    }

                }
                for (int k = 0; k < chars.Length; k++) {
                    this.UnitPrint(chars[k].ToString(), ConsoleColor.Magenta);
                }
                this.UnitPrintLine("Complete".PadLeft(25), ConsoleColor.Yellow);
            }
            Thread.Sleep(2000);
            Console.Clear();

            this.Timer("Formulating Results".PadLeft(Console.WindowWidth / 2));

            int fail_count = 0;
            foreach (KeyValuePair<int, Dictionary<int, bool>> test_results in Results) {
                int TestNum = test_results.Key;
                foreach (KeyValuePair<int, bool> case_results in test_results.Value) {
                    int CaseNum = case_results.Key;
                    bool result = case_results.Value;
                    if (result) {
                        this.UnitPrintLine($"Test: {TestNum} Case: {CaseNum} Passed".PadLeft(Console.WindowWidth / 2), ConsoleColor.Green);
                    } else {
                        this.UnitPrintLine($"Test: {TestNum} Case: {CaseNum} Failed".PadLeft(Console.WindowWidth / 2), ConsoleColor.Red);
                        fail_count++;
                    }
                    Thread.Sleep(1000);
                }
            }

            if (fail_count > 0) {
                this.UnitPrintLine("Unit Test Failed", ConsoleColor.Red);
            } else {
                this.UnitPrintLine("Unit Test Passed", ConsoleColor.Green);
            }

            this.UnitPrint("Press any key to continue . . .", ConsoleColor.Magenta);

            //Link to console.setOut
            // https://stackoverflow.com/questions/34920124/read-values-already-printed-to-the-console
            Console.ReadKey();
        }

        private void Timer(string message) {
            int message_length = message.Length + 1;

            int console_width = Console.WindowWidth;

            int control = 0;

            string[] timer = { "|", "/", "-", "\\" };
            
            this.UnitPrint($"{message}  ".PadLeft(console_width/2), ConsoleColor.Cyan);
            for (int i = 0; i < 100; i++) {    
                Console.Write("\b");
                this.UnitPrint(timer[control], ConsoleColor.Cyan);
                if (control == 3) {
                    control = -1;
                }
                Thread.Sleep(100);
                control++;
            }
            Console.Clear();
        }

        private void UnitPrint(string text, [Optional]ConsoleColor? cfg) {
            if (cfg != null) {
                Console.ForegroundColor = cfg.Value;
            }

            Console.Write(text);
            Console.ResetColor();
        }

        private void UnitPrintLine(string text, [Optional] ConsoleColor? cfg) {
            if (cfg != null) {
                Console.ForegroundColor = cfg.Value;
            }

            Console.WriteLine(text);
            Console.ResetColor();
        }

        private bool EvalTest(double value, double expected_value) {
            return value == expected_value;
        } 
    }
}
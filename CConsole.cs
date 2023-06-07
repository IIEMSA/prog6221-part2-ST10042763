using System;
namespace POE {
    public enum CColor {
        Red,
        Black,
        White,
        Green,
        Yellow,
        Blue,
        Cyan
    }

    internal class CConsole {
        public static void Print(string text, CColor bgColor, CColor fgColor, bool newLine, bool reset) {
            switch (bgColor) {
                case CColor.Red: {
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                }
                case CColor.Black: {
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                }
                case CColor.White: {
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                }
                case CColor.Green: {
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                }
                case CColor.Yellow: {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                }
                case CColor.Blue: {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                }
                case CColor.Cyan: {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;
                }
            }
            switch (fgColor) {
                case CColor.Red: {
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                }
                case CColor.Black: {
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                }
                case CColor.White: {
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                case CColor.Green: {
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                }
                case CColor.Yellow: {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                }
                case CColor.Blue: {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                }
                case CColor.Cyan: {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                }
            }

            if (newLine) {
                Console.WriteLine(text);
            } else {
                Console.Write(text);
            }

            if (reset) {
                Console.ResetColor();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ATMapp.UI
{
    public static class Utility
    {
        public static string GetSecretInput(string prompt)
        {
            bool isPrompt = true;
            string asterisk = "";

            StringBuilder input = new StringBuilder();

            while (true)
            {
                if (isPrompt)
                {
                    Console.WriteLine(prompt);
                }
                isPrompt = false;

                ConsoleKeyInfo inputKey = Console.ReadKey(true);

                if (inputKey.Key == ConsoleKey.Enter)
                {
                    if (input.Length == 6)
                    {
                        break;
                    }
                    else
                    {
                        PrintMessage("\n Please enter 6 digits.", false);
                        input.Clear();
                        isPrompt = true;
                        continue;
                    }
                }
                if (inputKey.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                }
                else if (inputKey.Key != ConsoleKey.Backspace)
                {
                    input.Append(inputKey.KeyChar);
                    Console.Write(asterisk + "*");
                }
            }

            return input.ToString();
        }
            public static void PrintMessage(string message, bool success = true) 
            {
                if(success)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else 
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                }

                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.White;

            //insert a method call for the next screen or next step  (enter)
            PressEnterToContinue();
            }

        public static string GetUserInput (string prompt)
        {
            Console.WriteLine($"Enter {prompt}");
            return Console.ReadLine();
        }

        public static void PrintDotAnimation (int timer = 10)
        {
            for(int i = 0; i < timer; i++) 
            {
                Console.Write(".");
                Thread.Sleep(200); // Thread means a linear process that's being executed
            }
            Console.Clear();
        }

        public static void PressEnterToContinue()
        {
            Console.WriteLine("\n\nPress Enter to Continue... \n");
            Console.ReadLine();
        }
        


    }
}

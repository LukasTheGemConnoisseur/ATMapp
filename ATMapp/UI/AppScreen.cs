using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMapp.UI
{
    public class AppScreen
    {
        internal static void Welcome()
        {
            // Clears the console screen
            Console.Clear();

            // set the title of the console window
            Console.Title = " Bitcoin ATM App ";

            // Sets the text color or foreground color to white
            Console.ForegroundColor = ConsoleColor.White;

            // Set the welcome message
            Console.WriteLine("\n\n --------------- Welcome To my Bitcoin ATM APP --------------- \n\n");

            // prompt the user to insert ATM card
            Console.WriteLine("Please insert your ATM card");
            Console.WriteLine("Note: The ATM machine will accept and validate " +
                "a physical ATM card, read the card number and validate it.");

            // We need to add a functionality where the user can continue to the next step
            Utility.PressEnterToContinue();
        }

        //Create a method that validates the user's account



        // Create a method for the LoginProcess

        internal static void LoginProgress()
        {
            Console.WriteLine("\nChecking card number and PIN...");
            //add an animation functionality to show the application is loading/checking
            Utility.PrintDotAnimation();
        }

        internal static void PrintLockScreen()
        {
            Console.Clear();
            //write a message stating that the account has been locked
            Utility.PrintMessage(" Your Account is locked. Please go to the nearest branch to unlock your account. Thank you.", true);

            Environment.Exit(1);
        }





    }
}

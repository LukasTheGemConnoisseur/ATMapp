using ATMapp.Domain.Interfaces;
using ATMapp.Domain.Modal;
using ATMapp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMapp.App
{
    public class ATMApp : IUserLogin
    {
        // Declare variables

        private List<UserAccounts> userAccountList;
        private UserAccounts selectedAccounts;  // Inheritance
        int withdrawalAmount = 0;

        // Create the data for the user accounts

        public void SetUpUserAcctsData() // initialize user acount information 
        {
            userAccountList = new List<UserAccounts>
            {
                new UserAccounts{Id=1, FullName="Christina Beckford", AccountNumber=123456, CardNumber=321321, CardPin=123123, AccountBalance=50000.00m, isLocked=false},
                new UserAccounts{Id=2, FullName="Brittany Turner", AccountNumber=456789, CardNumber=123123, CardPin=456456, AccountBalance=60000.00m, isLocked=false},
                new UserAccounts{Id=3, FullName="Walter Reed", AccountNumber=789789, CardNumber=456456, CardPin=789789, AccountBalance=100000.00m, isLocked=false}
            };
        }


        // create a function that focuses on checking the user's card number and password

        public void CheckUserCardNumAndPassword()
        {
            bool isCorrectLogin = false;

            while (!isCorrectLogin)
            {
                UserAccounts inputAccount = AppScreen.userLoginForm();

                AppScreen.LoginProgress();

                foreach (UserAccounts account in userAccountList) //Goes through each item in the useraccountList list
                {
                    if (inputAccount.CardNumber.Equals(account.CardNumber) && inputAccount.CardPin.Equals(account.CardPin)) //This checks if the given account number and 
                        // pin are correct, if they are not this if statement is skipped.
                    {
                        selectedAccounts = account; // the selectedaccounts variable is now set to the correct account (since it went through the pin and number check previously)
                        selectedAccounts.totalLogin++;

                        if (selectedAccounts.isLocked || selectedAccounts.totalLogin > 3)
                        {
                            AppScreen.PrintLockScreen();
                        }
                        else
                        {
                            selectedAccounts.totalLogin = 0;
                            isCorrectLogin = true;
                            break;
                        }
                    }
                }

                if (!isCorrectLogin) // This only gets used if the pin and card number given by user are incorrect
                {
                    Utility.PrintMessage("\nInvalid card number or PIN.", false);

                    foreach (UserAccounts account in userAccountList)
                    {
                        account.isLocked = account.totalLogin == 3;
                        if (account.isLocked)
                        {
                            AppScreen.PrintLockScreen();
                        }
                    }

                    Console.Clear();
                }
            }
        }

        public void ViewBalance()
        {
            if (selectedAccounts != null && !selectedAccounts.isLocked)
            {
                string userAnswer = Utility.GetUserInput("\nWould you like to see your balance? Enter Y for yes and N for no.");

                if (userAnswer.ToLower() == "y")
                {
                    Utility.PrintMessage($"\nYour balance is: ${selectedAccounts.AccountBalance}", true);
                }
                else
                {
                    Console.Clear();
                    Withdrawal();
                }

            }
        }

        public bool Withdrawal()
        {
            if (selectedAccounts != null && !selectedAccounts.isLocked)
            {
                string userAnswer = Utility.GetUserInput("\nWould you like to make a withdrawal? Enter Y for yes and N for no.");

                if (userAnswer.ToLower() == "y")
                {
                    withdrawalAmount = Convert.ToInt32(Utility.GetUserInput("\nHow much would you like to withdraw? Enter the amount in whole numbers."));

                    if(withdrawalAmount <= selectedAccounts.AccountBalance)
                    {
                        selectedAccounts.AccountBalance -= withdrawalAmount;
                        Utility.PrintMessage($"\nYou have succesfully withdrawn ${withdrawalAmount} from your account.", true);
                        

                        for (int i = 0; i < userAccountList.Count; i++)
                        {
                            if (userAccountList[i].CardNumber == selectedAccounts.CardNumber)
                            {
                                userAccountList[i].AccountBalance = selectedAccounts.AccountBalance;
                                break;
                            }
                        }

                        PrintReceipt();
                        return true; // Withdrawal successful
                        
                    }
                    else
                    {
                        Utility.PrintMessage($"\nYou do not have sufficient funds to withdraw ${withdrawalAmount} from your account. Your balance is: ${selectedAccounts.AccountBalance}", false);
                        
                        string secondUserAnswer = Utility.GetUserInput("\nIf you'd like to withdraw a different amount, enter Y for yes and N for no.");
                        if (secondUserAnswer.ToLower() == "y")
                        {
                            return Withdrawal(); // Recursive call to withdraw a different amount
                        }
                        else
                        {
                            Console.Clear();
                            CheckUserCardNumAndPassword();
                            return false; // Withdrawal unsuccessful
                        }
                    }

                }
                else
                {
                    Console.Clear();
                    PrintReceipt();
                }
            }
            return false; // Withdrawal unsuccessful
        }

        public void PrintReceipt()
        {
            string userAnswer = Utility.GetUserInput("\nWould you like a receipt? Enter Y for yes, and N for no.");
            if (userAnswer.ToLower() == "y")
            {
                Console.Clear();
                Console.WriteLine($"\n\n\n             Bitcoin ATM App             " +
                    $"\n\nCARD#_{selectedAccounts.CardNumber}" + "\nATM IL0001" + "\n................................................."
                    + "\nBalance Inquiry " + $"\nAvailable Balance ${selectedAccounts.AccountBalance}" +
                    $"\nWithdrawals ${withdrawalAmount}" + "\n\n\n\n\n................................................."
                    + "\nThank you for using the Bitcoin ATM APP!" + "\nSee you next time!");
                Utility.PressEnterToContinue();

                Console.Clear();
                AppScreen.Welcome();
                CheckUserCardNumAndPassword();
                Welcome();
                ViewBalance();
                Withdrawal();
                PrintReceipt();
            }
            else if(userAnswer.ToLower() == "n")
            {
                Console.WriteLine("\nNo receipt option chosen." + "\nUntil next time!");
                Utility.PressEnterToContinue();

                Console.Clear();
                AppScreen.Welcome();
                CheckUserCardNumAndPassword();
                Welcome();
                ViewBalance();
                Withdrawal();
                PrintReceipt();

            }
            else
            {
                Console.WriteLine("\nReceipt not available. Please inform store clerk.");
                Utility.PressEnterToContinue();
                Console.Clear();
                AppScreen.Welcome();
                CheckUserCardNumAndPassword();
                Welcome();
                ViewBalance();
                Withdrawal();
                PrintReceipt();
            }

        }



        public void Welcome()
        {
            Console.Clear();
            Console.WriteLine($"Welcome back, {selectedAccounts.FullName}");
            Utility.PressEnterToContinue();
        }



    }
}

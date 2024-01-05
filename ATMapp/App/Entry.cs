using ATMapp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMapp.App
{
     class Entry // Starting point of the application
    {
        static void Main(string[] args)
        {
            AppScreen.Welcome();
            ATMApp aTMApp = new ATMApp();
            aTMApp.SetUpUserAcctsData();

            while (true)
            {
                
                aTMApp.CheckUserCardNumAndPassword();
                aTMApp.Welcome();
                aTMApp.ViewBalance();
                aTMApp.Withdrawal();
                aTMApp.PrintReceipt();
            }

        }


    }
}

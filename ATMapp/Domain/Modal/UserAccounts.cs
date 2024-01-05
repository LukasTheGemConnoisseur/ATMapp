using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMapp.Domain.Modal
{
    public class UserAccounts
    {
        public int Id { get; set; }  // get will retrieve the value, the set will set the value for the variable
        public long CardNumber { get; set; }
        public int CardPin { get; set; }
        public long AccountNumber { get; set; }
        public string FullName { get; set; }
        public decimal AccountBalance { get; set; }
        public int totalLogin { get; set; }
        public bool isLocked { get; set; }



    }
}

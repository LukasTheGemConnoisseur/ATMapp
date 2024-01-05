using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMapp.Domain.Interfaces
{
    public interface IUserLogin  // interface is a contract file that shows all the mothods that are allowed to be used
    {
        void CheckUserCardNumAndPassword();
    }
}

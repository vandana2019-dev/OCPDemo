using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPLibrary
{
    public class PersonModel2 : IApplicantModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // public EmployeeType TypeOfEmployee { get; set; } = EmployeeType.Staff;
        public IAccounts2 AccountProcessor { get; set; } = new Accounts2();
    }
}

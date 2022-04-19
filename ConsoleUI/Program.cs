using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCPLibrary;
 

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // We need to identify a way that Employee is a manager
            // we need to add additional property to the EmployeeModel - IsManager, it is fine it is in the development process
            // once it goes to the Production, it should be change if there is a bug

            //1st approach add an enum, TypeOfEmployee Property to the existing person
            List<PersonModel> applicants = new List<PersonModel>
            {
                new PersonModel {FirstName = "Tim", LastName = "Corey"},
                new PersonModel {FirstName = "Sue", LastName = "Storm", TypeOfEmployee = EmployeeType.Manager},
                new PersonModel {FirstName = "Nancy", LastName = "Roman", TypeOfEmployee = EmployeeType.Executive},
            };


            List<EmployeeModel> employees = new List<EmployeeModel>();
            Accounts accountProcessor = new Accounts();

            foreach(var person in applicants)
            {
                employees.Add(accountProcessor.Create(person));
            }

            foreach(var emp in employees)
            {
                Console.WriteLine($"{ emp.FirstName } { emp.LastName } : {emp.EmailAddress } IsManager : {emp.IsManager} IsExecutive : {emp.IsExecutive}");
            }

            Console.WriteLine();
            Console.WriteLine("***** Extending the class using interfaces **");
            Console.WriteLine();

            // 2nd approach is by making changes by adding interfaces, we don't change the Person Model at all,
            // instead we add new models

            List<IApplicantModel> applicants2 = new List<IApplicantModel>
            {
                 //1st approach add an enum
                new PersonModel2 {FirstName = "Tim", LastName = "Corey"},
                //new PersonModel2 {FirstName = "Sue", LastName = "Storm"},
                new ManagerModel {FirstName = "Sue", LastName = "Storm"},
                //new PersonModel2 {FirstName = "Nancy", LastName = "Roman"},
                new ExecutiveModel {FirstName = "Nancy", LastName = "Roman"},
            };

            // To get the Managers - add a new class ManagerModel, which implements the IApplicantModel
            List<EmployeeModel> employees2 = new List<EmployeeModel>();

            foreach (var person in applicants2)
            {
                // the create method is different based on the user type
                employees2.Add(person.AccountProcessor.Create(person));
            }

            foreach (var emp in employees2)
            {
                Console.WriteLine($"{ emp.FirstName } { emp.LastName } : {emp.EmailAddress } IsManager : {emp.IsManager} IsExecutive : {emp.IsExecutive}");
            }

            Console.ReadLine();
        }
    }
}

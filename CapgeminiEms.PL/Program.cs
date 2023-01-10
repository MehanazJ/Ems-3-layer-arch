using Capgemini.EMS.BusinessLayer;
using Capgemini.EMS.Entities;
using Capgemini.EMS.Exceptions;
using System;

namespace CapgeminiEms.PL
{
    class Program
    {
        //ask user
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1.Add Employee 2.Employee List 3.Update the employee 4.Delete Employee  5.Exit");
                Console.WriteLine("Enter your choice :");
                string input = Console.ReadLine();
               
                //validation
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid input");
                    return;

                }
                
                switch (choice)
                {
                    case 1:
                        AddEmployee();
                      
                        break;
                    
                    case 2:
                        EmployeeList();

                        break;
                    case 3:
                        UpdateEmployee();
                       break;

                    case 4:
                        DeleteEmployee();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            }
        }

        

        //case 1
        //add employee
        private static void AddEmployee()
        {
            
            Employee newEmployee = new Employee();
            /*Console.WriteLine("Enter employee Id: ");
            string input = Console.ReadLine();*/
            string input;
            int empId;
            DateTime dateOfJoining;
            do
            {
                Console.WriteLine("Enter employee Id: ");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out empId));
            newEmployee.Id = empId;

            do
            {

                Console.WriteLine("Enter employee name : ");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));
            newEmployee.Name = input;

            do

            {
                Console.WriteLine("Enter the date of joining :" );
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out dateOfJoining));
            newEmployee.DateOfJoining = dateOfJoining;

            //call BL 
            try
            {
                bool isAdded = EmployeeBL.Add(newEmployee);
                if (isAdded)
                {
                    Console.WriteLine("Employee Added Successfully");
                }
                else
                {
                    Console.WriteLine("Employee add failed ");
                }
            }
            catch (EMSException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }

        //case 2
        //get list
        private static void EmployeeList()
        {
            var list = EmployeeBL.GetList();
            Console.WriteLine("Employee List : ");
            foreach (var emp in list)
            {
                //if we only write emp it will display only the class hence we implemented tostring in Employee class(entity layer) in order to get what the output in our desired format
                Console.WriteLine(emp.ToString());
            }

        }

        //case 3
        //update employee
        private static void UpdateEmployee()
        {
            //emp id
            string input;
            int empId;
            DateTime dateOfJoining;
            do
            {
                Console.WriteLine("Enter employee Id: ");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out empId));

            //emp id - check
            var existingEmployee = EmployeeBL.GetById(empId);
            if (existingEmployee == null)
            {
                Console.WriteLine("Employee does not exist");
                return;
            }

            //name/doj
            Employee newEmp = new Employee();
            newEmp.Id = empId;
            do
            {

                Console.WriteLine("Enter employee name : ");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));
            newEmp.Name = input;

            do
            {
                Console.WriteLine("Enter the date of joining :");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out dateOfJoining));
            newEmp.DateOfJoining = dateOfJoining;

            //update - dal
            var isUpdated = EmployeeBL.Update(newEmp);
            //after updating


            if (isUpdated)
            {
                Console.WriteLine("Employee updated Successfully");
            }
            else
            {
                Console.WriteLine("Employee update failed ");
            }

        }

        //case 4 
        //deleting the employee

        private static void DeleteEmployee()
        {
            Employee newEmp = new Employee();
            //getting employee id to delete
            string input;
            int empId;
            //DateTime dateOfJoining;
            do
            {
                Console.WriteLine("Enter employee Id: ");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out empId));
            newEmp.Id = empId;

            var existingEmployee = EmployeeBL.GetById(empId);
            if (existingEmployee == null)
            {
                Console.WriteLine("Employee does not exist");
                return;
            }

            //deleting - dal
            var isDeleted = EmployeeBL.Delete(newEmp);
            //after deleting


            if (isDeleted)
            {
                Console.WriteLine("Deleted succesfully");
            }
            else
            {
                Console.WriteLine("Employee deleting failed ");
            }

        }



    }
}

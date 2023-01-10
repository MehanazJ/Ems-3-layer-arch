using Capgemini.EMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capgemini.EMS.DataAccessLayer
{
    public class EmployeeDal
    {
        static List<Employee> list = new List<Employee>();
        //case 1
        //add employee
        public static bool Add(Employee emp)
        {
           
            list.Add(emp);
            return true;
        }

        //case 2
        //getting list
        public static List<Employee> GetList()
        {
            return list;
        }

        //case 3
        //checking whether exists before updating
        
        
        /* public static bool isExists(int id)
         {
             //list.contains we cannot use so we use where
             //firstordefault will return only one employee when it  is found
             var emp = list.Where(e => e.Id == id).FirstOrDefault();
            if(emp == null)
             {
                 return false;
             }
             return true;
         }*/

        //instead of returning the id like above we are using the below to return the enture object itself
        public static Employee GetById(int id)
        {
            //list.contains we cannot use so we use where
            //firstordefault will return only one employee when it  is found
            var emp = list.Where(e => e.Id == id).FirstOrDefault();
            return emp;
        }

        // updating
        public static bool Update(Employee emp)
        {
            //get emp by id 
            var existingEmp = list.Where(e => e.Id == emp.Id).FirstOrDefault();
            //update its properties
            existingEmp.Name = emp.Name;
            existingEmp.DateOfJoining = emp.DateOfJoining;

            return true;
            //after this go to bl
        }


        
        //deleting
        public static bool Delete(Employee emp)
        {
            var deletableEmp = list.Where(e => e.Id == emp.Id).FirstOrDefault();
            bool v = list.Remove(deletableEmp);


            return v;

            //after this go to bl
        }


    }
}

using System;
using System.Collections.Generic;
using Capgemini.EMS.DataAccessLayer;
using Capgemini.EMS.Entities;
using Capgemini.EMS.Exceptions;

namespace Capgemini.EMS.BusinessLayer
{
    public class EmployeeBL
    {
        
        //case1
        //add employee


        public static bool Add(Employee emp)
        {
            //biz validations
            //throw ude
            
            if (emp.Id <= 0)
            {
                throw new EMSException("Employee id should be greater than zero ");

            }
            //call dal method
            bool isAdded = EmployeeDal.Add(emp);
            return isAdded;
        }

        //case 2
        //get list
        public static List<Employee> GetList()
        {
            var list = EmployeeDal.GetList();
            return list;

        }

       
        //case 3
        //getbyid
        public static Employee GetById(int id)
        {
            var emp = EmployeeDal.GetById(id);
            return emp;
        }

        //updating
        public static bool Update(Employee emp)
        {
            //this below update method is from dal layer
            bool isUpdated = EmployeeDal.Update(emp);
            return isUpdated;
        }

        //deleting
        public static bool Delete(Employee emp)
        {
            bool isDeleted = EmployeeDal.Delete(emp);
            return isDeleted;
        }
    }
    
}

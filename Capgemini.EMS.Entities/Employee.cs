using System;

namespace Capgemini.EMS.Entities
{
    public class Employee
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfJoining { get; set; }


        //for implementing and displaying the lists in the way we want we use Tostring


        public override string ToString()
        {
            return $"Id : {Id} , Name: {Name},DateOfJoining : {DateOfJoining.ToShortDateString()} ";
        }
    }
}

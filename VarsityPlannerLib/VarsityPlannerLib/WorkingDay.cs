using System;
using System.Collections.Generic;
using System.Text;

namespace VarsityPlannerLib
{
    public class WorkingDay // class to store self study day
    {
        public WorkingDay(DateTime workDate, double hoursWorked, Module moduleWorked) //constructor for class
        {
            this.workDate = workDate;
            this.hoursWorked = hoursWorked;
            this.moduleWorked = moduleWorked;
        }
        //attributes of class
        public DateTime workDate { get; set; }
        public double hoursWorked { get; set; }
        public Module moduleWorked { get; set; }
    }
}

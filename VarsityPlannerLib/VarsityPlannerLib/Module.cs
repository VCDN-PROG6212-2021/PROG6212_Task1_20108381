using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace VarsityPlannerLib
{
    public class Module// class for a module
    {
        public Module(string moduleCode, string moduleName, int moduleCredits, int moduleWeeklyHours) //constructor for module object
        {
            code = moduleCode;
            name = moduleName;
            credits = moduleCredits;
            weeklyHours = moduleWeeklyHours;
        }
        // attributes of class
        public string code { get; set; }
        public string name { get; set; }
        public int credits { get; set; }
        public int weeklyHours { get; set; }

        public double selfstudy(int semWeeks) // returns self study hours per week for a module based on POE Document
        {
            double output = (double)(credits * 10) / semWeeks - weeklyHours;
   
            return output;
            
        }

        public string display() // displays a modules details
        {
           return $"{code}\t{credits}\t{weeklyHours}";
        }
    }
}

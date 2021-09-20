using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace VarsityPlannerLib
{
    public class WorkingDays//list worker for list of WorkingDay
    {
        public WorkingDays(List<WorkingDay> studentWorkingDays)//constructor for class
        {
            this.studentWorkingDays = studentWorkingDays;
        }

        public List<WorkingDay> studentWorkingDays { get; set; }//atribute of list of WorkingDay

  
       
        public Tuple<double, double> returnSelfStudy(string modCode) // method that calculates and returns hours done previous in weeks and hours done this week respectively
        {
            Tuple<double, double> output = new Tuple<double,double>(0,0); //Tuple to store hours worked before week, hours panned to work this week

            // Gets the Calendar instance associated with a CultureInfo.
            CultureInfo myCI = new CultureInfo("en-ZA");
            Calendar myCal = myCI.Calendar;

            // Gets the DTFI properties required by GetWeekOfYear.
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            //Adapted from: https://docs.microsoft.com/en-us/dotnet/api/system.globalization.calendar.getweekofyear?view=net-5.0
            // Author: Microsoft
            //Date accessed 20 August

            int thisWeek = myCal.GetWeekOfYear(DateTime.Now, myCWR, myFirstDOW);//gets week in year of this week
            //make values for work done in previous weekns and work done this week
            double hoursThisWeek = 0;
            double hoursWorked = 0;

            List<WorkingDay> temp = studentWorkingDays.FindAll(x => x.moduleWorked.code == modCode);//use linq to get all workingdays for specified module
            foreach (WorkingDay item in temp)
            {
                if ((myCal.GetWeekOfYear(item.workDate, myCWR, myFirstDOW)< thisWeek)) // if week in year of work is less that this week in the year then work was done before this week
                {
                    hoursWorked += item.hoursWorked;//add hours done to hours done before this week
                }
                if (myCal.GetWeekOfYear(item.workDate, myCWR, myFirstDOW) == thisWeek) // if week of work is this week
                {
                    hoursThisWeek += item.hoursWorked;//add hours done to this weeks hours
                }
            }
            
            output = new Tuple<double, double>(hoursWorked, hoursThisWeek);
              
            return output;
        }

        public void addWorkingDay(WorkingDay input) //adds a working day to list
        {
            studentWorkingDays.Add(input);
        }

   

        public string display(string moduleCode) // displays all working days for a module using LINQ
        {
            string output = "Date(DD/MM/YYYY)\tHours";
            List<WorkingDay> temp = studentWorkingDays.FindAll(x => x.moduleWorked.code == moduleCode);
            if (temp.Count>0)
            {
                foreach (WorkingDay item in temp)
                {
                    output += $"\n{item.workDate.ToString("dd / MM / yyyy")}\t\t{item.hoursWorked}";
                }
            }
            else
            {
                output = "No work added for this module yet";
            }
            return output;
        }
    }
}

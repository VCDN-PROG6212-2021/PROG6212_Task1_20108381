using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;

namespace VarsityPlannerLib
{
    public class SemesterWork // class to store semester and work done for semester
    {
        //attributes for class
        public Semester studentSem { get; set; }
        public WorkingDays studentWorkingDays { get; set; }

        public SemesterWork(Semester studentSem, WorkingDays studentWorkingDays)//constructor for class
        {
            this.studentSem = studentSem;
            this.studentWorkingDays = studentWorkingDays;
        }

        public string returnWork(string modCode) // dynamically calculates to work data for a module. If there was extra or defecit work in previous weeks, that is accounted for
        {
            string output = ""; 
            Module temp = studentSem.semModules.returnModule(modCode);//get module that work is being calculated for
            Tuple<double, double> selfStudy = studentWorkingDays.returnSelfStudy(modCode); // call method that returns tuple with item 1 being work done before this week and item 2 being work done this week

                double hoursThisWeek = (temp.selfstudy(studentSem.noWeeks) * studentSem.noWeeks - selfStudy.Item1) / weeksLeft();//calculate hours done this week
                double hoursleftThisWeek = hoursThisWeek - selfStudy.Item2; //calculate hours done this week
                //add relevant values to output string
                output += "Total Hours Completed:\t" + selfStudy.Item1;
                output += "\nTotal Hours this week:\t" + Math.Round(hoursThisWeek);
                output += "\nHours Done this week:\t" + selfStudy.Item2;
                output += "\nHours left this Week:\t" + Math.Round(hoursleftThisWeek);
               
            return output;
        }



        public int weeksLeft()//calculates weeks left for semester
        {


            // Gets the Calendar instance associated with a CultureInfo.
            CultureInfo myCI = new CultureInfo("en-ZA");
            Calendar myCal = myCI.Calendar;

            // Gets the DTFI properties required by GetWeekOfYear.
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            //Adapted from: https://docs.microsoft.com/en-us/dotnet/api/system.globalization.calendar.getweekofyear?view=net-5.0
            // Author: Microsoft
            //Date accessed 20 August

            int thisWeek = myCal.GetWeekOfYear(DateTime.Now, myCWR, myFirstDOW);//get this week in year

            int semStartWeek = myCal.GetWeekOfYear(studentSem.startDate, myCWR, myFirstDOW);//get week of start date of semester
            int weeksLeft = 0;
            if (thisWeek>semStartWeek) //if current week if after sem starts
            {
                weeksLeft = studentSem.noWeeks - (thisWeek - semStartWeek) - 1;
            }
            else
            {
                weeksLeft = studentSem.noWeeks;
            }
            return weeksLeft ;//calculate and return weeks left in semester
        }

    }
}

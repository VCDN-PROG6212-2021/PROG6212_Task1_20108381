using System;
using System.Collections.Generic;
using System.Text;

namespace VarsityPlannerLib
{
    public class Semester // class to store details for semester
    {
        public Semester(int noWeeks, DateTime startDate, ModuleList semModules)//constructor for class
        {
            this.noWeeks = noWeeks;
            this.startDate = startDate;
            this.semModules = semModules;
        }
        //atributes for clas
        public int noWeeks { get; set; }
        public DateTime startDate { get; set; }
        public ModuleList semModules { get; set; }

        public string semDetails()// returns details of semester, without modules as modules has a display method
        {
            string date = startDate.ToString("dd.MM.yyyy");
            return $"Semester Weeks: {noWeeks}\nSemester Start Date: {date}";
        }
    }
}

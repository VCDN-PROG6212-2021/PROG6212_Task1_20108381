using System;
using System.Collections.Generic;
using System.Text;
using VarsityPlannerLib;
namespace VarsityPlannerApp
{
    class CurrentDetails
    {
       public static SemesterWork studentDetails = new SemesterWork(new Semester(0,DateTime.Now, new ModuleList(new List<Module>())), new WorkingDays(new List<WorkingDay>()));//create static object for student details and set to default values
       
    }
}

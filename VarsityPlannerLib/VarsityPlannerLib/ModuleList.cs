using System;
using System.Collections.Generic;
using System.Text;


namespace VarsityPlannerLib
{
    public class ModuleList // list worker class for list of modules
    {
        public ModuleList(List<Module> semModules)// constructor for class
        {
            this.semModules = semModules;
        }

        public List<Module> semModules { get; set; } // attribute of list of modules for class

        public bool modExists() // checks if there is a module in the list or if no modules exist and list is empty
        {
            
            return (semModules.Count > 0);
        }
        public void delete(string code)//deletes a module object from list using LINQ
        {
        
            semModules.RemoveAll(x => x.code == code);
           
        }

        public void addModule(Module input) // adds module to list
        {
            semModules.Add(input);
        }

        public Module returnModule(string code) // returns module from list based of code given. Used for making work day where module for work is required
        {        
            return semModules.Find(x => x.code == code);
        }


        public string displayModules()// displays all modules in list in a string using LINQ
        {
            string output = "Code\t\tCredits\tHours a week"; // column headers based on module code structure and lenght of VC for module eg. "PROG6221"
     
            semModules.ForEach(x => output += "\n" + x.display());
            return output;
        }


   
    }
}

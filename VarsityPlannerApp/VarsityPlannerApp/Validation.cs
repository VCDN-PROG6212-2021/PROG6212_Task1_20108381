using System;
using System.Collections.Generic;

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VarsityPlannerApp
{
    class Validation
    {
       

        public static string alterInt(string input)//Alters input from label so its format can be parsed to a string without error
        {
            string output = input.Replace(".", ",");
            output.Replace(" ", "") ;
            return output;
        }



        public static bool validateNumWeeks(Canvas output, string input, SolidColorBrush normalColour)
        {
            bool value = false;
            SolidColorBrush error = new SolidColorBrush(Colors.Red);
            //Adapted From: https://docs.microsoft.com/en-us/dotnet/desktop/wpf/graphics-multimedia/wpf-brushes-overview?view=netframeworkdesktop-4.8
            // Date accessed 18 June
            //Author: Microsoft
            int temp;
            input.Replace(" ", ""); //eliminates spaces so we  can parse to double
            string edited = input.Replace(".", ",");//replaces . with , so we can parse to double

            if (edited != "")
            {
                if (Int32.TryParse(edited, out temp)) //checks input is double
                {
                    if (temp >0) // checks that value is not negative as you do not get a negative currency
                    {
                        if (temp <= 52)
                        {
                            output.Background = normalColour;
                            ToolTipService.SetToolTip(output, "All correct"); //adds tool tip to txb for user to know error
                                                                              //Adapted From: https://stackoverflow.com/questions/11925113/how-add-and-show-tooltip-textbox-wpf-if-textbox-not-empty
                                                                              // Date accessed 18 June
                                                                              //Author: Matthijs
                            value = true;
                        }
                        else
                        {
                            output.Background = error;
                            ToolTipService.SetToolTip(output, "Value must be less than or equal to 52"); //adds tool tip to txb for user to know error

                        }
                    }
                    else
                    {
                        output.Background = error;
                        ToolTipService.SetToolTip(output, "Value must be greater than 0"); //adds tool tip to txb for user to know error
                    }
                }
                else
                {

                    output.Background = error;
                    ToolTipService.SetToolTip(output, "Value is not a valid number."); //adds tool tip to txb for user to know error
                }
            }
            else
            {
                output.Background = error;
                ToolTipService.SetToolTip(output, "Please enter a value!"); //adds tool tip to txb for user to know error  
            }

            return value;
        }
     

    }
}

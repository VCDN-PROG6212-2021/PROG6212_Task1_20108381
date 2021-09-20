using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VarsityPlannerLib;

namespace VarsityPlannerApp
{
    /// <summary>
    /// Interaction logic for ModulePage.xaml
    /// </summary>
    public partial class ModulePage : Page
    {
        public ModulePage()
        {
            InitializeComponent();

            populateCMB();
            if (CurrentDetails.studentDetails.studentSem.semModules.modExists() == true)
            {
                txbDetails.Text = CurrentDetails.studentDetails.studentSem.semModules.displayModules();
              //  List<Module> tempMod = CurrentDetails.studentDetails.studentSem.semModules.returnList();
               
            }
            else
            {
                txbDetails.Text = "No Modules added yet";
            }
        }
        SolidColorBrush backColour = new SolidColorBrush(Color.FromRgb(0, 122, 204));//set rgb value of backcolour theme for for form to brush
        bool code = false;
        bool name = false;
        bool credits = false;
        bool classWeeks = false;
        
        public List<string> modCodes { get; set; }
        public void populateCMB()
        {
            cmbModules.Items.Clear();
            List<Module> temp = CurrentDetails.studentDetails.studentSem.semModules.semModules;
            temp.ForEach(x => cmbModules.Items.Add(x.code));

        }

        private bool validateInput()
        {
            bool output = true;
            List<bool> allInput = new List<bool> { code, name, credits, classWeeks };
            foreach (bool item in allInput)
            {
                if (item == false)
                {
                    output = false;
                    break;
                }
            }
            return output;

        }

       
        private void resetInputs()
        {
            txbCode.Text = "Module Code";
            cvCode.Background = backColour;
            txbName.Text = "Module Name";
            cvName.Background = backColour;
            txbCredits.Text = "Module Credits";
            cvCredits.Background = backColour;
            txbWeeklyHours.Text = "Class Hours per week";
            cvWeeklyHours.Background = backColour;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void txbDetails_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txbCode_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txbCode.Text == "Module Code")
            {
                txbCode.Text = "";
                txbCode.FontStyle = FontStyles.Normal;
            }
        }

        private void txbCode_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txbCode.Text == "")
            {
                txbCode.Text = "Module Code";
                txbCode.FontStyle = FontStyles.Italic;
            }
        }

        private void txbName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txbName.Text == "Module Name")
            {
                txbName.Text = "";
                txbName.FontStyle = FontStyles.Normal;
            }
        }

        private void txbName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txbName.Text == "")
            {
                txbName.Text = "Module Name";
                txbName.FontStyle = FontStyles.Italic;
            }
        }

        private void txbCredits_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txbCredits.Text == "Module Credits")
            {
                txbCredits.Text = "";
                txbCredits.FontStyle = FontStyles.Normal;
            }
        }

        private void txbCredits_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txbCredits.Text == "")
            {
                txbCredits.Text = "Module Credits";
                txbCredits.FontStyle = FontStyles.Italic;
            }

        }

        private void txbWeeklyHours_LostFocus(object sender, RoutedEventArgs e)
        {

            if (txbWeeklyHours.Text == "")
            {
                txbWeeklyHours.Text = "Class Hours per week";
                txbWeeklyHours.FontStyle = FontStyles.Italic;
            }

        }

        private void txbWeeklyHours_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txbWeeklyHours.Text == "Class Hours per week")
            {
                txbWeeklyHours.Text = "";
                txbWeeklyHours.FontStyle = FontStyles.Normal;
            }

        }

        private void txbWeeklyHours_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.IsLoaded) //text changed events will run even when text is set in xaml so here we ensure the page is completely loaded
            {

                classWeeks = Validation.validateNumWeeks(cvWeeklyHours, txbWeeklyHours.Text, backColour);
                
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentDetails.studentDetails.studentSem.semModules.modExists() == true)
            {
                if (cmbModules.SelectedIndex > -1)
                {
                    string code = cmbModules.Text;
                    CurrentDetails.studentDetails.studentSem.semModules.delete(code);
                    populateCMB();
                    cmbModules.SelectedIndex = -1;
                    if (CurrentDetails.studentDetails.studentSem.semModules.modExists() == true)
                    {
                        txbDetails.Text = CurrentDetails.studentDetails.studentSem.semModules.displayModules();
                       
                    }
                    else
                    {
                        txbDetails.Text = "No Modules added yet";
                        cmbModules.Items.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a module code to delete that module", "No Value Selected", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                MessageBox.Show("Please make a module before trying to remove one", "No Modules", MessageBoxButton.OK, MessageBoxImage.Error);

            }



        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (validateInput() == true)
            {
                string code = txbCode.Text.Trim();
                string name = txbName.Text.Trim();
                int credit = Int32.Parse(Validation.alterInt(txbCredits.Text));
                int weeks = Int32.Parse(Validation.alterInt(txbWeeklyHours.Text));
                Module newMod = new Module(code, name, credit, weeks);
                CurrentDetails.studentDetails.studentSem.semModules.addModule(newMod);
                txbDetails.Text = CurrentDetails.studentDetails.studentSem.semModules.displayModules();
                populateCMB();
                resetInputs();

            }
            else
            {
                MessageBox.Show("Incorrect format for number of weeks or no values inputted", "Input incorrect", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void txbCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.IsLoaded) //text changed events will run even when text is set in xaml so here we ensure the page is completely loaded
            {


                if (txbName.Text == "")
                {
                    code = false;
                }
                else
                {
                    code = true;
                }


            }
        }

        private void txbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.IsLoaded) //text changed events will run even when text is set in xaml so here we ensure the page is completely loaded
            {

               
                if (txbName.Text == "")
                {
                    name = false;
                }
                else
                {
                    name = true;
                }

            }
        }

        private void txbCredits_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.IsLoaded) //text changed events will run even when text is set in xaml so here we ensure the page is completely loaded
            {

                credits = Validation.validateNumWeeks(cvCredits, txbCredits.Text, backColour);

            }
        }
    }
    

}



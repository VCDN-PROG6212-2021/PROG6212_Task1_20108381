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
    /// Interaction logic for WorkPage.xaml
    /// </summary>
    public partial class WorkPage : Page
    {
        public WorkPage()
        {
            InitializeComponent();
            txbDetails.Text = "";
            txbWorkDone.Text = "";
            
            datePickerWorkDay.DisplayDateStart = CurrentDetails.studentDetails.studentSem.startDate;
            populateCMB();

            datePickerWorkDay.Loaded += delegate
            {
                var textBox1 = (TextBox)datePickerWorkDay.Template.FindName("PART_TextBox", datePickerWorkDay);
                textBox1.Background = datePickerWorkDay.Background;

            }; // https://www.codeproject.com/Tips/399140/WPF-DatePicker-Background-Fix
        }
        SolidColorBrush backColour = new SolidColorBrush(Color.FromRgb(0, 122, 204));//set rgb value of backcolour theme for for form to brush
        bool hours = false;
        private void txbHours_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txbHours.Text == "Hours Worked")
            {
                txbHours.Text = "";
                txbHours.FontStyle = FontStyles.Normal;
            }
        }
        public void populateCMB()
        {
            cmbModules.Items.Clear();
            List<Module> temp = CurrentDetails.studentDetails.studentSem.semModules.semModules;
            temp.ForEach(x => cmbModules.Items.Add(x.code));

        }
        private void resetInputs()
        {
            txbHours.Text = "Hours Worked";
            cvHours.Background = backColour;
            datePickerWorkDay.SelectedDate = null; //https://stackoverflow.com/questions/3090198/reset-value-of-wpf-toolkit-datepicker-to-default-value

        }
        private void txbHours_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txbHours.Text == "")
            {
                txbHours.Text = "Hours Worked";
                txbHours.FontStyle = FontStyles.Italic;
            }
        }

        private void txbHours_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (this.IsLoaded) //text changed events will run even when text is set in xaml so here we ensure the page is completely loaded
            {

                hours = Validation.validateNumWeeks(cvHours, txbHours.Text, backColour);

            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cmbModules.SelectedItem != null)
            {
                if (hours == true && !(datePickerWorkDay.SelectedDate == null))
                {
                    int hours = Int32.Parse(txbHours.Text);
                    DateTime newWork = (DateTime)datePickerWorkDay.SelectedDate;
                    string modCode = cmbModules.SelectedItem + "";
                    WorkingDay newWorkDay = new WorkingDay(newWork, hours, CurrentDetails.studentDetails.studentSem.semModules.returnModule(modCode));
                    CurrentDetails.studentDetails.studentWorkingDays.addWorkingDay(newWorkDay);
                    txbDetails.Text = CurrentDetails.studentDetails.studentWorkingDays.display(modCode);
                    txbWorkDone.Text = CurrentDetails.studentDetails.returnWork(modCode);
                    
                    resetInputs();
              
                }
                else
                {
                    MessageBox.Show("Incorrect format for number of weeks or no values inputted", "Input incorrect", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("You have not selected a module. Please select a Module to add work for", "No Module Selected", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void cmbModules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string modCode = cmbModules.SelectedItem + "";
            txbWorkDone.Text = CurrentDetails.studentDetails.returnWork(modCode);
            txbDetails.Text = CurrentDetails.studentDetails.studentWorkingDays.display(modCode);
        }
    }
}

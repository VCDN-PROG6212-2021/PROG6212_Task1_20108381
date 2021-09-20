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
    /// Interaction logic for SemesterPage.xaml
    /// </summary>
    public partial class SemesterPage : Page
    {
        public SemesterPage()
        {
            InitializeComponent();
            if (CurrentDetails.studentDetails.studentSem.noWeeks > 0) //if semester has weeks then object is made by user and no longer default
            {
                txbDetails.Text = CurrentDetails.studentDetails.studentSem.semDetails();
            }
            else
            {
                txbDetails.Text = "";
            }
            datePickerSemStart.Loaded += delegate
            {
                var textBox1 = (TextBox)datePickerSemStart.Template.FindName("PART_TextBox", datePickerSemStart);
                textBox1.Background = datePickerSemStart.Background;
               
            }; // https://www.codeproject.com/Tips/399140/WPF-DatePicker-Background-Fix

       }
        SolidColorBrush backColour = new SolidColorBrush(Color.FromRgb(0, 122, 204));//set rgb value of backcolour theme for for form to brush


        bool weeks = false;
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void resetInputs()
        {
            txbWeeks.Text = "Weeks in Semester";
            cvWeeks.Background = backColour;
            datePickerSemStart.SelectedDate = null; //https://stackoverflow.com/questions/3090198/reset-value-of-wpf-toolkit-datepicker-to-default-value
        }
        private void txbWeeks_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txbWeeks.Text == "")
            {
                txbWeeks.Text = "Weeks in Semester";
                txbWeeks.FontStyle = FontStyles.Italic;
            }
        }

        private void txbWeeks_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.IsLoaded) //text changed events will run even when text is set in xaml so here we ensure the page is completely loaded
            {
               
                weeks = Validation.validateNumWeeks(cvWeeks, txbWeeks.Text, backColour);
                
            }
        }

        private void txbWeeks_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txbWeeks.Text == "Weeks in Semester")
            {
                txbWeeks.Text = "";
                txbWeeks.FontStyle = FontStyles.Normal;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
                if (weeks == true && !(datePickerSemStart.SelectedDate == null))
                {
                    int weeks = Int32.Parse(Validation.alterInt( txbWeeks.Text));
                    DateTime semStart = (DateTime)datePickerSemStart.SelectedDate;
                    CurrentDetails.studentDetails.studentSem.noWeeks = weeks;
                    CurrentDetails.studentDetails.studentSem.startDate = semStart;
                    txbDetails.Text = CurrentDetails.studentDetails.studentSem.semDetails();
                    resetInputs();
                }
                else
                {
                    MessageBox.Show("Incorrect format for number of weeks or no values inputted", "Input incorrect", MessageBoxButton.OK, MessageBoxImage.Error);
                }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new SemesterPage();
        }

        public bool checkCurrentDetailsNull() //checks that semester values have been inputted and passed to Current details
        {
            bool output = true;
            if (CurrentDetails.studentDetails.studentSem.noWeeks > 0) //if semester has weeks then object is made by user and no longer default
            {
                output = false; 
            }
            return output;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);//close all open windows
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new SemesterPage();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (checkCurrentDetailsNull() == false)
            {
                MainFrame.Content = new ModulePage();
            }
            else
            {
                MessageBox.Show("Please enter your Semester Information before adding the module information for the semester", "Semester info not entered", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnWork_Click(object sender, RoutedEventArgs e)
        {
           
            if (checkCurrentDetailsNull() == false)
            {
                MainFrame.Content = new WorkPage();
            }
            else
            {
                MessageBox.Show("Please enter your Semester Information before adding the work information for the semester", "Semester info not entered", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnShare_Click(object sender, RoutedEventArgs e)
        {
            ShareWindow newShare = new ShareWindow();//opens share window
            newShare.Show();//shows it
        }
    }
}

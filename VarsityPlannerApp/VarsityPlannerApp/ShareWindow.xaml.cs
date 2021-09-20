using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace VarsityPlannerApp
{
    /// <summary>
    /// Interaction logic for ShareWindow.xaml
    /// </summary>
    public partial class ShareWindow : Window
    {
        public ShareWindow()
        {
            InitializeComponent();
            output = CurrentDetails.studentDetails.studentSem.semDetails() + "\n"
            + CurrentDetails.studentDetails.studentSem.semModules.displayModules() ;
            CurrentDetails.studentDetails.studentSem.semModules.semModules.ForEach(x => output += "\n" + x.code +"Work Details\n" + CurrentDetails.studentDetails.studentWorkingDays.display(x.code));
        }
        string output = ""; 
        private void BtnTxt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(output);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, output);
            ////Adapted from: https://wpf-tutorial.com/dialogs/the-savefiledialog/
            ////Date Accessed: 22 June
            //// Author: wpf-tutorial
            this.Close();
        }

        private void BtnWord(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word Documents|*.doc";

            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, output);
            //Adapted From:https://docs.microsoft.com/en-us/dotnet/api/microsoft.win32.filedialog.filter?view=net-5.0
            //Date Accessed: 22 June
            //Author: Microsoft
            this.Close();
        }

        private void btnEmail_Click(object sender, RoutedEventArgs e)
        {
            Email newEmail = new Email(); //open page for an email
            newEmail.Show();
            this.Close();//close current page
        }
    }
}

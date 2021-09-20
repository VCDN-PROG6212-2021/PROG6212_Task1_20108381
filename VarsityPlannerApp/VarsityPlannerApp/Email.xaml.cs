using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for Email.xaml
    /// </summary>
    public partial class Email : Window
    {
        public Email()
        {
            InitializeComponent();
            output = CurrentDetails.studentDetails.studentSem.semDetails() + "\n"
           + CurrentDetails.studentDetails.studentSem.semModules.displayModules();
            CurrentDetails.studentDetails.studentSem.semModules.semModules.ForEach(x => output += "\n" + x.code + "Work Details\n" + CurrentDetails.studentDetails.studentWorkingDays.display(x.code));

        }
        string output = "";
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            string recipientemail = txbUsername.Text + "@" + txbDomain.Text;
            var smtpClient = new SmtpClient("smtp.gmail.com") // create smtp client for gmail as company email is gmail
            {
                Port = 587,
                Credentials = new NetworkCredential("varsityplanner@gmail.com", "P@ssword!1#"), //login credentials for company email
                EnableSsl = true,
            };

            smtpClient.Send("varsityplanner@gmail.com", recipientemail, "All Semester Details", output);
            MessageBox.Show("Email sent succesfully");
            this.Close();
            //Adapted from :https://blog.elmah.io/how-to-send-emails-from-csharp-net-the-definitive-tutorial/
            //Date: 22 June
            //Author: https://elmah.io/
        }

        private void txbUsername_GotFocus(object sender, RoutedEventArgs e) //if user enters txb and placeholder txt is present
        {
            if (txbUsername.Text == "EmailExample")
            {
                txbUsername.Text = "";
                txbUsername.FontStyle = FontStyles.Normal;
            }
        }

        private void txbUsername_LostFocus(object sender, RoutedEventArgs e)//if user leaves txb having not entered anything
        {
            if (txbUsername.Text == "")
            {
                txbUsername.Text = "EmailExample";
                txbUsername.FontStyle = FontStyles.Italic;
            }
        }

        private void txbDomain_GotFocus(object sender, RoutedEventArgs e) //if user enters txb and placeholder txt is present
        {
            if (txbDomain.Text == "VarsityPlanner.co.za")
            {
                txbDomain.Text = "";
                txbDomain.FontStyle = FontStyles.Normal;
            }
        }

        private void txbDomain_LostFocus(object sender, RoutedEventArgs e)//if user leaves txb having not entered anything
        {
            if (txbDomain.Text == "")
            {
                txbDomain.Text = "VarsityPlanner.co.za";
                txbDomain.FontStyle = FontStyles.Italic;
            }
        }
    }
}

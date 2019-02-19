/*
 * Ian McTavish
 * Feb 18, 2019
 * String example, gets the meaning of a first name
 * that the user provides by getting it from a file on the internet.
 * Pulls the data from: http://www.cs.princeton.edu/introcs/data/names.csv
 */
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

namespace stringExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Global Variables
        //We don't want to do multiple calls to the same website
        //so we create only one client
        System.Net.WebClient webClient = new System.Net.WebClient();
        string allNames;

        public MainWindow()
        {
            InitializeComponent();
            //only download the file from the internet when the program starts
            allNames = webClient.DownloadString("http://www.cs.princeton.edu/introcs/data/names.csv");
        }

        private void btnGetName_Click(object sender, RoutedEventArgs e)
        {            
            //Get the name the user entered
            string nameToFind = txtInput.Text;
            //Convert it to uppercase letters
            nameToFind = nameToFind.ToUpper();
            //Find where the name is in the file
            int startOfName = allNames.IndexOf(nameToFind + ",");
            //Each line is set up like this:
            //name,meaning
            //so find the comma AFTER the name
            int endOfName = allNames.IndexOf(",", startOfName);
            //find the new line after the name
            int endOfMeaning = allNames.IndexOf("\n",endOfName);

            //output using substring to only output the information you want
            txtOutput.Text = nameToFind + " means: " + System.Environment.NewLine +
                allNames.Substring(endOfName+1, endOfMeaning - endOfName);
        }
    }
}

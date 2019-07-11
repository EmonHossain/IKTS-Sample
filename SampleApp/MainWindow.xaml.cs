using Newtonsoft.Json;
using SampleApp.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Open file button event
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            //Read json file
            string jsonObject = "";// new ProfileIO().Read();

            List<dynamic> objects = new ProfileIO().Read();
            //List<dynamic> d = new List<dynamic>();
            //Deserialize consumed string and convert it to a typed object
            if (!string.IsNullOrEmpty(jsonObject) && !string.IsNullOrWhiteSpace(jsonObject)){
                Profile profile = JsonConvert.DeserializeObject<Profile>(jsonObject);
                Debug.WriteLine(profile.WorkCentres[0]);
            }
            
            
            Debug.WriteLine(jsonObject);
            */
            ProfileWindow pw = new ProfileWindow();
            pw.Show();

        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            //ProfileWindow pw = new ProfileWindow();
            //pw.Show();

            //check file
            if(new ProfileIO().IsProfileExist())
            {
                Debug.WriteLine("Profile Exists..!!!!!!");
            }
            else
            {
                Debug.WriteLine("Profile does not Exist..!!!!!!");
            }

        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            this.cb_a.IsChecked = false;
        }

        private void WorkCentres_Checked(object sender, RoutedEventArgs e)
        {
            this.lengthTextBox.Text = ((CheckBox)sender).Content.ToString();
        }

        private void FinishComboItem_Selected(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = ((ComboBox)sender);
            ComboBoxItem cbi = (ComboBoxItem)cb.SelectedItem;
            this.lengthTextBox.Text = cbi.Content.ToString();
        }

        //Save file button event
        private void SaveProfile_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < 3; i++)
            {
                //Construct profile object
                Profile profile = new Profile();
                profile.Supplier.Add("name", "Emon");
                profile.Supplier.Add("Code", "007");
                profile.WorkCentres.AddRange(new string[] { "A", "B", "C", "D" });

                if (i == 0)
                {
                    profile.Domain = "domainXXX";
                }else if (i == 1)
                {
                    profile.Domain = "domainYYY";
                }
                else
                {
                    profile.Domain = "domainZZZ";
                }

                profile.CreatedOn = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                //JSON stringify
                string jsonObject = JsonConvert.SerializeObject(profile);
                Debug.WriteLine(jsonObject);

                //save json string to a selected directory
                new ProfileIO().Write(jsonObject);
            }
            
        }
    }
}

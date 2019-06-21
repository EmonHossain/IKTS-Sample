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

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            var a = description.Text;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {

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
    }
}

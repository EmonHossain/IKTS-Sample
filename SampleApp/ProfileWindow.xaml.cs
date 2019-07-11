using SampleApp.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace SampleApp
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public ProfileWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<dynamic> objects = new ProfileIO().Read();
            List<TreeViewItem> treeHeads = new List<TreeViewItem>();
            int flag = 0;
            string domainName = null;
            string profileName = null;

            foreach (dynamic obj in objects)
            {
                domainName = (string)obj.Domain;
                profileName = (string)obj.CreatedOn;
                if(flag == 0)
                {
                    treeHeads.Add(CreateNewTreeItemView(domainName, profileName));
                    flag = 1;
                }
                else
                {
                    bool innerFlag = true;
                    for(int i=0;i<treeHeads.Count;i++)
                    {
                        if (treeHeads[i].Header.ToString().Equals(domainName)) 
                        {
                            treeHeads[i].Items.Add(new TreeViewItem() { Header = profileName });
                            innerFlag = false;
                            break;
                        }
                    }
                    if (innerFlag)
                    {
                        treeHeads.Add(CreateNewTreeItemView(domainName, profileName));
                    }
                }
            }
            foreach(TreeViewItem item in treeHeads)
            {
                domainTree.Items.Add(item);
            }
        }

        private TreeViewItem CreateNewTreeItemView(string domain,string header)
        {
            TreeViewItem treeHead = new TreeViewItem();
            treeHead.Header = domain;
            treeHead.Items.Add(new TreeViewItem() { Header = header });
            return treeHead;
        }
    }
}

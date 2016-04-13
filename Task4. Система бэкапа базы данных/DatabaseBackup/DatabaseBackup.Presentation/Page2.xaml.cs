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

namespace DatabaseBackup.Presentation
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            selectAutentification.SelectedItem = selectAutentification.Items[0];
        }

        private string connectionString = "";
        private string username = "";
        private string password = "";

        private void RemoveText(object sender, RoutedEventArgs e)
        {
            if(InputServerData.Text == "Type the path to server...")
            {
                InputServerData.Text = "";
            }            
        }

        private void AddDescriptionToServerInput(object sender, RoutedEventArgs e)
        {
            if(InputServerData.Text == "")
            {
                InputServerData.Text = "Type the path to server...";
            }            
        }

        
        private void Combobox_Selected(object sender, SelectionChangedEventArgs e)
        {
            //string comboboxItemText = (this.selectAutentification.SelectedItem as ComboBoxItem).Content.ToString();
        }
    }
}

/*string errorText = "abvacas";
Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "DatabaseBackup"));
            File.WriteAllText($"log_{DateTime.Now.ToString("DD-MM-yyyy_HH-mm-ss")}", errorText);*/
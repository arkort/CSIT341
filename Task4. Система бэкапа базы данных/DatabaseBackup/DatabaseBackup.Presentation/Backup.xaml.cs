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
using System.Windows.Shapes;

namespace DatabaseBackup.Presentation
{
    /// <summary>
    /// Логика взаимодействия для Backup.xaml
    /// </summary>
    public partial class Backup : Window
    {
        public Backup()
        {
            InitializeComponent();
            selectAutentification.SelectedValue = selectAutentification.Items[0];
        }

        private void RemoveText(object sender, RoutedEventArgs e)
        {
            InputServerData.Text = "";
        }

        private void AddDescriptionToServerInput(object sender, RoutedEventArgs e)
        {
            InputServerData.Text = "Type the path to server...";
            
        }
    }
}

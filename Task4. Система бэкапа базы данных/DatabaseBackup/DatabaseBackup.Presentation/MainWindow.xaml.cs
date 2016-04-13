using DatabaseBackup.BLL;
using DatabaseBackup.ContractsBLL;
using System;
using System.Windows;

namespace DatabaseBackup.Presentation
{
    public partial class MainWindow : Window
    {
        private ILogic BL = new Logic();

        public MainWindow()
        {
            InitializeComponent();
        }        

        private void BackupButtonClick(object sender, RoutedEventArgs e)
        {
            Backup backupWindow = new Backup();
            backupWindow.Show();
        }

        private void RestoreButtonClick(object sender, RoutedEventArgs e)
        {
            Restore restoreWindow = new Restore();
            restoreWindow.Show();
        }        
    }
}
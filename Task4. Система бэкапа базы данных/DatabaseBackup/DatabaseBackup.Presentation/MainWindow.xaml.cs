using DatabaseBackup.BLL;
using DatabaseBackup.ContractsBLL;
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
    }
}
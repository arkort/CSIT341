using DatabaseBackup.BLL;
using DatabaseBackup.ContractsBLL;
using System.Windows;

namespace DatabaseBackup.Presentation
{
    public partial class MainWindow : Window
    {
        IBusinessLayer BL = new BusinessLayer();

        public MainWindow()
        {
            BL.Connect("...");
            BL.Backup();
            InitializeComponent();
        }
    }
}

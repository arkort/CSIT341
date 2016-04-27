using System.Windows;
using System.Windows.Controls;
using DatabaseBackup.BLL;
using DatabaseBackup.ContractsBLL;

namespace DatabaseBackup.Presentation
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private string connectionString = "";
        private string username = "";
        private string password = "";
        private ILogic logic = new Logic();

        public Page2()
        {
            InitializeComponent();
            selectAutentification.SelectedItem = selectAutentification.Items[0];
            //combobox.Items.Add();
        }

        private void GetDatabases()
        {
            var namesOfDatabases = logic.ShowDatabases(connectionString, username, password);
            foreach (var name in namesOfDatabases)
            {
                choosingDatabase.Items.Add(name);
            }
        }

        private void RemoveText(object sender, RoutedEventArgs e)
        {
            if (InputServerData.Text == "Type the path to server...")
            {
                InputServerData.Text = "";
            }
        }

        private void AddDescriptionToServerInput(object sender, RoutedEventArgs e)
        {
            if (InputServerData.Text == "")
            {
                InputServerData.Text = "Type the path to server...";
            }
        }

        private void Combobox_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (selectAutentification.SelectedItem == selectAutentification.Items[0])
            {
                usernameTextBox.IsEnabled = false;
                passwordTextBox.IsEnabled = false;
                usernameLabel.IsEnabled = false;
                passwordLabel.IsEnabled = false;
                usernameTextBox.Text = "(not required)";
                passwordTextBox.Text = "(not required)";
            }
            else
            {
                usernameTextBox.IsEnabled = true;
                passwordTextBox.IsEnabled = true;
                usernameLabel.IsEnabled = true;
                passwordLabel.IsEnabled = true;
                usernameTextBox.Text = "";
                passwordTextBox.Text = "";
            }
        }

        private void BackupButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void GettingPassword(object sender, RoutedEventArgs e)
        {
            password = passwordTextBox.Text;
        }

        private void getAccessToDatabases_Click(object sender, RoutedEventArgs e)
        {
            connectionString = InputServerData.Text;
            if (usernameTextBox.IsEnabled)
            {
                username = usernameTextBox.Text;
                password = passwordTextBox.Text;
            }

            this.GetDatabases();
        }
    }
}

/*string errorText = "abvacas";
Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "DatabaseBackup"));
            File.WriteAllText($"log_{DateTime.Now.ToString("DD-MM-yyyy_HH-mm-ss")}", errorText);*/
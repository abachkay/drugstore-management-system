using DrugstoreManagementSystem.DataAccess;
using DrugstoreManagementSystem.UI.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace DrugstoreManagementSystem.UI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            using (var context = new DrugstoreManagementSystemContext())
            {
                var userRepository = new UserRepository(context);
                var user = userRepository.GetUser(login, password);

                if (user == null)
                {
                    MessageBox.Show("Invalid user name or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var mainWindow = new MainWindow();

                    mainWindow.DataContext = new MainWindowViewModel();
                    mainWindow.Show();

                    Close();
                }
            }
        }
    }
}
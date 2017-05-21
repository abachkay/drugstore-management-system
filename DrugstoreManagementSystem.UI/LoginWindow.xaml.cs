using DrugstoreManagementSystem.Entities;
using DrugstoreManagementSystem.Repositories;
using DrugstoreManagementSystem.UI.ViewModels;
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


namespace DrugstoreManagementSystem.UI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;
            User user = _unitOfWork.UserRepository.GetUser(login, password);
            if (user == null)
            {                
                MessageBox.Show("Invalid user name or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var mainWindow = new MainWindow();
                mainWindow.DataContext = new MainWindowViewModel();                
                mainWindow.Show();
                this.Close();
            }
        }
    }

}


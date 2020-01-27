using DrugsoreManagementSystem.Common;
using DrugstoreManagementSystem.Domain;
using DrugstoreManagementSystem.UI.Commands;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DrugstoreManagementSystem.UI.ViewModels
{
    public class LoginWindowViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly IUserRepository _userRepository;
        private string _password;

        public string Username { get; set; }

        public LoginWindowViewModel(MainWindowViewModel mainWindowViewModel, IUserRepository userRepository)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _userRepository = userRepository;
        }

        public ICommand LoginCommand => new RelayCommand<Window>((window) =>
        {
            User user;
            // TODO this is for testing, uncomment in future.
            //if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(_password) ||
            //    (user = _userRepository.GetUser(Username, _password)) == null)
            //{
            //    MessageBox.Show(Constants.InvalidUserOrPassword, Constants.ErrorMessageCaption,
            //        MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //else
            {
                var mainWindow = new MainWindow
                {
                    DataContext = _mainWindowViewModel
                };

                mainWindow.Show();

                window.Close();
            }
        });

        public ICommand SetPasswordCommand => new RelayCommand<PasswordBox>((passwordBox) =>
        {
            // Password is not a dependency property, so it is not possible to use binding for it.
            _password = passwordBox.Password;
        });
    }
}
using DrugstoreManagementSystem.UI.Configuration;
using DrugstoreManagementSystem.UI.ViewModels;
using System.Windows;
using Unity;

namespace DrugstoreManagementSystem.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var loginWindowViewModel = UnityConfiguration.Container.Resolve<LoginWindowViewModel>();
            var loginWindow = new LoginWindow { DataContext = loginWindowViewModel };

            loginWindow.Show();
        }
    }
}
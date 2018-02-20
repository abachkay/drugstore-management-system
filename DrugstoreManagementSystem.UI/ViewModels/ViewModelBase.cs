using DrugstoreManagementSystem.UI.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;

namespace DrugstoreManagementSystem.UI.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        private string _areChangesSavedMessage = "Changes are saved";
        public string AreChangesSavedMessage
        {
            get => _areChangesSavedMessage;
            set => SetProperty(ref _areChangesSavedMessage, value);
        }

        private Brush _areChangesSavedMessageColor = Brushes.Green;
        public Brush AreChangesSavedMessageColor
        {
            get => _areChangesSavedMessageColor;
            set => SetProperty(ref _areChangesSavedMessageColor, value);
        }
        public ICommand ChangesMadeCommand
        {
            get
            {
                return new RelayCommand(o =>
                {
                    UpdateChangesStatus(false);
                });
            }
        }

        public void UpdateChangesStatus(bool areChangesSaved)
        {
            AreChangesSavedMessage = areChangesSaved ? "Changes are saved." : "There are unsaved changes.";
            AreChangesSavedMessageColor = areChangesSaved ? Brushes.Green : Brushes.Red;
        }
    } 
}
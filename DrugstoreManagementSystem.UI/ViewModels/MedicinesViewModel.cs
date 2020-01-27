using DrugstoreManagementSystem.DataAccess;
using DrugstoreManagementSystem.Domain;
using DrugstoreManagementSystem.UI.Commands;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows.Data;
using System.Windows.Input;

namespace DrugstoreManagementSystem.UI.ViewModels
{
    public class MedicinesViewModel : ViewModelBase
    {
        private readonly DrugstoreManagementSystemContext _context;

        public DataStateViewModel DataStateViewModel { get; set; }
        public ObservableCollection<Medicine> Medicines { get; set; }

        public ICommand ChangesMadeCommand => new RelayCommand(() =>
        {
            DataStateViewModel.IsChanged = true;
        });

        public ICommand AddNewItem => new RelayCommand(() =>
        {
            Medicines.Add(new Medicine());
            ChangesMadeCommand.Execute(null);
        });

        public ICommand DeleteItem => new RelayCommand<Medicine>((medicine) =>
        {
            Medicines.Remove(medicine);
            ChangesMadeCommand.Execute(null);
        });

        public MedicinesViewModel(DrugstoreManagementSystemContext context, DataStateViewModel dataStateViewModel)
        {
            _context = context;
            _context.Medicines.Load();
            Medicines = _context.Medicines.Local;

            DataStateViewModel = dataStateViewModel;
            dataStateViewModel.DataStateChanged += () => CollectionViewSource.GetDefaultView(Medicines).Refresh();
        }
    }
}
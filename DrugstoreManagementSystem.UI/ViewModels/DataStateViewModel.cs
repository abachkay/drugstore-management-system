using DrugstoreManagementSystem.DataAccess;
using DrugstoreManagementSystem.UI.Commands;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Windows;
using System.Windows.Input;

namespace DrugstoreManagementSystem.UI.ViewModels
{
    public class DataStateViewModel : ViewModelBase
    {
        private readonly DbContext _dbContext;

        public event Action DataStateChanged;

        private bool _isChanged;
        public bool IsChanged
        {
            get => _isChanged;
            set => SetProperty(ref _isChanged, value);
        }

        public ICommand SaveChangesCommand => new RelayCommand(() =>
        {
            try
            {
                _dbContext.SaveChanges();
                IsChanged = false;
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("You can not delete some medicines, because they are connected to some sale or supply.\nDelete those sales or supplies first, then you will be able to delete required medicines.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (DbEntityValidationException)
            {
                MessageBox.Show("Some data is not valid or empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        });

        public ICommand DiscardChangesCommand => new RelayCommand(() =>
        {
            var changedEntries = _dbContext.ChangeTracker.Entries();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.State = EntityState.Unchanged;
                        break;
                    default: break;
                }
            }

            IsChanged = false;
            DataStateChanged?.Invoke();
        });

        public DataStateViewModel(DrugstoreManagementSystemContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
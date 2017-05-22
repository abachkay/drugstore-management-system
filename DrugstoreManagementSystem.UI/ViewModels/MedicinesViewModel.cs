using DrugstoreManagementSystem.Entities;
using DrugstoreManagementSystem.Repositories;
using DrugstoreManagementSystem.UI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace DrugstoreManagementSystem.UI.ViewModels
{
    public class MedicinesViewModel: ViewModelBase
    {
        #region Private fields
        private DrugstoreManagementSystemContext _context = new DrugstoreManagementSystemContext();
        private string _areChangesSavedMessage = "Changes are saved";
        private Brush _areChangesSavedMessageColor = Brushes.Green;
        #endregion

        #region Properties
        public ObservableCollection<Medicine> Medicines { get; set; }
        public string AreChangesSavedMessage
        {
            get
            {
                return _areChangesSavedMessage;
            }
            set
            {
                SetProperty(ref _areChangesSavedMessage, value);
            }
        }
        public Brush AreChangesSavedMessageColor
        {
            get
            {
                return _areChangesSavedMessageColor;
            }
            set
            {
                SetProperty(ref _areChangesSavedMessageColor, value);
            }
        }
        public ICommand SaveChangesCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        _context.SaveChanges();
                        AreChangesSavedMessage = "Changes are saved.";
                        AreChangesSavedMessageColor = Brushes.Green;
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
            }
        }
        public ICommand DiscardChangesCommand
        {
            get
            {
                return new RelayCommand(() =>
                {            
                    var changedEntries = _context.ChangeTracker.Entries();
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
                        AreChangesSavedMessage = "Changes are saved.";
                        AreChangesSavedMessageColor = Brushes.Green;                            
                    }
                    CollectionViewSource.GetDefaultView(Medicines).Refresh(); 
                });
            }
        }
        public ICommand ChangesMadeCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    AreChangesSavedMessage = "There are unsaved changes.";
                    AreChangesSavedMessageColor = Brushes.Red;
                });
            }
        }
        public ICommand AddNewItem
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Medicines.Add(new Medicine());
                    CollectionViewSource.GetDefaultView(Medicines).Refresh();
                    ChangesMadeCommand.Execute(null);
                });
            }
        }
        
        #endregion

        #region Constructors
        public MedicinesViewModel()
        {         
            _context.Medicines.Load();
            Medicines = _context.Medicines.Local;                    
        }
        #endregion

        #region Destructors
        // Dispose context on closing
        ~MedicinesViewModel()
        {
            _context.Dispose();
        }
        #endregion
    }
}

﻿using DrugstoreManagementSystem.Entities;
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
    public class SuppliesViewModel: ViewModelBase
    {
        #region Private fields
        private DrugstoreManagementSystemContext _context = new DrugstoreManagementSystemContext();
        private string _areChangesSavedMessage = "Changes are saved";
        private Brush _areChangesSavedMessageColor = System.Windows.Media.Brushes.Green;
        private int _selectedSupplyIndex = 0;
        private Supply _selectedSupply = null;
        #endregion

        #region Properties
        public ObservableCollection<Supply> Supplies { get; set; }
        public ObservableCollection<MedicineSupplyDetail> MedicineSupplyDetails { get; set; }
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
        public int SelectedSupplyIndex
        {
            get
            {
                return _selectedSupplyIndex;
            }
            set
            {
                SetProperty(ref _selectedSupplyIndex, value);
            }
        }
        public Supply SelectedSupply
        {
            get
            {
                return _selectedSupply;
            }
            set
            {
                SetProperty(ref _selectedSupply, value);
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
                        foreach (var s in _context.Suppliers)
                        {
                            _context.Entry(s).State = EntityState.Modified;
                        }
                        foreach (var s in Supplies)
                        {                          
                            foreach (var msd in s.MedicineSupplyDetails)
                            {
                                if (_context.Entry(msd).State == EntityState.Added)
                                {
                                    msd.Medicine.Quantity += msd.Quantity;
                                    _context.Entry(msd.Medicine).State = EntityState.Modified;
                                }                               
                            }                                                    
                        }
                        _context.SaveChanges();
                        foreach (var s in Supplies)
                        {
                            if (s.SupplyTotal == 0)
                            {
                                decimal total = 0;
                                foreach (var msd in s.MedicineSupplyDetails)
                                {
                                    total += msd.Medicine.Price * msd.Quantity;
                                }
                                s.SupplyTotal = total;
                                _context.Entry(s).State = EntityState.Modified;
                            }
                        }
                        _context.SaveChanges();
                        CollectionViewSource.GetDefaultView(Supplies).Refresh();
                        AreChangesSavedMessage = "Changes are saved.";
                        AreChangesSavedMessageColor = Brushes.Green;
                    }
                    catch (DbUpdateException ex)
                    {
                        //MessageBox.Show("Some data is invalid or empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        MessageBox.Show(ex.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (DbEntityValidationException ex)
                    {
                        //MessageBox.Show("Some data is invalid or empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        MessageBox.Show(ex.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    try
                    {
                        CollectionViewSource.GetDefaultView(Supplies).Refresh();
                    }
                    catch
                    {
                        MessageBox.Show("Some fields are still editing.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
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
        public ICommand SelectionChangedCommand
        {
            get
            {
                return new RelayCommand(() =>
                {                    
                    _context.Medicines.Load();                    
                    if (SelectedSupply != null)
                    {
                        MedicineSupplyDetails = SelectedSupply.MedicineSupplyDetails;
                        OnPropertyChanged(nameof(MedicineSupplyDetails));
                    }                    
                });
            }
        }
        public ICommand AddNewItem
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Supplies.Add(new Supply() { MedicineSupplyDetails = new ObservableCollection<MedicineSupplyDetail>() });
                    CollectionViewSource.GetDefaultView(Supplies).Refresh();
                    ChangesMadeCommand.Execute(null);
                });
            }
        }
        public ICommand AddNewSubItem
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (SelectedSupply == null)
                    {                        
                        MessageBox.Show("Supply is not selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    SelectedSupply.MedicineSupplyDetails.Add(new MedicineSupplyDetail());
                    CollectionViewSource.GetDefaultView(MedicineSupplyDetails).Refresh();
                    ChangesMadeCommand.Execute(null);
                });
            }
        }
        #endregion

        #region Constructors
        public SuppliesViewModel()
        {
            _context.Supplies.Load();
            _context.Medicines.Load();
            Supplies = _context.Supplies.Local;
            if (_context.Suppliers.Any())
            {
                MedicineSupplyDetails = _context.Supplies.First().MedicineSupplyDetails;
            }
        }
        #endregion

        #region Destructors
        // Dispose context on closing
        ~SuppliesViewModel()
        {
            _context.Dispose();
        }
        #endregion
    }
}

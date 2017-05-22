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
    public class SalesViewModel: ViewModelBase
    {
        #region Private fields
        private DrugstoreManagementSystemContext _context = new DrugstoreManagementSystemContext();
        private string _areChangesSavedMessage = "Changes are saved";
        private Brush _areChangesSavedMessageColor = System.Windows.Media.Brushes.Green;
        private int _selectedSaleIndex = 0;
        private Sale _selectedSale = null;
        #endregion

        #region Properties
        public ObservableCollection<Sale> Sales { get; set; }
        public ObservableCollection<MedicineSaleDetail> MedicineSaleDetails { get; set; }
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
        public int SelectedSaleIndex
        {
            get
            {
                return _selectedSaleIndex;
            }
            set
            {
                SetProperty(ref _selectedSaleIndex, value);
            }
        }
        public Sale SelectedSale
        {
            get
            {
                return _selectedSale;
            }
            set
            {
                SetProperty(ref _selectedSale, value);
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
                        foreach (var s in Sales)
                        {
                            foreach (var msd in s.MedicineSaleDetails)
                            {
                                if (_context.Entry(msd).State == EntityState.Added)
                                {
                                    msd.Medicine.Quantity -= msd.Quantity;
                                    if (msd.Medicine.Quantity < 0)
                                    {
                                        throw new InvalidOperationException("Not enough medicines for this sale.");
                                    }
                                    _context.Entry(msd.Medicine).State = EntityState.Modified;
                                }
                            }
                        }
                        _context.SaveChanges();
                        foreach (var s in Sales)
                        {
                            if (s.SaleTotal == 0)
                            {
                                decimal total = 0;
                                foreach (var msd in s.MedicineSaleDetails)
                                {
                                    total += msd.Medicine.Price * msd.Quantity;
                                }
                                s.SaleTotal = total;
                                _context.Entry(s).State = EntityState.Modified;
                            }
                        }
                        _context.SaveChanges();
                        CollectionViewSource.GetDefaultView(Sales).Refresh();
                        AreChangesSavedMessage = "Changes are saved.";
                        AreChangesSavedMessageColor = Brushes.Green;
                    }
                    catch (DbUpdateException ex)
                    {
                        MessageBox.Show("Some data is invalid or empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        //MessageBox.Show(ex.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (DbEntityValidationException ex)
                    {
                        MessageBox.Show("Some data is invalid or empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        //MessageBox.Show(ex.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                        CollectionViewSource.GetDefaultView(Sales).Refresh();
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
                    if (SelectedSale != null)
                    {
                        MedicineSaleDetails = SelectedSale.MedicineSaleDetails;
                        OnPropertyChanged(nameof(MedicineSaleDetails));
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
                    Sales.Add(new Sale() { MedicineSaleDetails = new ObservableCollection<MedicineSaleDetail>() });
                    CollectionViewSource.GetDefaultView(Sales).Refresh();
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
                    if (SelectedSale == null)
                    {
                        MessageBox.Show("Sale is not selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    SelectedSale.MedicineSaleDetails.Add(new MedicineSaleDetail());
                    CollectionViewSource.GetDefaultView(MedicineSaleDetails).Refresh();
                    ChangesMadeCommand.Execute(null);
                });
            }
        }
        #endregion

        #region Constructors
        public SalesViewModel()
        {
            _context.Sales.Load();
            _context.Medicines.Load();
            Sales = _context.Sales.Local;
            if (_context.Sales.Any())
            {
                MedicineSaleDetails = _context.Sales.First().MedicineSaleDetails;
            }
        }
        #endregion

        #region Destructors
        // Dispose context on closing
        ~SalesViewModel()
        {
            _context.Dispose();
        }
        #endregion
    }
}

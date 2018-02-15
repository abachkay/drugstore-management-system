using DrugstoreManagementSystem.UI.Commands;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using DrugstoreManagementSystem.DataAccess.Context;
using DrugstoreManagementSystem.Entities;

namespace DrugstoreManagementSystem.UI.ViewModels
{
    public class SalesViewModel: ViewModelBase
    {
        #region Private fields

        private readonly DrugstoreManagementSystemContext _context = new DrugstoreManagementSystemContext();
        private string _areChangesSavedMessage = "Changes are saved";
        private Brush _areChangesSavedMessageColor = Brushes.Green;
        private int _selectedSaleIndex = 0;
        private Sale _selectedSale = null;

        #endregion

        #region Properties

        public ObservableCollection<Sale> Sales { get; set; }

        public ObservableCollection<MedicineSaleDetail> MedicineSaleDetails { get; set; }

        public string AreChangesSavedMessage
        {
            get => _areChangesSavedMessage;
            set => SetProperty(ref _areChangesSavedMessage, value);
        }

        public Brush AreChangesSavedMessageColor
        {
            get => _areChangesSavedMessageColor;
            set => SetProperty(ref _areChangesSavedMessageColor, value);
        }

        public int SelectedSaleIndex
        {
            get => _selectedSaleIndex;
            set => SetProperty(ref _selectedSaleIndex, value);
        }

        public Sale SelectedSale
        {
            get => _selectedSale;
            set => SetProperty(ref _selectedSale, value);
        }

        public ICommand SaveChangesCommand
        {
            get
            {
                return new RelayCommand(o =>
                {
                    try
                    {
                        if (MedicineSaleDetails.Count <= 0)
                        {
                            throw new InvalidOperationException("There must be some medicines in sale.");
                        }                       
                        foreach (var s in Sales)
                        {
                            foreach (var msd in s.MedicineSaleDetails)
                            {
                                if (_context.Entry(msd).State == EntityState.Added)
                                {
                                    if (msd.Medicine == null)
                                    {
                                        throw new InvalidOperationException("There is no medicine with given id.");
                                    }
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
                            if (s.SaleTotal != 0)
                            {
                                continue;                                
                            }

                            var total = s.MedicineSaleDetails.Sum(msd => msd.Medicine.Price * msd.Quantity);

                            s.SaleTotal = total;
                            _context.Entry(s).State = EntityState.Modified;
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
                return new RelayCommand(o =>
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
                return new RelayCommand(o =>
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
                return new RelayCommand(o =>
                {
                    _context.Medicines.Load();
                    if (SelectedSale != null)
                    {
                       // MedicineSaleDetails = SelectedSale.MedicineSaleDetails;
                        OnPropertyChanged(nameof(MedicineSaleDetails));
                    }
                });
            }
        }

        public ICommand AddNewItem
        {
            get
            {
                return new RelayCommand(o =>
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
                return new RelayCommand(o =>
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
                MedicineSaleDetails = new ObservableCollection<MedicineSaleDetail>(_context.Sales.First().MedicineSaleDetails);
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

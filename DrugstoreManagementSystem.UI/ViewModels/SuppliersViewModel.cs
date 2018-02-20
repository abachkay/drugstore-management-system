using DrugstoreManagementSystem.Entities;
using DrugstoreManagementSystem.Services;
using DrugstoreManagementSystem.UI.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace DrugstoreManagementSystem.UI.ViewModels
{
    public class SuppliersViewModel : ViewModelBase
    {
        private readonly ISupplierService _supplierService;
        private ICollection<Supplier> _archivedSuppliers;

        public SuppliersViewModel(ISupplierService supplierService)
        {
            _supplierService = supplierService;
            _archivedSuppliers = new List<Supplier>();

            IncludeArchived = false;
        }

        private bool _includeArchived;
        public bool IncludeArchived
        {
            get => _includeArchived;
            set
            {
                SetProperty(ref _includeArchived, value);

                Suppliers = new ObservableCollection<Supplier>(_supplierService.GetSuppliers(IncludeArchived));
                SelectedSupplier = Suppliers.FirstOrDefault();
            }
        }
        
        private ObservableCollection<Supplier> _suppliers;
        public ObservableCollection<Supplier> Suppliers
        {
            get => _suppliers;
            set => SetProperty(ref _suppliers, value);
        }

        private Supplier _selectedSupplier;
        public Supplier SelectedSupplier
        {
            get => _selectedSupplier;
            set => SetProperty(ref _selectedSupplier, value);
        }

        public ICommand SaveChangesCommand
        {
            get
            {
                return new RelayCommand(o =>
                {
                    _supplierService.SaveChanges(Suppliers.ToList().Concat(_archivedSuppliers));
                    UpdateChangesStatus(true);
                    _archivedSuppliers.Clear();
                });
            }
        }

        public ICommand DiscardChangesCommand
        {
            get
            {
                return new RelayCommand(o =>
                {
                    Suppliers = new ObservableCollection<Supplier>(_supplierService.GetSuppliers(IncludeArchived));
                    UpdateChangesStatus(true);
                });
            }
        }

        public ICommand AddSupplier
        {
            get
            {
                return new RelayCommand(o =>
                {
                    Suppliers.Add(new Supplier()
                    {
                        SupplierName = "New supplier"
                    });

                    UpdateChangesStatus(false);
                });
            }
        }

        public ICommand ArchiveSupplier
        {
            get
            {
                return new RelayCommand(o =>
                {
                    _supplierService.ArchiveSupplier(SelectedSupplier);
                    if (!IncludeArchived)
                    {
                        _archivedSuppliers.Add(SelectedSupplier);
                        Suppliers.Remove(SelectedSupplier);
                    }
                    CollectionViewSource.GetDefaultView(Suppliers).Refresh();
                    UpdateChangesStatus(false);
                });
            }
        }
    }
}
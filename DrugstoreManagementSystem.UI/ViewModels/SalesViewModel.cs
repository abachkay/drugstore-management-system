using DrugstoreManagementSystem.Entities;
using DrugstoreManagementSystem.Services;
using DrugstoreManagementSystem.UI.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DrugstoreManagementSystem.UI.ViewModels
{
    public class SalesViewModel : ViewModelBase
    {
        private readonly ISaleService _saleService;
        private readonly IMedicineService _medicineService;

        public SalesViewModel(ISaleService saleService, IMedicineService medicineService)
        {
            _saleService = saleService;
            _medicineService = medicineService;

            Sales = new ObservableCollection<Sale>(_saleService.GetSales());
            Medicines = new ObservableCollection<Medicine>(_medicineService.GetMedicines());
            SelectedSale = Sales.FirstOrDefault();
        }           

        private ObservableCollection<Sale> _sales;
        public ObservableCollection<Sale> Sales
        {
            get => _sales;
            set => SetProperty(ref _sales, value);
        }

        private ObservableCollection<MedicineSaleDetail> _medicineSaleDetails;
        public ObservableCollection<MedicineSaleDetail> MedicineSaleDetails
        {
            get => _medicineSaleDetails;
            set => SetProperty(ref _medicineSaleDetails, value);
        }

        private ObservableCollection<Medicine> _medicines;
        public ObservableCollection<Medicine> Medicines
        {
            get => _medicines;
            set => SetProperty(ref _medicines, value);
        }

        private Sale _selectedSale;
        public Sale SelectedSale
        {
            get => _selectedSale;
            set
            {
                SetProperty(ref _selectedSale, value);
                MedicineSaleDetails = new ObservableCollection<MedicineSaleDetail>(SelectedSale.MedicineSaleDetails);
                SelectedMedicineSaleDetail = MedicineSaleDetails.FirstOrDefault();
            }
        }

        private MedicineSaleDetail _selectedMedicineSaleDetail;
        public MedicineSaleDetail SelectedMedicineSaleDetail
        {
            get => _selectedMedicineSaleDetail;
            set
            {
                SetProperty(ref _selectedMedicineSaleDetail, value);               
                SelectedMedicine = Medicines.FirstOrDefault(m => m.MedicineId == _selectedMedicineSaleDetail.Medicine.MedicineId);                
            }
        }

        private Medicine _selectedMedicine;
        public Medicine SelectedMedicine
        {
            get => _selectedMedicine;
            set
            {
                SetProperty(ref _selectedMedicine, value);
                SelectedMedicineSaleDetail.Medicine = SelectedMedicine;
            }
        }

        public ICommand SaveChangesCommand
        {
            get
            {
                return new RelayCommand(o =>
                {                    
                    _saleService.SaveChanges(Sales);                    
                    UpdateChangesStatus(true);
                });
            }
        }

        public ICommand DiscardChangesCommand
        {
            get
            {
                return new RelayCommand(o =>
                {                   
                    Sales = new ObservableCollection<Sale>(_saleService.GetSales());                    
                    UpdateChangesStatus(true);
                });
            }
        }

        public ICommand AddNewItem
        {
            get
            {
                return new RelayCommand(o =>
                {
                    Sales.Add(new Sale()
                    {
                        SaleDate = DateTime.Now,
                        SaleTotal = 0,
                        MedicineSaleDetails = new ObservableCollection<MedicineSaleDetail>()
                    });
                    SelectedSale = Sales.Last();
                });
            }
        }

        public ICommand AddNewSubItem
        {
            get
            {
                return new RelayCommand(o =>
                {
                    if (!Sales.Any())
                    {
                        MessageBox.Show("Sale is not selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MedicineSaleDetails.Add(new MedicineSaleDetail()
                    {
                        Quantity = 1,
                        Medicine = SelectedMedicine
                    });
                });
            }
        }
    }
}
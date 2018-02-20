using Autofac;
using DrugstoreManagementSystem.DataAccess.Context;
using DrugstoreManagementSystem.Entities;
using DrugstoreManagementSystem.Services;
using DrugstoreManagementSystem.UI.Commands;
using DrugstoreManagementSystem.UI.Configuration;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DrugstoreManagementSystem.UI.ViewModels
{
    public class SalesViewModel : ViewModelBase
    {                           
        //public SalesViewModel()
        //{
        //    using (var saleService = SaleService)
        //    {
        //        Sales = new ObservableCollection<Sale>(saleService.GetSales());
        //        saleService.Dispose();
        //    }

        //    //using (var c = new DrugstoreManagementSystemContext())
        //    //{
        //    //    Sales = new ObservableCollection<Sale>(c.Set<Sale>().Include($"{nameof(Sale.MedicineSaleDetails)}.{nameof(MedicineSaleDetail.Medicine)}").ToList());
        //    //}

        //    using (var medicineService = MedicineService)
        //    {
        //        Medicines = new ObservableCollection<Medicine>(medicineService.GetMedicines());
        //    }

        //    if (Sales.Any())
        //    {
        //        //SelectedSale = Sales.First();
        //    }
        //}

        //public ISaleService SaleService => AutofacConfiguration.Container.Resolve<ISaleService>();

        //public IMedicineService MedicineService => AutofacConfiguration.Container.Resolve<IMedicineService>();

        //private ObservableCollection<Sale> _sales;
        //public ObservableCollection<Sale> Sales
        //{
        //    get => _sales;
        //    set => SetProperty(ref _sales, value);
        //}

        //private ObservableCollection<MedicineSaleDetail> _medicineSaleDetails;
        //public ObservableCollection<MedicineSaleDetail> MedicineSaleDetails
        //{
        //    get => _medicineSaleDetails;
        //    set => SetProperty(ref _medicineSaleDetails, value);
        //}

        //private ObservableCollection<Medicine> _medicines;
        //public ObservableCollection<Medicine> Medicines
        //{
        //    get => _medicines;
        //    set => SetProperty(ref _medicines, value);
        //}

        ////private Sale _selectedSale;
        ////public Sale SelectedSale
        ////{
        ////    get => _selectedSale;
        ////    set
        ////    {
        ////        SetProperty(ref _selectedSale, value);
        ////        MedicineSaleDetails = new ObservableCollection<MedicineSaleDetail>(SelectedSale.MedicineSaleDetails);
        ////        if (MedicineSaleDetails.Any())
        ////        {
        ////            SelectedMedicineSaleDetail = MedicineSaleDetails.First();
        ////        }
        ////    }
        ////}

        ////private MedicineSaleDetail _selectedMedicineSaleDetail;
        ////public MedicineSaleDetail SelectedMedicineSaleDetail
        ////{
        ////    get => _selectedMedicineSaleDetail;
        ////    set
        ////    {
        ////        SetProperty(ref _selectedMedicineSaleDetail, value);
        ////        if (MedicineSaleDetails.Any())
        ////        {
        ////            SelectedMedicine = Medicines.FirstOrDefault(m => m.MedicineId == _selectedMedicineSaleDetail.Medicine.MedicineId);
        ////        }
        ////    }
        ////}

        ////private Medicine _selectedMedicine;
        ////public Medicine SelectedMedicine
        ////{
        ////    get => _selectedMedicine;
        ////    set
        ////    {
        ////        SetProperty(ref _selectedMedicine, value);
        ////        SelectedMedicineSaleDetail.Medicine = SelectedMedicine;
        ////    }
        ////}

        //public ICommand SaveChangesCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(o =>
        //        {
        //            using (var saleService = SaleService)
        //            {                        
        //                saleService.SaveChanges(Sales);                        
        //            }
                   
        //            UpdateChangesStatus(true);
        //        });
        //    }
        //}

        //public ICommand DiscardChangesCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(o =>
        //        {
        //            using (var supplyService = SaleService)
        //            {
        //                Sales = new ObservableCollection<Sale>(supplyService.GetSales());
        //            }
        //            UpdateChangesStatus(true);
        //        });
        //    }
        //}

        ////public ICommand AddNewItem
        ////{
        ////    get
        ////    {
        ////        return new RelayCommand(o =>
        ////        {
        ////            Sales.Add(new Sale()
        ////            {
        ////                SaleDate = DateTime.Now,
        ////                SaleTotal = 0,
        ////                MedicineSaleDetails = new ObservableCollection<MedicineSaleDetail>()
        ////            });
        ////            SelectedSale = Sales.Last();
        ////        });
        ////    }
        ////}

        ////public ICommand AddNewSubItem
        ////{
        ////    get
        ////    {
        ////        return new RelayCommand(o =>
        ////        {
        ////            if (!Sales.Any())
        ////            {
        ////                MessageBox.Show("Sale is not selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        ////                return;
        ////            }

        ////            MedicineSaleDetails.Add(new MedicineSaleDetail()
        ////            {
        ////                Quantity = 1,
        ////                Medicine = SelectedMedicine
        ////            });
        ////        });
        ////    }
        ////}
    }
}
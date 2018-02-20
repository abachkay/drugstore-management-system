using Autofac;
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
    public class SuppliesViewModel : ViewModelBase
    {
        //public SuppliesViewModel()
        //{            
        //    using (var supplierService = SupplyService)
        //    {
        //        Supplies = new ObservableCollection<Supply>(supplierService.GetSupplies());

        //        if (Supplies.Any())
        //        {
        //            SelectedSupplyIndex = 0;
        //        }
        //    }
        //}

        //public ISupplyService SupplyService => AutofacConfiguration.Container.Resolve<ISupplyService>();        

        //private ObservableCollection<MedicineSupplyDetail> _medicineSupplyDetails;
        //public ObservableCollection<MedicineSupplyDetail> MedicineSupplyDetails
        //{
        //    get => _medicineSupplyDetails;
        //    set => SetProperty(ref _medicineSupplyDetails, value);
        //}

        //private ObservableCollection<Supply> _supplies;
        //public ObservableCollection<Supply> Supplies
        //{
        //    get => _supplies;
        //    set => SetProperty(ref _supplies, value);
        //}

        //private int _selectedSupplyIndex;
        //public int SelectedSupplyIndex
        //{
        //    get => _selectedSupplyIndex;
        //    set
        //    {
        //        SetProperty(ref _selectedSupplyIndex, value);
        //        MedicineSupplyDetails = new ObservableCollection<MedicineSupplyDetail>(SupplyService.GetMedicineSupplyDetails(Supplies[value].SupplyId));
        //    }
        //}

        //public ICommand SaveChangesCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(o =>
        //        {
        //            using (var supplyService = SupplyService)
        //            {
        //                supplyService.SaveChanges(Supplies);
        //            }

        //            using (var medicineService = SupplyService)
        //            {
        //                Supplies = new ObservableCollection<Supply>(medicineService.GetSupplies());
        //            }

        //            UpdateChangesStatus(true);
        //            MessageBox.Show("Some data is not valid or empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //        });
        //    }
        //}

        //public ICommand DiscardChangesCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(o =>
        //        {
        //            using (var supplyService = SupplyService)
        //            {
        //                Supplies = new ObservableCollection<Supply>(supplyService.GetSupplies());
        //            }
        //            UpdateChangesStatus(true);
        //        });
        //    }
        //}

        //public ICommand AddNewItem
        //{
        //    get
        //    {
        //        return new RelayCommand(o =>
        //        {
        //            Supplies.Add(new Supply()
        //            {
        //                SupplyDate = DateTime.Now,
        //                SupplyTotal = 0, 
        //                MedicineSupplyDetails = new ObservableCollection<MedicineSupplyDetail>()
        //            });                                        
        //        });
        //    }
        //}

        //public ICommand AddNewSubItem
        //{
        //    get
        //    {
        //        return new RelayCommand(o =>
        //        {
        //            if (!Supplies.Any())
        //            {
        //                MessageBox.Show("Supply is not selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //                return;
        //            }
        //            MedicineSupplyDetails.Add(new MedicineSupplyDetail()
        //            {
        //                Quantity = 1
        //            });
        //        });
        //    }
        //}
    }
}
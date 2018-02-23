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
    public class MedicinesViewModel: ViewModelBase
    {
        private readonly IMedicineService _medicineService;
        private ICollection<Medicine> _archivedMedicines;

        public MedicinesViewModel(IMedicineService medicineService)
        {
            _medicineService = medicineService;
            _archivedMedicines = new List<Medicine>();

            IncludeArchived = false;
        }        
       
        private bool _includeArchived;
        public bool IncludeArchived
        {
            get => _includeArchived;
            set
            {
                SetProperty(ref _includeArchived, value);

                Medicines = new ObservableCollection<Medicine>(_medicineService.GetMedicines(IncludeArchived));
                SelectedMedicine = Medicines.FirstOrDefault();
            }
        }

        private ObservableCollection<Medicine> _medicines;
        public ObservableCollection<Medicine> Medicines
        {
            get => _medicines;
            set => SetProperty(ref _medicines, value);
        }

        private Medicine _selectedMedicine;
        public Medicine SelectedMedicine
        {
            get => _selectedMedicine;
            set => SetProperty(ref _selectedMedicine, value);
        }

        public ICommand SaveChangesCommand
        {
            get
            {
                return new RelayCommand(o =>
                {                                        
                    _medicineService.SaveChanges(Medicines.ToList().Concat(_archivedMedicines));                                                                                             
                    UpdateChangesStatus(true);
                    _archivedMedicines.Clear();
                });
            }
        }

        public ICommand DiscardChangesCommand
        {
            get
            {
                return new RelayCommand(o =>
                {                  
                    Medicines = new ObservableCollection<Medicine>(_medicineService.GetMedicines(IncludeArchived));                    
                    UpdateChangesStatus(true);
                });
            }
        }     

        public ICommand AddMedicine
        {
            get
            {
                return new RelayCommand(o =>
                {
                    Medicines.Add(new Medicine()
                    {
                        MedicineName = "New medicine",
                        Price = 1,
                        ProducerName = "Producer",
                        Quantity = 1,
                    });
                    UpdateChangesStatus(false);
                });
            }
        }

        public ICommand ArchiveMedicine
        {
            get
            {
                return new RelayCommand(o =>
                {
                    _medicineService.ArchiveMedicine(SelectedMedicine);                    
                    if (!IncludeArchived)
                    {
                        _archivedMedicines.Add(SelectedMedicine);
                        Medicines.Remove(SelectedMedicine);
                    }
                    CollectionViewSource.GetDefaultView(Medicines).Refresh();
                    UpdateChangesStatus(false);
                });
            }
        }           
    }
}
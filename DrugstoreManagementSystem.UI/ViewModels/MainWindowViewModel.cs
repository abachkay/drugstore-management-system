namespace DrugstoreManagementSystem.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MedicinesViewModel MedicinesViewModel { get; }

        public SuppliersViewModel SuppliersViewModel { get; }

        public SuppliesViewModel SuppliesViewModel { get; }

        public SalesViewModel SalesViewModel { get; }

        public MainWindowViewModel(MedicinesViewModel medicinesViewModel, SuppliersViewModel suppliersViewModel,
            SuppliesViewModel suppliesViewModel, SalesViewModel salesViewModel)
        {
            MedicinesViewModel = medicinesViewModel;
            SuppliersViewModel = suppliersViewModel;
            SuppliesViewModel = suppliesViewModel;
            SalesViewModel = salesViewModel;
        }
    }
}
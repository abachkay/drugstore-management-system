namespace DrugstoreManagementSystem.UI.ViewModels
{
    public class MainWindowViewModel: ViewModelBase
    {
        public MedicinesViewModel MedicinesViewModel { get; set; } = new MedicinesViewModel();

        public SuppliersViewModel SuppliersViewModel { get; set; } = new SuppliersViewModel();

        public SuppliesViewModel SuppliesViewModel { get; set; } = new SuppliesViewModel();

        public SalesViewModel SalesViewModel { get; set; } = new SalesViewModel();
    }
}
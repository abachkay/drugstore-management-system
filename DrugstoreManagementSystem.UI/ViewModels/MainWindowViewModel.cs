using DrugstoreManagementSystem.UI.Configuration;
using Unity;

namespace DrugstoreManagementSystem.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MedicinesViewModel MedicinesViewModel { get; set; } = UnityConfiguration.Container.Resolve<MedicinesViewModel>();

        public SuppliersViewModel SuppliersViewModel { get; set; } = UnityConfiguration.Container.Resolve<SuppliersViewModel>();

        public SuppliesViewModel SuppliesViewModel { get; set; } = UnityConfiguration.Container.Resolve<SuppliesViewModel>();

        public SalesViewModel SalesViewModel { get; set; } = UnityConfiguration.Container.Resolve<SalesViewModel>();
    }
}
using Autofac;
using DrugstoreManagementSystem.UI.Configuration;

namespace DrugstoreManagementSystem.UI.ViewModels
{
    public class ViewModelLocator
    {
        public MedicinesViewModel MedicinesViewModel => AutofacConfiguration.Container.Resolve<MedicinesViewModel>();

        public SuppliersViewModel SuppliersViewModel => AutofacConfiguration.Container.Resolve<SuppliersViewModel>();

        public SuppliesViewModel SuppliesViewModel => AutofacConfiguration.Container.Resolve<SuppliesViewModel>();

        public SalesViewModel SalesViewModel => AutofacConfiguration.Container.Resolve<SalesViewModel>();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagementSystem.UI.ViewModels
{
    class MainWindowViewModel: ViewModelBase
    {
        public MedicinesViewModel MedicinesViewModel => new MedicinesViewModel();
        public SalesViewModel SalesViewModel => new SalesViewModel();
        public SuppliersViewModel SuppliersViewModel => new SuppliersViewModel();
        public SuppliesViewModel SuppliesViewModel => new SuppliesViewModel();

    }
}

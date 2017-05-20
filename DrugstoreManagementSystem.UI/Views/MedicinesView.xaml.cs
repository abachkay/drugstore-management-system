using DrugstoreManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrugstoreManagementSystem.UI.Views
{
    /// <summary>
    /// Interaction logic for MedicinesView.xaml
    /// </summary>
    public partial class MedicinesView : UserControl
    {        
        public MedicinesView()
        {
            InitializeComponent();
            using (var unitOfWork = new UnitOfWork())
            {
                MedicinesDataGrid.ItemsSource = unitOfWork.MedicineRepository.GetAll.Select(m => new { Name = m.MedicineName, Producer = m.ProducerName, Price = m.Price, Prescription_Required = m.PrescriptionRequired }).ToList();
            }
        }
    }
}

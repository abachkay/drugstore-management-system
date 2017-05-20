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
using DrugstoreManagementSystem.Entities;
using DrugstoreManagementSystem.Repositories;

namespace DrugstoreManagementSystem.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {            
            InitializeComponent();
            RefreshData();
        }
        private void OnlyAvailibleCheckBox_Click(object sender, RoutedEventArgs e)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                if (!OnlyAvailibleCheckBox.IsChecked.Value)
                {
                    MedicinesDataGrid.ItemsSource = unitOfWork.MedicineRepository.GetAll.Select(m => new { Name = m.MedicineName, Producer = m.ProducerName, Price = m.Price, Quantity = m.Quantity, Prescription_Required = m.PrescriptionRequired }).ToList();
                }
                else
                {
                    MedicinesDataGrid.ItemsSource = unitOfWork.MedicineRepository.GetAvailible.Select(m => new { Name = m.MedicineName, Producer = m.ProducerName, Price = m.Price, Quantity = m.Quantity, Prescription_Required = m.PrescriptionRequired }).ToList();
                }
            
            }            
        }

        private void AddMedicineButton_Click(object sender, RoutedEventArgs e)
        {
            decimal price = 0;            
            if (MedicineNameTextBox.Text.Length == 0 || MedicineProducerNameTextBox.Text.Length == 0 || MedicinePriceTextBox.Text.Length == 0 || !Decimal.TryParse(MedicinePriceTextBox.Text, out price))
            {
                MessageBox.Show("Invalid input.");
                return;
            }
            var medicine = new Medicine()
            {
                MedicineName = MedicineNameTextBox.Text,
                ProducerName = MedicineProducerNameTextBox.Text,
                PrescriptionRequired = RequiresPrescriptionCheckbox.IsChecked.Value,
                Price = Convert.ToDecimal(MedicinePriceTextBox.Text),
            };            
            using (var unitOfWork = new UnitOfWork())
            {                
                unitOfWork.MedicineRepository.Create(medicine);
            }
            RefreshData();
            MedicinesTabControl.SelectedIndex = 0;
        }

        private void RefreshData()
        {
            using (var unitOfWork = new UnitOfWork())
            {                
                MedicinesDataGrid.ItemsSource = unitOfWork.MedicineRepository.GetAll.Select(m => new { Name = m.MedicineName, Producer = m.ProducerName, Price = m.Price, Quantity = m.Quantity, Prescription_Required = m.PrescriptionRequired }).ToList();
                SuppliersDataGrid.ItemsSource = unitOfWork.SupplierRepository.GetAll.Select(s => new { Name = s.SupplierName }).ToList();
                SuppliesDataGrid.ItemsSource = unitOfWork.SupplyRepository.GetAll.Select(s => new { Date = s.SupplyDate.Date.ToString(), Total = s.SupplyTotal, Supplier = s.Supplier.SupplierName });
            }
        }

        private void MedicinesDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MedicinesDataGrid.SelectedIndex < 0)
            {
                MessageBox.Show("You must select item first.");
                return;
            }
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.MedicineRepository.Delete(unitOfWork.MedicineRepository.GetAll.ToList()[MedicinesDataGrid.SelectedIndex]);                
            }
            RefreshData();
        }

        private void MedicineChangePriceButton_Click(object sender, RoutedEventArgs e)
        {
            if (MedicinesDataGrid.SelectedIndex < 0)
            {
                MessageBox.Show("You must select item first.");
                return;
            }
            if (MedicineNewPricefTextBox.Text.Length == 0)
            {
                MessageBox.Show("New price field must be filled.");
                return;
            }
            decimal newPrice = 0;
            if (!decimal.TryParse(MedicineNewPricefTextBox.Text, out newPrice))
            {
                MessageBox.Show("New price must be number.");
                return;
            }
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.MedicineRepository.ChangePrice(unitOfWork.MedicineRepository.GetAll.ToList()[MedicinesDataGrid.SelectedIndex], newPrice);
            }
            RefreshData();
        }

        private void SupplierAddTextBox_Click(object sender, RoutedEventArgs e)
        {
            if (SupplierNameTextBox.Text.Length == 0)
            {
                MessageBox.Show("Supplier name field must be filled.");
                return;
            }
            var supplier = new Supplier()
            {
                SupplierName = SupplierNameTextBox.Text
            };
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.SupplierRepository.Create(supplier);
            }
            RefreshData();
            SuppliersTabControl.SelectedIndex = 0;
        }

        private void SupplierDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SuppliersDataGrid.SelectedIndex < 0)
            {
                MessageBox.Show("You must select item first.");
                return;
            }
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.SupplierRepository.Delete(unitOfWork.SupplierRepository.GetAll.ToList()[SuppliersDataGrid.SelectedIndex]);
            }
            RefreshData();
        }

        private void SuppliesDataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                if (SuppliesDataGrid.SelectedIndex != 0)
                {
                    var supplies = unitOfWork.SupplyRepository.GetAll.ToList();
                    var medicines = unitOfWork.MedicineRepository.GetAll.ToList();
                    //SuppliesDataGrid.ItemsSource = medicines.Where(m => supplies[SuppliesDataGrid.SelectedIndex].MedicineSupplyDetails.Contains(m.MedicineSupplyDetails))
                }
            }
        }
    }
}

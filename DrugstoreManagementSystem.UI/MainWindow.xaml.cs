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
        public List<MedicineSupplyDetail> MedicineSupplyDetails = new List<MedicineSupplyDetail>();
        public List<MedicineSaleDetail> MedicineSaleDetails = new List<MedicineSaleDetail>();
        public MainWindow()
        {
            InitializeComponent();
            RefreshData();
            MedicineSupplyDatePicker.SelectedDate = DateTime.Now;
            MedicineSaleDatePicker.SelectedDate = DateTime.Now;
        }

        // Refreshing all data, bond to database
        private void RefreshData()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                MedicinesDataGrid.ItemsSource = unitOfWork.MedicineRepository.GetAll.Select(m => new { Name = m.MedicineName, Producer = m.ProducerName, Price = m.Price, Quantity = m.Quantity, Prescription_Required = m.PrescriptionRequired }).ToList();                
                SuppliersDataGrid.ItemsSource = unitOfWork.SupplierRepository.GetAll.Select(s => new { Name = s.SupplierName }).ToList();
                SuppliesDataGrid.ItemsSource = unitOfWork.SupplyRepository.GetAll.Select(s => new { Date = s.SupplyDate.Date.ToString("d MMM yyyy"), Total = s.SupplyTotal, Supplier = s.Supplier.SupplierName });
                SalesDataGrid.ItemsSource = unitOfWork.SaleRepository.GetAll.Select(s => new { Date = s.SaleDate.Date.ToString("d MMM yyyy"), Total = s.SaleTotal });

                MedicineSupplyComboBox.ItemsSource = unitOfWork.MedicineRepository.GetAvailible.Select(m => m.MedicineName).ToList();
                MedicineSaleComboBox.ItemsSource = unitOfWork.MedicineRepository.GetAvailible.Select(m => m.MedicineName).ToList();

                MedicineSupplySupplierComboBox.ItemsSource = unitOfWork.SupplierRepository.GetAll.Select(s => s.SupplierName);
                MedicineSupplySupplierComboBox.SelectedIndex = 0;
                MedicineSupplyComboBox.SelectedIndex = 0;
                MedicineSaleComboBox.SelectedIndex = 0;

                MedicinesDataGrid.SelectedIndex = 0;
                SuppliersDataGrid.SelectedIndex = 0;
                SuppliesDataGrid.SelectedIndex = 0;
                SalesDataGrid.SelectedIndex = 0;
            }
        }

        // Medicine tab operations
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
            MedicineNameTextBox.Text = "";
            MedicineProducerNameTextBox.Text = "";
            MedicinePriceTextBox.Text = "";
            RequiresPrescriptionCheckbox.IsChecked = false;
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
                try
                {
                    unitOfWork.MedicineRepository.Delete(unitOfWork.MedicineRepository.GetAll.ToList()[MedicinesDataGrid.SelectedIndex]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
            MedicineNewPricefTextBox.Text = "";
            RefreshData();
        }

        // Supplier tab operations
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
            SupplierNameTextBox.Text = "";
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
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    unitOfWork.SupplierRepository.Delete(unitOfWork.SupplierRepository.GetAll.ToList()[SuppliersDataGrid.SelectedIndex]);
                }
            }
            catch
            {
                MessageBox.Show("This supplier is still bond to some supply");
            }
            RefreshData();
        }

        // Supplies tab operations.
        private void SuppliesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                if (SuppliesDataGrid.SelectedIndex >= 0)
                {
                    var supplies = unitOfWork.SupplyRepository.GetAll.ToList();
                    var medicines = unitOfWork.MedicineRepository.GetAll.ToList();
                    SuppliesMedicinesDataGrid.ItemsSource = medicines.Where(m => supplies[SuppliesDataGrid.SelectedIndex].MedicineSupplyDetails.
                        Any(msd => m.MedicineSupplyDetails.Contains(msd))).
                        Select(m => new { Name = m.MedicineName, Producer = m.ProducerName, Price = m.Price, Quantity = m.MedicineSupplyDetails.FirstOrDefault().Quantity, Prescription_Required = m.PrescriptionRequired }).ToList();
                }
            }
        }

        private void MedicineSupplyAddButton_Click(object sender, RoutedEventArgs e)
        {
            int quantity = 0;
            if (!int.TryParse(MedicineSupplyQuantityTextBox.Text, out quantity))
            {
                MessageBox.Show("Quantity must be number");
                return;
            }
            if (MedicineSupplyComboBox.SelectedIndex >= 0)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    MedicineSupplyDetails.Add(new MedicineSupplyDetail()
                    {
                        Quantity = quantity,
                        Medicine = unitOfWork.MedicineRepository.GetAvailible.ToList()[MedicineSupplyComboBox.SelectedIndex]
                    });

                    MedicineSupplyAddDataGrid.ItemsSource = MedicineSupplyDetails.Select(msd => new { Medicine = msd.Medicine.MedicineName, Quantity = msd.Quantity, }).ToList();
                }
            }
            MedicineSupplyQuantityTextBox.Text = "";
        }

        private void SupplyAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (MedicineSupplyDetails.Count == 0)
            {
                MessageBox.Show("You must add at least one medicine to supply");
                return;
            }
            var date = MedicineSupplyDatePicker.SelectedDate.Value;

            var supply = new Supply()
            {
                SupplyDate = date,
                MedicineSupplyDetails = MedicineSupplyDetails,
            };
            using (var unitOfWork = new UnitOfWork())
            {
                var supplier = unitOfWork.SupplierRepository.GetAll.ToList()[MedicineSupplySupplierComboBox.SelectedIndex];
                supply.Supplier = supplier;
                unitOfWork.SupplyRepository.Create(supply);
            }
            MedicineSupplyDetails = new List<MedicineSupplyDetail>();
            RefreshData();
            SuppliesTabControl.SelectedIndex = 0;
        }

        private void SupplyDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SuppliesDataGrid.SelectedIndex < 0)
            {
                MessageBox.Show("You must select item first.");
                return;
            }
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.SupplyRepository.Delete(unitOfWork.SupplyRepository.GetAll.ToList()[SuppliesDataGrid.SelectedIndex]);
            }
            RefreshData();
        }

        // Sales tab operations.
        private void MedicineSaleAddButton_Click(object sender, RoutedEventArgs e)
        {
            int quantity = 0;
            if (!int.TryParse(MedicineSaleQuantityTextBox.Text, out quantity))
            {
                MessageBox.Show("Quantity must be number");
                return;
            }            
            if (MedicineSaleComboBox.SelectedIndex >= 0)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var medicine = unitOfWork.MedicineRepository.GetAvailible.ToList()[MedicineSaleComboBox.SelectedIndex];
                    if (medicine.Quantity<quantity)
                    {
                        MessageBox.Show("Not enough medicine for sale");
                    }
                    MedicineSaleDetails.Add(new MedicineSaleDetail()
                    {
                        Quantity = quantity,
                        Medicine = medicine
                    });
                    MedicineSaleQuantityTextBox.Text = "";
                    MedicineSaleAddDataGrid.ItemsSource = MedicineSaleDetails.Select(msd => new { Medicine = msd.Medicine.MedicineName, Quantity = msd.Quantity, }).ToList();
                }
            }                        
        }

        private void SaleAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (MedicineSaleDetails.Count == 0)
            {
                MessageBox.Show("You must add at least one medicine to sale");
                return;
            }
            var date = MedicineSaleDatePicker.SelectedDate.Value;

            var sale = new Sale()
            {
                SaleDate = date,
                MedicineSaleDetails = MedicineSaleDetails,
            };
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.SaleRepository.Create(sale);
            }
            MedicineSaleDetails = new List<MedicineSaleDetail>();
            RefreshData();
            SalesTabControl.SelectedIndex = 0;
        }

        private void SalesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                if (SalesDataGrid.SelectedIndex >= 0)
                {
                    var sales = unitOfWork.SaleRepository.GetAll.ToList();
                    var medicines = unitOfWork.MedicineRepository.GetAll.ToList();
                    SalesMedicinesDataGrid.ItemsSource = medicines.Where(m => sales[SalesDataGrid.SelectedIndex].MedicineSaleDetails.
                        Any(msd => m.MedicineSaleDetails.Contains(msd))).
                        Select(m =>new { Name = m.MedicineName, Producer = m.ProducerName, Price = m.Price, Quantity = m.MedicineSaleDetails.FirstOrDefault().Quantity, Prescription_Required = m.PrescriptionRequired }).ToList();
                }
            }
        }

        private void SaleDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SalesDataGrid.SelectedIndex < 0)
            {
                MessageBox.Show("You must select item first.");
                return;
            }
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.SaleRepository.Delete(unitOfWork.SaleRepository.GetAll.ToList()[SalesDataGrid.SelectedIndex]);
            }
            RefreshData();
        }
    }
}

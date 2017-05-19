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
        public IEnumerable<Medicine> Medicines { get; set; }
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            Medicines = new DrugstoreManagementSystemContext().Medicines.ToList();
            DG.ItemsSource = Medicines.ToList();
        }
    }
}

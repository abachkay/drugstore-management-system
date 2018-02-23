using DrugstoreManagementSystem.Entities;
using System;
using System.Linq;

namespace DrugstoreManagementSystem.UI.ViewModels
{
    public class MedicineSaleDetailViewModel:ViewModelBase
    {
        private readonly MedicineSaleDetail _medicineSaleDetail;
        private readonly Medicine[] _medicines;
        
        public MedicineSaleDetailViewModel(MedicineSaleDetail medicineSaleDetail, Medicine[] medicines)
        {
            _medicineSaleDetail = medicineSaleDetail;
            _medicines = medicines;
        }
        
        public int Quantity
        {
            get => _medicineSaleDetail.Quantity;
            set => _medicineSaleDetail.Quantity = value;
        }
        
        public int MedicineIndex
        {
            get => _medicineSaleDetail.Quantity;
            set => _medicineSaleDetail.Quantity = value;
        }
    }
}
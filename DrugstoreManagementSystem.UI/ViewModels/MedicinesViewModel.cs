using DrugstoreManagementSystem.Entities;
using DrugstoreManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagementSystem.UI.ViewModels
{
    public class MedicinesViewModel
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        public IList<Medicine> Medicines => _unitOfWork.MedicineRepository.GetAll.ToList();      
    }
}

using Autofac;
using DrugstoreManagementSystem.DataAccess.Context;
using DrugstoreManagementSystem.DataAccess.Repositories;
using DrugstoreManagementSystem.Entities;
using DrugstoreManagementSystem.Services;
using DrugstoreManagementSystem.UI.ViewModels;
using System.Data.Entity;

namespace DrugstoreManagementSystem.UI.Configuration
{
    public static class AutofacConfiguration
    {
        private static IContainer _container;

        public static IContainer Container
        {
            get
            {
                if (_container != null)
                {
                    return _container;
                }

                var builder = new ContainerBuilder();

                builder.RegisterType<DrugstoreManagementSystemContext>().As<DbContext>().InstancePerDependency();
                builder.RegisterType<SqlGenericRepository<Medicine>>().As<IRepository<Medicine>>().InstancePerDependency();
                builder.RegisterType<SqlGenericRepository<Supply>>().As<IRepository<Supply>>().InstancePerDependency();
                builder.RegisterType<SqlGenericRepository<Supplier>>().As<IRepository<Supplier>>().InstancePerDependency();
                builder.RegisterType<SqlGenericRepository<Sale>>().As<IRepository<Sale>>().InstancePerDependency(); ;
                builder.RegisterType<SqlGenericRepository<MedicineSupplyDetail>>().As<IRepository<MedicineSupplyDetail>>().InstancePerDependency();
                builder.RegisterType<SqlGenericRepository<MedicineSaleDetail>>().As<IRepository<MedicineSaleDetail>>().InstancePerDependency();
                builder.RegisterType<SqlUnitOfWork>().As<IUnitOfWork>().PropertiesAutowired().InstancePerDependency();
                builder.RegisterType<MedicineService>().As<IMedicineService>().SingleInstance();
                builder.RegisterType<SupplierService>().As<ISupplierService>().SingleInstance();
                builder.RegisterType<SupplyService>().As<ISupplyService>().SingleInstance();
                builder.RegisterType<SaleService>().As<ISaleService>().SingleInstance();
                builder.RegisterType<MedicinesViewModel>().SingleInstance();
                builder.RegisterType<SuppliersViewModel>().SingleInstance();
                builder.RegisterType<SuppliesViewModel>().SingleInstance();
                builder.RegisterType<SalesViewModel>().SingleInstance();

                _container = builder.Build();
                return _container;
            }
        }
    }
}
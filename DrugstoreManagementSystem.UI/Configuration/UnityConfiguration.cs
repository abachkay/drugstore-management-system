using DrugstoreManagementSystem.DataAccess;
using DrugstoreManagementSystem.Domain;
using DrugstoreManagementSystem.UI.ViewModels;
using System;
using Unity;

namespace DrugstoreManagementSystem.UI.Configuration
{
    public class UnityConfiguration
    {
        private static Lazy<IUnityContainer> ContainerBuilder =>
            new Lazy<IUnityContainer>(() =>
            {
                var container = new UnityContainer();

                container.RegisterType<DrugstoreManagementSystemContext>();
                container.RegisterType<MedicinesViewModel>();
                container.RegisterType<SuppliersViewModel>();
                container.RegisterType<SuppliesViewModel>();
                container.RegisterType<SalesViewModel>();
                container.RegisterType<IUserRepository, UserRepository>();

                return container;
            });

        public static IUnityContainer Container => ContainerBuilder.Value;
    }
}
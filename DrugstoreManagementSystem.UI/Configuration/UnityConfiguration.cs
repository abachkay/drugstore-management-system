using DrugstoreManagementSystem.DataAccess;
using DrugstoreManagementSystem.Domain;
using DrugstoreManagementSystem.UI.ViewModels;
using System;
using Unity;
using Unity.Lifetime;

namespace DrugstoreManagementSystem.UI.Configuration
{
    public class UnityConfiguration
    {
        private static Lazy<IUnityContainer> ContainerBuilder =>
            new Lazy<IUnityContainer>(() =>
            {
                var container = new UnityContainer();

                container.RegisterType<DrugstoreManagementSystemContext>(new ContainerControlledLifetimeManager());
                container.RegisterType<MainWindowViewModel>(new ContainerControlledLifetimeManager());
                container.RegisterType<LoginWindowViewModel>(new ContainerControlledLifetimeManager());
                container.RegisterType<MedicinesViewModel>(new ContainerControlledLifetimeManager());
                container.RegisterType<SuppliersViewModel>(new ContainerControlledLifetimeManager());
                container.RegisterType<SuppliesViewModel>(new ContainerControlledLifetimeManager());
                container.RegisterType<SalesViewModel>(new ContainerControlledLifetimeManager());
                container.RegisterType<DataStateViewModel>(new ContainerControlledLifetimeManager());
                container.RegisterType<IUserRepository, UserRepository>(new ContainerControlledLifetimeManager());

                return container;
            });

        public static IUnityContainer Container => ContainerBuilder.Value;
    }
}
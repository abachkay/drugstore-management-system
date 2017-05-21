IF DB_ID('DrugstoreManagementSystem') IS NULL
	CREATE DATABASE DrugstoreManagementSystem
GO
USE DrugstoreManagementSystem     
GO
CREATE TABLE [dbo].[Medicines] (
    [MedicineId] [int] PRIMARY KEY NOT NULL IDENTITY,
    [MedicineName] [nvarchar](max) NOT NULL,
    [ProducerName] [nvarchar](max) NOT NULL,
    [Price] [decimal](18, 2) NOT NULL,
	[PrescriptionRequired] [bit] NOT NULL,
    [Quantity] [int] NOT NULL,        
)
    
CREATE TABLE [dbo].[Sales] (
    [SaleId] [int] PRIMARY KEY NOT NULL IDENTITY,
    [SaleDate] [datetime] NOT NULL,
    [SaleTotal] [decimal](18, 2) NOT NULL,    	    
)

CREATE TABLE [dbo].[MedicineSaleDetails] (
    [MedicineSaleDetailId] [int] PRIMARY KEY NOT NULL IDENTITY,
    [Quantity] [int] NOT NULL,
    [Medicine_MedicineId] [int],
    [Sale_SaleId] [int],    
	CONSTRAINT [FK_dbo.MedicineSaleDetails_dbo.Medicines_Medicine_MedicineId] FOREIGN KEY ([Medicine_MedicineId]) REFERENCES [dbo].[Medicines] ([MedicineId]),
	CONSTRAINT [FK_dbo.MedicineSaleDetails_dbo.Sales_Sale_SaleId] FOREIGN KEY ([Sale_SaleId]) REFERENCES [dbo].[Sales] ([SaleId])
)   

CREATE TABLE [dbo].[Suppliers] (
    [SupplierId] [int] PRIMARY KEY NOT NULL IDENTITY,
    [SupplierName] [nvarchar](max) NOT NULL,    
)

CREATE TABLE [dbo].[Supplies] (
    [SupplyId] [int] PRIMARY KEY NOT NULL IDENTITY,
    [SupplyDate] [datetime] NOT NULL,
    [SupplyTotal] [decimal](18, 2) NOT NULL,
    [Supplier_SupplierId] [int] NOT NULL,   
	CONSTRAINT [FK_dbo.MedicineSupplierDetails_dbo.Suppliers_Supply_SupplierId] FOREIGN KEY ([Supplier_SupplierId]) REFERENCES [dbo].[Suppliers] ([SupplierId]) 
)
 
CREATE TABLE [dbo].[MedicineSupplyDetails] (
    [MedicineSupplyDetailId] [int] PRIMARY KEY NOT NULL IDENTITY,
    [Quantity] [int] NOT NULL,
    [Medicine_MedicineId] [int] NOT NULL,
    [Supply_SupplyId] [int] NOT NULL,
	CONSTRAINT [FK_dbo.MedicineSupplyDetails_dbo.Medicines_Medicine_MedicineId] FOREIGN KEY ([Medicine_MedicineId]) REFERENCES [dbo].[Medicines] ([MedicineId]),
	CONSTRAINT [FK_dbo.MedicineSupplyDetails_dbo.Supplies_Supply_SupplyId] FOREIGN KEY ([Supply_SupplyId]) REFERENCES [dbo].[Supplies] ([SupplyId])
)
 
CREATE TABLE [dbo].[Users] (
    [UserId] [int] PRIMARY KEY NOT NULL IDENTITY,
    [Login] [nvarchar](max) NOT NULL,    
    [PasswordHash] [nvarchar](max) NOT NULL,    
)
IF DB_ID('DrugstoreManagementSystem') IS NULL
	PRINT 'Error. Database not exist';
GO

USE DrugstoreManagementSystem;
GO

IF OBJECT_ID('[dbo].[MedicineSaleDetails]', 'U') IS NOT NULL
	DROP TABLE [dbo].[MedicineSaleDetails];
GO

IF OBJECT_ID('[dbo].[MedicineSupplyDetails]', 'U') IS NOT NULL
	DROP TABLE [dbo].[MedicineSupplyDetails];
GO

IF OBJECT_ID('[dbo].[Medicines]', 'U') IS NOT NULL
	DROP TABLE [dbo].[Medicines];
GO

IF OBJECT_ID('[dbo].[Sales]', 'U') IS NOT NULL
	DROP TABLE [dbo].[Sales];
GO

IF OBJECT_ID('[dbo].[Supplies]', 'U') IS NOT NULL
	DROP TABLE [dbo].[Supplies];
GO

IF OBJECT_ID('[dbo].[Suppliers]', 'U') IS NOT NULL
	DROP TABLE [dbo].[Suppliers];
GO

IF OBJECT_ID('[dbo].[Users]', 'U') IS NOT NULL
	DROP TABLE [dbo].[Users];
GO
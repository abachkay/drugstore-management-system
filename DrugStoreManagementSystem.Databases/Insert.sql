USE DrugstoreManagementSystem

INSERT INTO MEDICINES VALUES
('Centramon','Darnica',200,1000,0),
('Aspirin','Enroling',300,1000,0),
('Dufalac','Vary',140,1000,0),
('Ertan','Dart',500,1000,1),
('Martan','Rith',200,1000,1)

INSERT INTO Sales VALUES
('2-2-2016',4400),
('2-4-2013',4440),
('5-2-2012',4420),
('4-2-2016',4100),
('7-4-2016',1400)

INSERT INTO Suppliers VALUES
('Arino store'),
('Darwin store'),
('Kernel shop'),
('Swavn store')

INSERT INTO Supplies VALUES
('5-2-2012',5000, 1),
('4-2-2016',4100, 1),
('7-4-2016',1400, 2)

INSERT INTO MedicineSaleDetails VALUES
(2,3, 2),
(1,2, 2),
(3,2, 3),
(1,3, 2),
(4,2,4)

INSERT INTO MedicineSupplyDetails VALUES
(2,3, 2),
(1,2, 2),
(3,2, 3),
(1,3, 2),
(4,2,2)

INSERT INTO Users VALUES
('abachkay','428f78bf42693da2f9f4b4ba537c5f101e275607'), --12345678
('johnsmith','2555889a0d6b5e7a3b0f74150bf01213500444ca') --1234abcd

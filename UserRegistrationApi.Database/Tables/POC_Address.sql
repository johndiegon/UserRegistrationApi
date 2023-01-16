CREATE TABLE POC_Address (
  Id int NOT NULL,
  UserId int DEFAULT NULL,
  City varchar(255) DEFAULT NULL,
  Country varchar(255) DEFAULT NULL,
  CountryCode varchar(45) DEFAULT NULL,
  State varchar(255) DEFAULT NULL,
  Street varchar(400) DEFAULT NULL,
  Type varchar(45) DEFAULT NULL,
  ZipCode varchar(45) DEFAULT NULL,
  Number varchar(45) DEFAULT NULL,
  Complement varchar(400) DEFAULT NULL,
  POC_Addresscol varchar(45) DEFAULT NULL,
  PRIMARY KEY (Id),
  --KEY userId_idx (UserId),
  --CONSTRAINT address_user FOREIGN KEY (UserId) REFERENCES POC_User (Id)
) 
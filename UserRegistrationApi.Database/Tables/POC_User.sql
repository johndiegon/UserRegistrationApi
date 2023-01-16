CREATE TABLE POC_User (
  Id int NOT NULL,
  Name varchar(255) DEFAULT NULL,
  DateBirth date DEFAULT NULL,
  Gender varchar(45) DEFAULT NULL,
  DocumentType varchar(45) DEFAULT NULL,
  Document varchar(100) DEFAULT NULL,
  PRIMARY KEY (Id)
)

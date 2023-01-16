CREATE TABLE POC_Contact (
  Id int NOT NULL,
  UserId int DEFAULT NULL,
  ContactType varchar(45) DEFAULT NULL,
  Contact varchar(255) DEFAULT NULL,
  PRIMARY KEY (Id),
  --KEY contact_user_idx (UserId),
  --CONSTRAINT contact_user FOREIGN KEY (UserId) REFERENCES POC_User (Id)
)

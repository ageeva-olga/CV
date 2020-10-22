-- Script Date: 10/22/2020 9:59 PM  - ErikEJ.SqlCeScripting version 3.5.2.86
CREATE TABLE [PersonalInfo] (
  [Id] TEXT NOT NULL
, [Name] TEXT NOT NULL
, [SureName] TEXT NOT NULL
, [Email] TEXT NOT NULL
, [Phone] TEXT NOT NULL
, CONSTRAINT [PK_PersonalInfo] PRIMARY KEY ([Id])
);

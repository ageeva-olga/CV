-- Script Date: 11/30/2020 10:37 PM  - ErikEJ.SqlCeScripting version 3.5.2.86
CREATE TABLE [Skills] (
  [Id] TEXT NOT NULL
, [Name] TEXT NOT NULL
, [SkillCategory] TEXT NOT NULL
, CONSTRAINT [PK_Skills] PRIMARY KEY ([Id])
, FOREIGN KEY ([SkillCategory]) REFERENCES  [SkillCategory]([Id])
);

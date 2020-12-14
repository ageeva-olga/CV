-- Script Date: 12/10/2020 10:00 PM  - ErikEJ.SqlCeScripting version 3.5.2.86
CREATE TABLE [SkillExperience] (
  [ExpId] TEXT NOT NULL
, [SkillId] TEXT NOT NULL
, CONSTRAINT [PK_SkillExperience] PRIMARY KEY ([ExpId],[SkillId])
);

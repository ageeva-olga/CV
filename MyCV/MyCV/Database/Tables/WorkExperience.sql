-- Script Date: 11/12/2020 9:31 PM  - ErikEJ.SqlCeScripting version 3.5.2.86
CREATE TABLE [WorkExperience] (
  [Id] text NOT NULL
, [Begin] bigint NOT NULL
, [End] bigint NOT NULL
, [WorkName] text NOT NULL
, [PositionName] text NOT NULL
, CONSTRAINT [sqlite_autoindex_WorkExperience_1] PRIMARY KEY ([Id])
);

/* Drop all non-system stored procs */
DECLARE @name VARCHAR(128)
DECLARE @constraint VARCHAR(254)
DECLARE @SQL VARCHAR(254)

SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'P' AND category = 0 ORDER BY [name])

WHILE @name is not null
BEGIN
    SELECT @SQL = 'DROP PROCEDURE [dbo].[' + RTRIM(@name) +']'
    EXEC (@SQL)
    SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'P' AND category = 0 AND [name] > @name ORDER BY [name])
END;

/* Drop all views */

SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'V' AND category = 0 ORDER BY [name])

WHILE @name IS NOT NULL
BEGIN
    SELECT @SQL = 'DROP VIEW [dbo].[' + RTRIM(@name) +']'
    EXEC (@SQL)
    SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'V' AND category = 0 AND [name] > @name ORDER BY [name])
END;

/* Drop all functions */

SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] IN (N'FN', N'IF', N'TF', N'FS', N'FT') AND category = 0 ORDER BY [name])

WHILE @name IS NOT NULL
BEGIN
    SELECT @SQL = 'DROP FUNCTION [dbo].[' + RTRIM(@name) +']'
    EXEC (@SQL)
    SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] IN (N'FN', N'IF', N'TF', N'FS', N'FT') AND category = 0 AND [name] > @name ORDER BY [name])
END;

/* Drop all Foreign Key constraints */

SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' ORDER BY TABLE_NAME)

WHILE @name is not null
BEGIN
    SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
    WHILE @constraint IS NOT NULL
    BEGIN
        SELECT @SQL = 'ALTER TABLE [dbo].[' + RTRIM(@name) +'] DROP CONSTRAINT [' + RTRIM(@constraint) +']'
        EXEC (@SQL)
        SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' AND CONSTRAINT_NAME <> @constraint AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
    END
SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' ORDER BY TABLE_NAME)
END;

/* Drop all Primary Key constraints */

SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' ORDER BY TABLE_NAME)

WHILE @name IS NOT NULL
BEGIN
    SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
    WHILE @constraint is not null
    BEGIN
        SELECT @SQL = 'ALTER TABLE [dbo].[' + RTRIM(@name) +'] DROP CONSTRAINT [' + RTRIM(@constraint)+']'
        EXEC (@SQL)
        SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' AND CONSTRAINT_NAME <> @constraint AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
    END
SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' ORDER BY TABLE_NAME)
END;

/* Drop all tables */

SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'U' AND category = 0 ORDER BY [name])

WHILE @name IS NOT NULL
BEGIN
    SELECT @SQL = 'DROP TABLE [dbo].[' + RTRIM(@name) +']'
    EXEC (@SQL)
    PRINT 'Dropped Table: ' + @name
    SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'U' AND category = 0 AND [name] > @name ORDER BY [name])
END;

/* Create all tables */
CREATE TABLE eos_subjects(
    id           INTEGER IDENTITY(1,1) NOT NULL ,
    xpos         INTEGER NOT NULL ,
    ypos         INTEGER NOT NULL ,
    title        VARCHAR (Max) ,
    color        VARCHAR (Max) ,
    details      VARCHAR (Max) ,
    radius       DECIMAL (28) ,
    eos_users_id INTEGER NOT NULL ,
    CONSTRAINT eos_subjects_PK PRIMARY KEY CLUSTERED (id)
WITH( ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON ) ON "default" ) ON "default"

CREATE TABLE eos_tasks(
    id              INTEGER IDENTITY(1,1) NOT NULL ,
    xpos            INTEGER ,
    ypos            INTEGER ,
    title           VARCHAR (Max) ,
	color           VARCHAR (Max) ,
    eos_subjects_id INTEGER NOT NULL ,
    CONSTRAINT eos_tasks_PK PRIMARY KEY CLUSTERED (id)
WITH( ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON ) ON "default" ) ON "default"

CREATE TABLE eos_users(
    id         INTEGER IDENTITY(1,1) NOT NULL ,
    first_name VARCHAR (Max) ,
    last_name  VARCHAR (Max) ,
    username   VARCHAR (Max) ,
    email      VARCHAR (Max) ,
    password   VARCHAR (Max) ,
    CONSTRAINT eos_users_PK PRIMARY KEY CLUSTERED (id)
WITH( ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON ) ON "default" ) ON "default"

ALTER TABLE eos_subjects
ADD CONSTRAINT eos_subjects_eos_users_FK FOREIGN KEY ( eos_users_id )
REFERENCES eos_users ( id )
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION

ALTER TABLE eos_tasks
ADD CONSTRAINT eos_tasks_eos_subjects_FK FOREIGN KEY ( eos_subjects_id )
REFERENCES eos_subjects ( id )
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
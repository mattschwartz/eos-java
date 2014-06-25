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
CREATE TABLE eos_subjects 
  ( 
     [id]             INTEGER IDENTITY(1, 1) NOT NULL, 
     [xpos]           INTEGER NOT NULL, 
     [ypos]			  INTEGER NOT NULL, 
     [title]		  VARCHAR (max), 
     [color]		  VARCHAR (max), 
     [details]		  VARCHAR (max), 
     [radius]		  DECIMAL (28), 
     [user_id]        INTEGER NOT NULL, 
     CONSTRAINT eos_subjects_pk PRIMARY KEY CLUSTERED (id) WITH( 
     allow_page_locks = on, allow_row_locks = on ) ON "default" 
  ) 
ON "default" 

CREATE TABLE eos_tasks 
  ( 
     [id]              INTEGER IDENTITY(1, 1) NOT NULL, 
     [title]           VARCHAR (max), 
     [color]           VARCHAR (max), 
     [comments]        VARCHAR (max), 
     [subject_id]      INTEGER NOT NULL, 
	 [user_id]        INTEGER NOT NULL, 
     CONSTRAINT eos_tasks_pk PRIMARY KEY CLUSTERED (id) WITH( allow_page_locks = 
     on, allow_row_locks = on ) ON "default" 
  ) 
ON "default" 

CREATE TABLE eos_users 
  ( 
     [id]              INTEGER IDENTITY(1, 1) NOT NULL, 
     [first_name]	   VARCHAR (max), 
     [last_name]       VARCHAR (max), 
     [username]        VARCHAR (max), 
     [email]           VARCHAR (max), 
     [password]        VARCHAR (max), 
     CONSTRAINT eos_users_pk PRIMARY KEY CLUSTERED (id) WITH( allow_page_locks = 
     on, allow_row_locks = on ) ON "default" 
  ) 
ON "default" 

ALTER TABLE eos_subjects 
  ADD CONSTRAINT eos_subjects_eos_users_fk FOREIGN KEY ( [user_id] ) 
  REFERENCES eos_users ( id ) ON DELETE no action ON UPDATE no action 

ALTER TABLE eos_tasks 
  ADD CONSTRAINT eos_tasks_eos_subjects_fk FOREIGN KEY ( [subject_id] ) 
  REFERENCES eos_subjects ( id ) ON DELETE no action ON UPDATE no action 

  ALTER TABLE eos_tasks 
  ADD CONSTRAINT eos_tasks_eos_users_fk FOREIGN KEY ( [user_id] ) 
  REFERENCES eos_users ( id ) ON DELETE no action ON UPDATE no action 
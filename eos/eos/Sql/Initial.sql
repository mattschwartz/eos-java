/* Drop all non-system stored procs */
DECLARE @name VARCHAR(128)
DECLARE @constraint VARCHAR(254)
DECLARE @SQL VARCHAR(254)

SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'P' AND category = 0 ORDER BY [name])

WHILE @name is NOT NULL
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

WHILE @name is NOT NULL
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
    WHILE @constraint is NOT NULL
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

CREATE TABLE eos_documents 
  ( 
     [id]              INTEGER IDENTITY(1, 1) NOT NULL, 
     [file_name]	   VARCHAR (MAX) NOT NULL, 
     [extension]       VARCHAR (MAX) NOT NULL, 
     [data]            VARBINARY (MAX) NOT NULL,
	 [user_id]	       INTEGER NOT NULL,
	 [subject_id]	   INTEGER NULL,
	 [task_id]	       INTEGER NULL,
	 [event_id]	       INTEGER NULL,
	 [created_on]	   DATETIME NOT NULL,
	 [updated_on]      DATETIME NULL,
     CONSTRAINT eos_documents_pk PRIMARY KEY CLUSTERED (id) WITH( allow_page_locks = 
     on, allow_row_locks = on ) ON "default" 
  ) 
ON "default" 

CREATE TABLE eos_events
  ( 
     [id]              INTEGER IDENTITY(1, 1) NOT NULL, 
     [title]		   VARCHAR (MAX) NOT NULL, 
     [description]     VARCHAR (MAX) NOT NULL, 
     [start_date]      DATETIME NOT NULL,
	 [end_date]		   DATETIME NOT NULL,
	 [subject_id]      INTEGER NULL,
	 [task_id]         INTEGER NULL,
	 [user_id]         INTEGER NOT NULL,
	 [created_on]	   DATETIME NOT NULL,
	 [updated_on]      DATETIME NULL,
     CONSTRAINT eos_events_pk PRIMARY KEY CLUSTERED (id) WITH( allow_page_locks = 
     on, allow_row_locks = on ) ON "default" 
  ) 
ON "default"

/* Create all tables */
CREATE TABLE eos_subjects 
  ( 
     [id]             INTEGER IDENTITY(1, 1) NOT NULL, 
     [xpos]           INTEGER NOT NULL, 
     [ypos]			  INTEGER NOT NULL, 
     [title]		  VARCHAR (MAX), 
     [color]		  VARCHAR (MAX), 
     [details]		  VARCHAR (MAX), 
     [radius]		  DECIMAL (28),
	 [user_id]        INTEGER NOT NULL, 
	 [created_on]	  DATETIME NOT NULL,
	 [updated_on]     DATETIME NULL,
     CONSTRAINT eos_subjects_pk PRIMARY KEY CLUSTERED (id) WITH( 
     allow_page_locks = on, allow_row_locks = on ) ON "default" 
  ) 
ON "default" 

CREATE TABLE eos_tasks 
  ( 
     [id]              INTEGER IDENTITY(1, 1) NOT NULL, 
     [title]           VARCHAR (MAX) NOT NULL, 
     [color]           VARCHAR (MAX) NOT NULL, 
     [comments]        VARCHAR (MAX) NULL, 
     [subject_id]      INTEGER NOT NULL, 
	 [user_id]         INTEGER NOT NULL, 
	 [created_on]      DATETIME NOT NULL,
	 [updated_on]      DATETIME NULL,
     CONSTRAINT eos_tasks_pk PRIMARY KEY CLUSTERED (id) WITH( allow_page_locks = 
     on, allow_row_locks = on ) ON "default" 
  ) 
ON "default" 

CREATE TABLE eos_users 
  ( 
     [id]              INTEGER IDENTITY(1, 1) NOT NULL, 
     [first_name]	   VARCHAR (MAX), 
     [last_name]       VARCHAR (MAX), 
     [username]        VARCHAR (MAX), 
     [email]           VARCHAR (MAX), 
     [password]        VARCHAR (MAX),
	 [created_on]	   DATETIME NOT NULL,
	 [updated_on]      DATETIME NULL, 
     CONSTRAINT eos_users_pk PRIMARY KEY CLUSTERED (id) WITH( allow_page_locks = 
     on, allow_row_locks = on ) ON "default" 
  ) 
ON "default" 

ALTER TABLE eos_documents
  ADD CONSTRAINT eos_attachment_on_subject_fk FOREIGN KEY ( subject_id ) 
  REFERENCES eos_subjects ( id ) ON DELETE no action ON UPDATE no action 

ALTER TABLE eos_documents
  ADD CONSTRAINT eos_documents_on_task_fk FOREIGN KEY ( task_id ) 
  REFERENCES eos_tasks ( id ) ON DELETE no action ON UPDATE no action 

ALTER TABLE eos_documents
  ADD CONSTRAINT eos_documents_on_event_fk FOREIGN KEY ( event_id ) 
  REFERENCES eos_events ( id ) ON DELETE no action ON UPDATE no action 

ALTER TABLE eos_documents
  ADD CONSTRAINT eos_documents_user_fk FOREIGN KEY ( [user_id] ) 
  REFERENCES eos_users ( id ) ON DELETE no action ON UPDATE no action 

ALTER TABLE eos_events
  ADD CONSTRAINT eos_events_users_fk FOREIGN KEY ( [user_id] ) 
  REFERENCES eos_users ( id ) ON DELETE no action ON UPDATE no action 

ALTER TABLE eos_events
  ADD CONSTRAINT eos_events_subject_fk FOREIGN KEY ( subject_id ) 
  REFERENCES eos_subjects ( id ) ON DELETE no action ON UPDATE no action 

ALTER TABLE eos_subjects 
  ADD CONSTRAINT eos_subjects_eos_users_fk FOREIGN KEY ( [user_id] ) 
  REFERENCES eos_users ( id ) ON DELETE no action ON UPDATE no action 

ALTER TABLE eos_tasks 
  ADD CONSTRAINT eos_tasks_eos_subjects_fk FOREIGN KEY ( [subject_id] ) 
  REFERENCES eos_subjects ( id ) ON DELETE no action ON UPDATE no action 

ALTER TABLE eos_tasks 
  ADD CONSTRAINT eos_tasks_eos_users_fk FOREIGN KEY ( [user_id] ) 
  REFERENCES eos_users ( id ) ON DELETE no action ON UPDATE no action 
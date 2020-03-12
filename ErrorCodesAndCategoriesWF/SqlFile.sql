-- 1. Создание таблицы [ErrorCodes]

CREATE TABLE [dbo].[ErrorCodes]
(
	[Code] INT NOT NULL,
	[Text] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [PK_ErrorCodes] PRIMARY KEY ([Code] ASC)
)

-- 2. Создание таблицы [Categories]

CREATE TABLE [dbo].[Categories]
(
	[ID] INT NOT NULL,
	[Name] NVARCHAR(MAX) NOT NULL,
	[Parent] INT NOT NULL,
	[Image] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Categories] PRIMARY KEY ([ID] ASC)
)

GO

-- 3. Создание хранимой процедуры SelectErrorCodes для получения [Code] = переданному коду 

CREATE PROC SelectErrorCodes
	@selectCode INT OUTPUT,
	@codeNew INT
AS
BEGIN
	SELECT 
		@selectCode = COUNT(Code) 
	FROM 
		[ErrorCodes]
	WHERE [Code] = @codeNew
END

GO

 -- 4. Создание хранимой процедуры AddErrorCodes для добавления данных в таблицу [ErrorCodes]
 -- с предварительной проверкой на наличие повторяющихся элементов 

 CREATE PROC AddErrorCodes 
	@code INT,
	@text NVARCHAR(MAX)
AS
BEGIN
	DECLARE @selectCode INT
	EXEC SelectErrorCodes @selectCode OUTPUT, @code
	IF (@selectCode = 0)
	INSERT INTO [ErrorCodes] ([Code],[Text]) VALUES (@code,@text)
END

GO

 -- ИЛИ можем объединить хранимые процедуры SelectErrorCodes и AddErrorCodes

CREATE PROC AddErrorCodes 
	@code INT,
	@text NVARCHAR(MAX)
AS
BEGIN
	DECLARE @count INT
	SELECT 
		@count = COUNT(Code)
	FROM
		[ErrorCodes]
	WHERE [Code] = @code
	IF (@count = 0)
	INSERT INTO [ErrorCodes] ([Code],[Text]) VALUES (@code,@text)
END

 -- 5. Проверяющий код работаспособности созданных хранимых процедур SelectErrorCodes, 
 -- AddErrorCodes для таблицы [ErrorCodes] 

DECLARE @code INT
DECLARE @text NVARCHAR(MAX)

SET @code = 1
SET @text = N'qqq'

EXEC AddErrorCodes @code, @text 

SELECT * FROM [ErrorCodes]

DELETE FROM [ErrorCodes] 
WHERE [Code] >= 0 OR [Code] <= 1

GO

-- 6. Создание хранимой процедуры SelectCategories для получения [ID] = переданному ID

CREATE PROC SelectCategories
	@selectID INT OUTPUT,
	@IdNew INT
AS
BEGIN
	SELECT
		@selectID = COUNT(ID)
	FROM
		[Categories]
	WHERE [ID] = @IdNew
END

GO

 -- 7. Создание хранимой процедуры AddCategories для добавления данных в таблицу [Categories]
 -- с предварительной проверкой на наличие повторяющихся элементов 

CREATE PROC AddCategories
	@id INT,
	@name NVARCHAR(MAX),
	@parent INT,
	@image NVARCHAR(MAX)
AS
BEGIN
	DECLARE @selectID INT
	EXEC SelectCategories @selectID OUTPUT, @id
	IF (@selectID = 0)
	INSERT INTO [Categories] ([ID],[Name],[Parent],[Image]) VALUES (@id,@name,@parent,@image);
END

GO

 -- ИЛИ можем объединить хранимые процедуры SelectCategories и AddCategories

CREATE PROC AddCategories
	@id INT,
	@name NVARCHAR(MAX),
	@parent INT,
	@image NVARCHAR(MAX)
AS
BEGIN
	DECLARE @count INT
	SELECT
		@count = COUNT(ID)
	FROM 
		[Categories]
	WHERE [ID] = @id
	IF (@count = 0)
	INSERT INTO [Categories] ([ID],[Name],[Parent],[Image]) VALUES (@id,@name,@parent,@image);
END

GO

 -- 8. Проверяющий код работаспособности созданных хранимых процедур SelectCategories, 
 -- AddCategories для таблицы [Categories] 

DECLARE @id INT
DECLARE @name NVARCHAR(MAX)
DECLARE @parent INT
DECLARE @image NVARCHAR(MAX)

SET @id = 1
SET @name = N'sss'
SET @parent = 2
SET @image = N'ccccc'

EXEC AddCategories @id, @name, @parent, @image

SELECT * FROM [Categories]

DELETE FROM [Categories]

GO

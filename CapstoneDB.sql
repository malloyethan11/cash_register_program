-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
SET NOCOUNT ON; -- Report only errors

-- --------------------------------------------------------------------------------
-- Drop Tables
-- --------------------------------------------------------------------------------
IF OBJECT_ID( 'TTransactionItems' )			IS NOT NULL DROP TABLE		TTransactionItems
IF OBJECT_ID( 'TTransactions' )				IS NOT NULL DROP TABLE		TTransactions
IF OBJECT_ID( 'TItems' )					IS NOT NULL DROP TABLE		TItems
IF OBJECT_ID( 'TVendors' )					IS NOT NULL DROP TABLE		TVendors
IF OBJECT_ID( 'TCategories' )				IS NOT NULL DROP TABLE		TCategories
IF OBJECT_ID( 'TStates' )					IS NOT NULL DROP TABLE		TStates
IF OBJECT_ID( 'TPaymentTypes' )				IS NOT NULL DROP TABLE		TPaymentTypes
IF OBJECT_ID( 'TTransactionTypes' )			IS NOT NULL DROP TABLE		TTransactionTypes
IF OBJECT_ID( 'TUsers' )					IS NOT NULL DROP TABLE		TUsers
IF OBJECT_ID( 'TReports' )					IS NOT NULL DROP TABLE		TReports

-- --------------------------------------------------------------------------------
-- Drop Views
-- --------------------------------------------------------------------------------


-- --------------------------------------------------------------------------------
-- Drop procedure statements
-- --------------------------------------------------------------------------------

IF OBJECT_ID( 'uspAddItem' )				IS NOT NULL DROP PROCEDURE	uspAddItem
IF OBJECT_ID( 'uspAddUser' )				IS NOT NULL DROP PROCEDURE	uspAddUser
IF OBJECT_ID( 'uspTransaction' )			IS NOT NULL DROP PROCEDURE	uspTransaction
IF OBJECT_ID( 'uspCheckoutItems' )			IS NOT NULL DROP PROCEDURE	uspCheckoutItems
IF OBJECT_ID( 'uspReturnItems' )			IS NOT NULL DROP PROCEDURE	uspReturnItems

-- --------------------------------------------------------------------------------
-- Create Tables
-- --------------------------------------------------------------------------------

CREATE TABLE TTransactionItems
(
	 intTransactionItemID	INTEGER IDENTITY(1,1)		NOT NULL
	,intTransactionID		INTEGER						NOT NULL
	,intItemID				INTEGER						NOT NULL
	,intItemAmount			INTEGER						NOT NULL

	,CONSTRAINT TTransactionItems_PK PRIMARY KEY ( intTransactionItemID	)
)

CREATE TABLE TItems
(
	 intItemID				INTEGER IDENTITY(1,1)		NOT NULL
	,strSKU					VARCHAR(50)					NOT NULL
	,strItemName			VARCHAR	(50)				NOT NULL
	,strItemDesc			VARCHAR(50)					NOT NULL
	,decItemPrice			DECIMAL(8,2)				NOT NULL
	,intInventoryAmt		INTEGER						NOT NULL
	,intSafetyStockAmt		INTEGER						NOT NULL
	,strUPC					VARCHAR(50)					NOT NULL
	,imgItemImage			IMAGE						NOT NULL

	,CONSTRAINT TItems_PK PRIMARY KEY ( intItemID	)
)

CREATE TABLE TTransactions
(
	 intTransactionID		INTEGER IDENTITY(1,1)		NOT NULL
	,intTransactionTypeID	INTEGER						NOT NULL
	,intPaymentTypeID		INTEGER						NOT NULL
	,strFirstName			VARCHAR(50)					NOT NULL
	,strLastName			VARCHAR(50)					NOT NULL
	,strAddress				VARCHAR(50)					NOT NULL
	,strCity				VARCHAR(50)					NOT NULL
	,intStateID				INTEGER						NOT NULL
	,strZip					VARCHAR(50)					NOT NULL
	,strPhoneNumber			VARCHAR(50)					NOT NULL
	,strEmail				VARCHAR(50)					NOT NULL
	,strCreditCard			VARCHAR(50)	
	,strExpirationDate		VARCHAR(5)		
	,strSecurityCode		VARCHAR(3)		
	,monTotalPrice			MONEY						NOT NULL
	,monSalesTax			MONEY						NOT NULL

	,CONSTRAINT TTransactions_PK PRIMARY KEY ( intTransactionID	)
)

CREATE TABLE TVendors
(
	 intVendorID			INTEGER IDENTITY(1,1)		NOT NULL
	,strVendorName			VARCHAR(50)					NOT NULL

	,CONSTRAINT TVendors_PK PRIMARY KEY ( intVendorID )
)

CREATE TABLE TStates
(
	 intStateID				INTEGER IDENTITY(1,1)		NOT NULL
	,strState				VARCHAR(50)					NOT NULL

	,CONSTRAINT TStates_PK PRIMARY KEY ( intStateID )
)

CREATE TABLE TCategories
(
	 intCategoryID			INTEGER IDENTITY(1,1)		NOT NULL
	,strCategory			VARCHAR(50)					NOT NULL

	,CONSTRAINT TCategories_PK PRIMARY KEY ( intCategoryID )
)

CREATE TABLE TTransactionTypes
(
	 intTransactionTypeID	INTEGER IDENTITY(1,1)		NOT NULL
	,strTransactionType		VARCHAR(50)					NOT NULL
	,CONSTRAINT TTransactionTypes_PK PRIMARY KEY ( intTransactionTypeID )
)

CREATE TABLE TPaymentTypes
(
	 intPaymentTypeID		INTEGER IDENTITY(1,1)		NOT NULL
	,strPaymentType			VARCHAR(50)					NOT NULL
	,CONSTRAINT TPaymentTypes_PK PRIMARY KEY ( intPaymentTypeID )
)

CREATE TABLE TUsers
(
	 intUserID				INTEGER IDENTITY(1,1)		NOT NULL
	,strUsername			VARCHAR(50)					NOT NULL
	,strPassword			VARCHAR(50)					NOT NULL
	,blnCheckout			BIT							NOT NULL
	,blnReturns				BIT							NOT NULL
	,blnAddItems			BIT							NOT NULL
	,blnEditItems			BIT							NOT NULL
	,blnDeleteItems			BIT							NOT NULL
	,blnMassPricing			BIT							NOT NULL
	,blnAddVendors			BIT							NOT NULL
	,blnEditVendors			BIT							NOT NULL

	,CONSTRAINT TUsers_PK PRIMARY KEY ( intUserID )
)

CREATE TABLE TReports
(
	 intReportID			INTEGER IDENTITY(1,1)		NOT NULL
	,strReportType			VARCHAR(50)					NOT NULL
	,blnDaily				BIT
	,blnWeekly				BIT	
	,blnMonthly				BIT	
	,blnYearly				BIT	
	,dtDailyReportDate		DATETIME	
	,dtWeeklyReportDate		DATETIME	
	,dtMonthlyReportDate	DATETIME	
	,dtYearlyReportDate		DATETIME	

	,CONSTRAINT TReports_PK PRIMARY KEY ( intReportID )
)



-- --------------------------------------------------------------------------------
-- Identify and Create Foreign Keys
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						Column(s)
-- -	-----							------						---------
-- 1	TTransactionItems				TTransactions				intTransactionID
-- 2	TTransactionItems				TItems						intItemID
-- 3	TTransactions					TTransactionTypes			intTransactionTypeID
-- 4	TTransactions					TPaymentTypes				intPaymentTypeID
-- 5	TTransactions					TStates						intStateID
-- 6	TItems							TVendors					intVendorID
-- 7	TItems							TCategories					intCategoryID

-- 1
ALTER TABLE TTransactionItems ADD CONSTRAINT TTransactionItems_TTransactions_FK
FOREIGN KEY ( intTransactionID ) REFERENCES TTransactions ( intTransactionID )

-- 2
ALTER TABLE TTransactionItems ADD CONSTRAINT TTransactionItems_TItems_FK
FOREIGN KEY ( intItemID ) REFERENCES TItems ( intItemID )

-- 3
ALTER TABLE TTransactions ADD CONSTRAINT TTransactions_TTransactionTypes_FK
FOREIGN KEY ( intTransactionTypeID ) REFERENCES TTransactionTypes ( intTransactionTypeID )

-- 4
ALTER TABLE TTransactions ADD CONSTRAINT TTransactions_TPaymentTypes_FK
FOREIGN KEY ( intPaymentTypeID ) REFERENCES TPaymentTypes ( intPaymentTypeID )

-- 5
ALTER TABLE TTransactions ADD CONSTRAINT TTransactions_TStates_FK
FOREIGN KEY ( intStateID ) REFERENCES TStates ( intStateID )



-- --------------------------------------------------------------------------------
-- Insert Statements
-- --------------------------------------------------------------------------------

INSERT INTO TPaymentTypes( strPaymentType )
VALUES	 ( 'Cash' )
		,( 'Credit Card' )

INSERT INTO TTransactionTypes( strTransactionType )
VALUES	 ( 'Purchase' )
		,( 'Return' )

INSERT INTO TCategories( strCategory )
VALUES	 ( 'Booklet' )
		,( 'Crucifix' )
		,( 'Medals' )
		,( 'Prayer Token' )
		,( 'Keychain' )
		,( 'Necklace ' )
		,( 'Rosary' )
		,( 'Scapular' )
		,( 'Baptism & Christening' )
		,( 'St. Michael' )
		,( 'Confirmation' )
		,( 'Holy Cards' )
		,( 'Holy Water Fonts' )
		,( 'Home Goods' )
		,( 'Jewelry' )
		,( 'Medals' )
		,( 'Occasions' )
		,( 'Olive Wood' )
		,( 'Our Lady of Sorrows' )
		,( 'Picture Frames' )
		,( 'Plaques' )
		,( 'Pocket Tokens' )
		,( 'Rosaries' )
		,( 'Sacred Art' )
		,( 'Saint Medals' )
		,( 'Statuary' )
		,( 'St. Benedict' )
		,( 'St. Christopher' )
		,( 'St. Francis of Assisi' )
		,( 'Vatican Art' )
		,( 'Wall Crosses & Crucifixes' )
		,( 'Candles & Accessories' )
		,( 'Furniture' )
		,( 'Sacred Vessels' )
		,( 'Sanctuary Appointments' )
		,( 'Textiles' )

INSERT INTO TStates ( strState )
VALUES	 ( 'Alabama')
		,( 'Alaska')
		,( 'Arizona')
		,( 'Arkansas')
		,( 'California')
		,( 'Colorado')
		,( 'Connecticut')
		,( 'Delaware')
		,( 'District of Columbia')
		,( 'Florida')
		,( 'Georgia')
		,( 'Hawaii')
		,( 'Idaho')
		,( 'Illinois')
		,( 'Indiana')
		,( 'Iowa')
		,( 'Kansas')
		,( 'Kentucky')
		,( 'Louisiana')
		,( 'Maine')
		,( 'Maryland')
		,( 'Massachusetts')
		,( 'Michigan')
		,( 'Minnesota')
		,( 'Mississippi')
		,( 'Missouri')
		,( 'Montana')
		,( 'Nebraska')
		,( 'Nevada')
		,( 'New Hampshire')
		,( 'New Jersey')
		,( 'New Mexico')
		,( 'New York')
		,( 'North Carolina')
		,( 'North Dakota')
		,( 'Ohio')
		,( 'Oklahoma')
		,( 'Oregon')
		,( 'Pennsylvania')
		,( 'Puerto Rico')
		,( 'Rhode Island')
		,( 'South Carolina')
		,( 'South Dakota')
		,( 'Tennessee')
		,( 'Texas')
		,( 'Utah')
		,( 'Vermont')
		,( 'Virginia')
		,( 'Washington')
		,( 'West Virginia')
		,( 'Wisconsin')
		,( 'Wyoming')

INSERT INTO TReports( strReportType, blnDaily, blnWeekly, blnMonthly, blnYearly, dtDailyReportDate, dtWeeklyReportDate, dtMonthlyReportDate, dtYearlyReportDate )
VALUES ('Sales Report', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
	  ,('Inventory Report', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
	  ,('Tax Report', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
	  ,('Deposit Report', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)


-- --------------------------------------------------------------------------------
-- Stored Procedures
-- --------------------------------------------------------------------------------

-- Add an Item
GO

CREATE PROCEDURE uspAddItem
	 @strSKU			AS VARCHAR(50)
	,@strItemName		AS VARCHAR(50)
	,@strItemDesc		AS VARCHAR(50)
	,@decItemPrice		AS DECIMAL
	,@intInventoryAmt	AS INTEGER
	,@intSafetyStockAmt	AS INTEGER
	,@strUPC			AS VARCHAR(50)
	,@imgItemImage		AS IMAGE
AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	INSERT INTO TItems (strSKU, strItemName, strItemDesc, decItemPrice, intInventoryAmt, intSafetyStockAmt, strUPC, imgItemImage )
	VALUES				(@strSKU, @strItemName, @strItemDesc, @decItemPrice, @intInventoryAmt, @intSafetyStockAmt, @strUPC, @imgItemImage )


COMMIT TRANSACTION

GO


-- Add a User
GO

CREATE PROCEDURE uspAddUser
	 @strUserName		AS VARCHAR(50)
	,@strPassword		AS VARCHAR(50)
	,@blnCheckout		BIT
	,@blnReturns		BIT
	,@blnAddItems		BIT
	,@blnEditItems		BIT
	,@blnDeleteItems	BIT
	,@blnMassPricing	BIT
AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	INSERT INTO TUsers (strUsername, strPassword, blnCheckout, blnReturns, blnAddItems, blnEditItems, blnDeleteItems, blnMassPricing)
	VALUES				(@strUsername, @strPassword, @blnCheckout, @blnReturns, @blnAddItems, @blnEditItems, @blnDeleteItems, @blnMassPricing)


COMMIT TRANSACTION

GO


-- Checkout 
GO

CREATE PROCEDURE uspTransaction
	 
	 @intTransactionTypeID	INTEGER
	,@intPaymentTypeID		INTEGER
	,@strFirstName			VARCHAR(50)
	,@strLastName			VARCHAR(50)
	,@strAddress			VARCHAR(50)
	,@strCity				VARCHAR(50)
	,@intStateID			INTEGER
	,@strZip				VARCHAR(50)
	,@strPhoneNumber		VARCHAR(50)
	,@strEmail				VARCHAR(50)
	,@strCreditCard			VARCHAR(50)
	,@strExpirationDate		VARCHAR(5)
	,@strSecurityCode		VARCHAR(3)
	,@monTotalPrice			MONEY
	,@monSalesTax			MONEY
AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	DECLARE @intTransactionID	AS INTEGER
	DECLARE @intInventoryAmt	AS INTEGER

	INSERT INTO TTransactions(intTransactionTypeID, intPaymentTypeID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, strCreditCard, strExpirationDate, strSecurityCode, monTotalPrice, monSalesTax)
	VALUES				(@intTransactionTypeID, @intPaymentTypeID, @strFirstName, @strLastName, @strAddress, @strCity, @intStateID, @strZip, @strPhoneNumber, @strEmail, @strCreditCard, @strExpirationDate, @strSecurityCode, @monTotalPrice, @monSalesTax) 


COMMIT TRANSACTION

GO


-- Checkout Items 
GO

CREATE PROCEDURE uspCheckoutItems

	 @intItemID				INTEGER
	,@intItemAmount			INTEGER
AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	DECLARE @intTransactionID	AS INTEGER
	DECLARE @intInventoryAmt	AS INTEGER

	SELECT @intTransactionID = MAX(intTransactionID)
	FROM   TTransactions (TABLOCKX)

	SELECT @intInventoryAmt = (@intInventoryAmt)
	FROM   TItems (TABLOCKX)

	INSERT INTO TTransactionItems(intTransactionID, intItemID, intItemAmount)
	VALUES						(@intTransactionID, @intItemID, @intItemAmount)

	UPDATE TItems SET intInventoryAmt = ((SELECT intInventoryAmt FROM TItems WHERE intItemID = @intItemID) - @intItemAmount)
				WHERE intItemID = @intItemID

COMMIT TRANSACTION

GO


-- Return Items 
GO

CREATE PROCEDURE uspReturnItems

	 @intItemID				INTEGER
	,@intItemAmount			INTEGER
AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	DECLARE @intTransactionID	AS INTEGER
	DECLARE @intInventoryAmt	AS INTEGER

	SELECT @intTransactionID = MAX(intTransactionID)
	FROM   TTransactions (TABLOCKX)

	SELECT @intInventoryAmt = (@intInventoryAmt)
	FROM   TItems (TABLOCKX)

	INSERT INTO TTransactionItems(intTransactionID, intItemID, intItemAmount)
	VALUES						(@intTransactionID, @intItemID, @intItemAmount)

	UPDATE TItems SET intInventoryAmt = ((SELECT intInventoryAmt FROM TItems WHERE intItemID = @intItemID) + @intItemAmount)
				WHERE intItemID = @intItemID

COMMIT TRANSACTION

GO



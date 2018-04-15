

IF OBJECT_ID(N'[dbo].[Usp_T_Sys_User_Insert]') IS NOT NULL
BEGIN
	PRINT 'Dropping Procedure [dbo].[Usp_T_Sys_User_Insert]'
	DROP PROCEDURE [dbo].[Usp_T_Sys_User_Insert]
END


GO

PRINT 'Create Procedure [dbo].[Usp_T_Sys_User_Insert]'

GO

CREATE PROCEDURE [dbo].[Usp_T_Sys_User_Insert]
	@GUID varchar(50),
	@Account nvarchar(50),
	@Pwd varchar(32),
	@UserState tinyint,
	@UserType nvarchar(32),
	@TrueName nvarchar(50),
	@DepartmentGuid varchar(32),
	@PositionGuid varchar(32),
	@CreatePerson varchar(32),
	@CreateTime datetime,
	@ExpirationDate datetime,
	@QQ varchar(20),
	@IsAdmin bit,
	@TelPhone varchar(15),
	@QQGroup nvarchar(50),
	@ReturnInfo nvarchar(500),
	@CityName nvarchar(50),
	@ProvinceName nvarchar(50),
	@Email varchar(50),
	@Gender nvarchar(5),
	@ZFBAccount nvarchar(50)
AS

SET NOCOUNT ON

INSERT INTO [dbo].[T_Sys_User] (
	[GUID],
	[Account],
	[Pwd],
	[UserState],
	[UserType],
	[TrueName],
	[DepartmentGuid],
	[PositionGuid],
	[CreatePerson],
	[CreateTime],
	[ExpirationDate],
	[QQ],
	[IsAdmin],
	[TelPhone],
	[QQGroup],
	[ReturnInfo],
	[CityName],
	[ProvinceName],
	[Email],
	[Gender],
	[ZFBAccount]
) VALUES (
	@GUID,
	@Account,
	@Pwd,
	@UserState,
	@UserType,
	@TrueName,
	@DepartmentGuid,
	@PositionGuid,
	@CreatePerson,
	@CreateTime,
	@ExpirationDate,
	@QQ,
	@IsAdmin,
	@TelPhone,
	@QQGroup,
	@ReturnInfo,
	@CityName,
	@ProvinceName,
	@Email,
	@Gender,
	@ZFBAccount
)

GO

--GRANT EXEC ON [dbo].[Usp_T_Sys_User_Insert] TO shafeUser

GO


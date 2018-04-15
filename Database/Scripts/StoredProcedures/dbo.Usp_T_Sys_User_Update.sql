

IF OBJECT_ID(N'[dbo].[Usp_T_Sys_User_Update]') IS NOT NULL
BEGIN
	PRINT 'Dropping Procedure [dbo].[Usp_T_Sys_User_Update]'
	DROP PROCEDURE [dbo].[Usp_T_Sys_User_Update]
END


GO

PRINT 'Create Procedure [dbo].[Usp_T_Sys_User_Update]'

GO

CREATE PROCEDURE [dbo].[Usp_T_Sys_User_Update]
	@GUID varchar(50),
	@Account nvarchar(50),
	@Pwd varchar(32),
	@UserState tinyint,
	@UserType nvarchar(32),
	@TrueName nvarchar(50),
	@DepartmentGuid varchar(32),
	@PositionGuid varchar(32),
	@LastLoginTime datetime,
	@LastLoginIP varchar(60),
	@LoginTimes int,
	@LoginErrorTimes int,
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
	@ZFBAccount nvarchar(50),
	@UpdateTime datetime
AS

SET NOCOUNT ON

UPDATE [dbo].[T_Sys_User] SET
	[Account] = @Account,
	[Pwd] = @Pwd,
	[UserState] = @UserState,
	[UserType] = @UserType,
	[TrueName] = @TrueName,
	[DepartmentGuid] = @DepartmentGuid,
	[PositionGuid] = @PositionGuid,
	[LastLoginTime] = @LastLoginTime,
	[LastLoginIP] = @LastLoginIP,
	[LoginTimes] = @LoginTimes,
	[LoginErrorTimes] = @LoginErrorTimes,
	[ExpirationDate] = @ExpirationDate,
	[QQ] = @QQ,
	[IsAdmin] = @IsAdmin,
	[TelPhone] = @TelPhone,
	[QQGroup] = @QQGroup,
	[ReturnInfo] = @ReturnInfo,
	[CityName] = @CityName,
	[ProvinceName] = @ProvinceName,
	[Email] = @Email,
	[Gender] = @Gender,
	[ZFBAccount] = @ZFBAccount,
	[UpdateTime] = @UpdateTime
WHERE
	[GUID] = @GUID

GO

--GRANT EXEC ON [dbo].[Usp_T_Sys_User_Update] TO shafeUser

GO


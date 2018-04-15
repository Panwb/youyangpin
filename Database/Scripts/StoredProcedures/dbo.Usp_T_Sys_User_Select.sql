

IF OBJECT_ID(N'[dbo].[Usp_T_Sys_User_Select]') IS NOT NULL
BEGIN
	PRINT 'Dropping Procedure [dbo].[Usp_T_Sys_User_Select]'
	DROP PROCEDURE [dbo].[Usp_T_Sys_User_Select]
END


GO

PRINT 'Create Procedure [dbo].[Usp_T_Sys_User_Select]'

GO

CREATE PROCEDURE [dbo].[Usp_T_Sys_User_Select]
	@GUID varchar(50)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[GUID],
	[Account],
	[Pwd],
	[UserState],
	[UserType],
	[TrueName],
	[DepartmentGuid],
	[PositionGuid],
	[LastLoginTime],
	[LastLoginIP],
	[LoginTimes],
	[LoginErrorTimes],
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
	[ZFBAccount],
	[UpdateTime]
FROM
	[dbo].[T_Sys_User]
WHERE
	[GUID] = @GUID

GO

--GRANT EXEC ON [dbo].[Usp_T_Sys_User_Select] TO shafeUser

GO


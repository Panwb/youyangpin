

IF OBJECT_ID(N'[dbo].[Usp_TYYP_StudioHost_Insert]') IS NOT NULL
BEGIN
	PRINT 'Dropping Procedure [dbo].[Usp_TYYP_StudioHost_Insert]'
	DROP PROCEDURE [dbo].[Usp_TYYP_StudioHost_Insert]
END


GO

PRINT 'Create Procedure [dbo].[Usp_TYYP_StudioHost_Insert]'

GO

CREATE PROCEDURE [dbo].[Usp_TYYP_StudioHost_Insert]
	@UserId varchar(50),
	@StudioHostName nvarchar(20),
	@AddTime datetime
AS

SET NOCOUNT ON

INSERT INTO [dbo].[TYYP_StudioHost] (
	[UserId],
	[StudioHostName],
	[AddTime]
) VALUES (
	@UserId,
	@StudioHostName,
	@AddTime
)


GO

--GRANT EXEC ON [dbo].[Usp_TYYP_StudioHost_Insert] TO shafeUser

GO


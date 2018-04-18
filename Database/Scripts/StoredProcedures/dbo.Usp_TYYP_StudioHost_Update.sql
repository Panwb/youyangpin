

IF OBJECT_ID(N'[dbo].[Usp_TYYP_StudioHost_Update]') IS NOT NULL
BEGIN
	PRINT 'Dropping Procedure [dbo].[Usp_TYYP_StudioHost_Update]'
	DROP PROCEDURE [dbo].[Usp_TYYP_StudioHost_Update]
END


GO

PRINT 'Create Procedure [dbo].[Usp_TYYP_StudioHost_Update]'

GO

CREATE PROCEDURE [dbo].[Usp_TYYP_StudioHost_Update]
	@UserId varchar(50),
	@StudioHostName nvarchar(20),
	@TKName nvarchar(30),
	@Height int,
	@Weight int,
	@ShoeSize int,
	@ClothesSize varchar(5),
	@Address nvarchar(200),
	@LinkmanName nvarchar(30),
	@LinkmanPhone varchar(30),
	@WeChat varchar(30),
	@QQ varchar(30),
	@Email varchar(30),
	@FansNum int,
	@AverageDailyViews int,
	@VerticalFieldCode nvarchar(100),
	@MainPopActivityType nvarchar(50),
	@PerCustomerTransactionHight decimal(10, 2),
	@PerCustomerTransactionLow decimal(10, 2),
	@AlipayAccount varchar(30),
	@AccountBalance money,
	@Margin money,
	@CheckStatus nvarchar(3),
	@Remark nvarchar(500),
	@DailyBeginTime datetime,
	@DailyEndTime datetime,
	@UpdateTime datetime
AS

SET NOCOUNT ON

UPDATE [dbo].[TYYP_StudioHost] SET
	[StudioHostName] = @StudioHostName,
	[TKName] = @TKName,
	[Height] = @Height,
	[Weight] = @Weight,
	[ShoeSize] = @ShoeSize,
	[ClothesSize] = @ClothesSize,
	[Address] = @Address,
	[LinkmanName] = @LinkmanName,
	[LinkmanPhone] = @LinkmanPhone,
	[WeChat] = @WeChat,
	[QQ] = @QQ,
	[Email] = @Email,
	[FansNum] = @FansNum,
	[AverageDailyViews] = @AverageDailyViews,
	[VerticalFieldCode] = @VerticalFieldCode,
	[MainPopActivityType] = @MainPopActivityType,
	[PerCustomerTransactionHight] = @PerCustomerTransactionHight,
	[PerCustomerTransactionLow] = @PerCustomerTransactionLow,
	[AlipayAccount] = @AlipayAccount,
	[AccountBalance] = @AccountBalance,
	[Margin] = @Margin,
	[CheckStatus] = @CheckStatus,
	[Remark] = @Remark,
	[DailyBeginTime] = @DailyBeginTime,
	[DailyEndTime] = @DailyEndTime,
	[UpdateTime] = @UpdateTime
WHERE
	[UserId] = @UserId

GO

--GRANT EXEC ON [dbo].[Usp_TYYP_StudioHost_Update] TO shafeUser

GO




IF OBJECT_ID(N'[dbo].[Usp_TYYP_Order_SelectByUserId]') IS NOT NULL
BEGIN
	PRINT 'Dropping Procedure [dbo].[Usp_TYYP_Order_SelectByUserId]'
	DROP PROCEDURE [dbo].[Usp_TYYP_Order_SelectByUserId]
END


GO

PRINT 'Create Procedure [dbo].[Usp_TYYP_Order_SelectByUserId]'

GO

CREATE PROCEDURE [dbo].[Usp_TYYP_Order_SelectByUserId]
	@UserId varchar(50)
AS

SET NOCOUNT ON
SELECT  O.OrderID,
		S.ShopName ,
        S.WangWangNo ,
        M.LinkmanName,
		M.LinkmanPhone,
		O.OrderNo,
		O.OrderStatus,
		O.DirectionalPlanStatus
FROM    dbo.TYYP_Order AS O
        INNER JOIN dbo.TYYP_Shop AS S ON O.ShopGuid = S.ShopId
        INNER JOIN dbo.TYYP_Merchant AS M ON M.UserId = S.UserId
		INNER JOIN dbo.TYYP_StudioHost AS SH ON O.StudioHostUserId = SH.UserId
WHERE   SH.UserId = @UserId;

GO


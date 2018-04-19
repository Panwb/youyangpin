

IF OBJECT_ID(N'[dbo].[Usp_TYYP_Goods_SelectByOrderId]') IS NOT NULL
    BEGIN
        PRINT 'Dropping Procedure [dbo].[Usp_TYYP_Goods_SelectByOrderId]';
        DROP PROCEDURE [dbo].[Usp_TYYP_Goods_SelectByOrderId];
    END;


GO

PRINT 'Create Procedure [dbo].[Usp_TYYP_Goods_SelectByOrderId]';

GO

CREATE PROCEDURE [dbo].[Usp_TYYP_Goods_SelectByOrderId] @OrderId VARCHAR(50)
AS
    SET NOCOUNT ON;
    SELECT  G.*
    FROM    dbo.TYYP_OrderGoods AS OG
            INNER JOIN dbo.TYYP_Goods AS G ON G.GoodsId = OG.GoodsId
    WHERE   OG.OrderId = @OrderId;

GO


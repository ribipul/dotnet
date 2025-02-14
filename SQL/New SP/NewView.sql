USE [Accounting_Web]
GO
/****** Object:  View [dbo].[vw_Receipt]    Script Date: 08/04/2015 14:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Receipt]
ASSELECT DISTINCT i.Invoice_No,i.TAmount,c.Name,l.sbname,i.MoneyReceiptNo FROM InvoiceList i,Company c,InvoiceSceduler i1,Sales s,Ledger l WHERE i.id=i1.Invoice_Id and i1.tno=s.tno and s.pcode=l.id and i.cid=c.id and i.id in (82968,82946,81331,76918) --ORDER BY i.Invoice_No
GO
/****** Object:  View [dbo].[V_SalesList]    Script Date: 08/04/2015 14:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_SalesList]
AS
SELECT     s.TNO, c.Name AS CompanyName, cp.Name AS BillingContactPerson, l.SBName AS ProductName, s.SDate AS StartDate, s.EDate AS EndDate, 
                      s.SalesPrice, s.Tax AS VAT, s.Posted
FROM         dbo.Sales AS s LEFT OUTER JOIN
                      dbo.Company AS c ON s.CId = c.Id LEFT OUTER JOIN
                      dbo.Ledger AS l ON s.PCode = l.Id LEFT OUTER JOIN
                      dbo.ContactPersons AS cp ON s.BillContactId = cp.Id
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "s"
            Begin Extent = 
               Top = 14
               Left = 246
               Bottom = 207
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 22
               Left = 20
               Bottom = 137
               Right = 183
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "l"
            Begin Extent = 
               Top = 10
               Left = 518
               Bottom = 125
               Right = 676
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "cp"
            Begin Extent = 
               Top = 132
               Left = 470
               Bottom = 247
               Right = 622
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_SalesList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_SalesList'
GO
/****** Object:  View [dbo].[LedgerVw]    Script Date: 08/04/2015 14:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[LedgerVw]
AS
SELECT DISTINCT TOP (100) PERCENT l1.Id, l1.SBName, l1.LevelNo, l1.MGroup, l2.Id AS UnderID, l2.SBName AS UnderLedgerName, l1.LedgerAcc
FROM         dbo.Ledger AS l1 CROSS JOIN
                      dbo.Ledger AS l2
WHERE     (l1.Under = l2.Under + ',' + CAST(l2.Id AS varchar)) OR
                      (l1.Under = CAST(l2.Id AS varchar))
UNION
SELECT ID, SBName, LevelNo, MGroup, 0 As UnderID, '' As UnderLedgerName, LedgerAcc FROM Ledger
WHERE LevelNo = 0
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[11] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "l1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 196
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "l2"
            Begin Extent = 
               Top = 6
               Left = 234
               Bottom = 121
               Right = 392
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LedgerVw'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LedgerVw'
GO

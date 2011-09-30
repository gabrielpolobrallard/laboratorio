IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[tb_Pacientes]')) 
   ALTER TABLE [dbo].[tb_Pacientes] 
   ENABLE  CHANGE_TRACKING
GO

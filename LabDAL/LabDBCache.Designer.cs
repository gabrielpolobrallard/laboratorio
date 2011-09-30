﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LabDAL {
    
    
    public partial class LabDBCacheClientSyncProvider : Microsoft.Synchronization.Data.SqlServerCe.SqlCeClientSyncProvider {
        
        public LabDBCacheClientSyncProvider() {
            this.ConnectionString = global::LabDAL.Properties.Settings.Default.ClientLabDBConnectionString;
        }
        
        public LabDBCacheClientSyncProvider(string connectionString) {
            this.ConnectionString = connectionString;
        }
    }
    
    public partial class LabDBCacheSyncAgent : Microsoft.Synchronization.SyncAgent {
        
        private tb_AnalisisSyncTable _tb_AnalisisSyncTable;
        
        private tb_PacientesSyncTable _tb_PacientesSyncTable;
        
        partial void OnInitialized();
        
        public LabDBCacheSyncAgent() {
            this.InitializeSyncProviders();
            this.InitializeSyncTables();
            this.OnInitialized();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public tb_AnalisisSyncTable tb_Analisis {
            get {
                return this._tb_AnalisisSyncTable;
            }
            set {
                this.Configuration.SyncTables.Remove(this._tb_AnalisisSyncTable);
                this._tb_AnalisisSyncTable = value;
                this.Configuration.SyncTables.Add(this._tb_AnalisisSyncTable);
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public tb_PacientesSyncTable tb_Pacientes {
            get {
                return this._tb_PacientesSyncTable;
            }
            set {
                this.Configuration.SyncTables.Remove(this._tb_PacientesSyncTable);
                this._tb_PacientesSyncTable = value;
                this.Configuration.SyncTables.Add(this._tb_PacientesSyncTable);
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeSyncProviders() {
            // Create SyncProviders.
            this.RemoteProvider = new LabDBCacheServerSyncProvider();
            this.LocalProvider = new LabDBCacheClientSyncProvider();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeSyncTables() {
            // Create SyncTables.
            this._tb_AnalisisSyncTable = new tb_AnalisisSyncTable();
            this._tb_AnalisisSyncTable.SyncGroup = new Microsoft.Synchronization.Data.SyncGroup("tb_AnalisisSyncTableSyncGroup");
            this.Configuration.SyncTables.Add(this._tb_AnalisisSyncTable);
            this._tb_PacientesSyncTable = new tb_PacientesSyncTable();
            this._tb_PacientesSyncTable.SyncGroup = new Microsoft.Synchronization.Data.SyncGroup("tb_PacientesSyncTableSyncGroup");
            this.Configuration.SyncTables.Add(this._tb_PacientesSyncTable);
        }
        
        public partial class tb_AnalisisSyncTable : Microsoft.Synchronization.Data.SyncTable {
            
            partial void OnInitialized();
            
            public tb_AnalisisSyncTable() {
                this.InitializeTableOptions();
                this.OnInitialized();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitializeTableOptions() {
                this.TableName = "tb_Analisis";
                this.SyncDirection = Microsoft.Synchronization.Data.SyncDirection.Snapshot;
                this.CreationOption = Microsoft.Synchronization.Data.TableCreationOption.DropExistingOrCreateNewTable;
            }
        }
        
        public partial class tb_PacientesSyncTable : Microsoft.Synchronization.Data.SyncTable {
            
            partial void OnInitialized();
            
            public tb_PacientesSyncTable() {
                this.InitializeTableOptions();
                this.OnInitialized();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitializeTableOptions() {
                this.TableName = "tb_Pacientes";
                this.CreationOption = Microsoft.Synchronization.Data.TableCreationOption.DropExistingOrCreateNewTable;
            }
        }
    }
}
namespace LabDAL {
    
    
    public partial class tb_AnalisisSyncAdapter : Microsoft.Synchronization.Data.Server.SyncAdapter {
        
        partial void OnInitialized();
        
        public tb_AnalisisSyncAdapter() {
            this.InitializeCommands();
            this.InitializeAdapterProperties();
            this.OnInitialized();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeCommands() {
            // tb_AnalisisSyncTableInsertCommand command.
            this.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this.InsertCommand.CommandText = @" SET IDENTITY_INSERT dbo.tb_Analisis ON INSERT INTO dbo.tb_Analisis ([id_analisis], [paciente_id], [fecha_solicitud], [fecha_entrega], [estado_id], [medico_id], [enzim_id], [hepatog_id], [matfecal_id], [hemogram_id], [hemostaciaycoag_id], [hormonas_id], [inmunoglobul_id], [lipidogelectrof_id], [microbiolog_id], [orinacomplet_id], [orinacomplemen_id], [orinafisicoquimico_id], [orina_sediment_id], [proteinogelectroforetic_id], [quimica_hematica_id]) VALUES (@id_analisis, @paciente_id, @fecha_solicitud, @fecha_entrega, @estado_id, @medico_id, @enzim_id, @hepatog_id, @matfecal_id, @hemogram_id, @hemostaciaycoag_id, @hormonas_id, @inmunoglobul_id, @lipidogelectrof_id, @microbiolog_id, @orinacomplet_id, @orinacomplemen_id, @orinafisicoquimico_id, @orina_sediment_id, @proteinogelectroforetic_id, @quimica_hematica_id) SET @sync_row_count = @@rowcount SET IDENTITY_INSERT dbo.tb_Analisis OFF ";
            this.InsertCommand.CommandType = System.Data.CommandType.Text;
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id_analisis", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@paciente_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fecha_solicitud", System.Data.SqlDbType.Date));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fecha_entrega", System.Data.SqlDbType.Date));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@estado_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@medico_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@enzim_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@hepatog_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@matfecal_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@hemogram_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@hemostaciaycoag_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@hormonas_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@inmunoglobul_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lipidogelectrof_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@microbiolog_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orinacomplet_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orinacomplemen_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orinafisicoquimico_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orina_sediment_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@proteinogelectroforetic_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@quimica_hematica_id", System.Data.SqlDbType.Int));
            System.Data.SqlClient.SqlParameter insertcommand_sync_row_countParameter = new System.Data.SqlClient.SqlParameter("@sync_row_count", System.Data.SqlDbType.Int);
            insertcommand_sync_row_countParameter.Direction = System.Data.ParameterDirection.Output;
            this.InsertCommand.Parameters.Add(insertcommand_sync_row_countParameter);
            // tb_AnalisisSyncTableDeleteCommand command.
            this.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this.DeleteCommand.CommandText = "DELETE FROM dbo.tb_Analisis WHERE ([id_analisis] = @id_analisis) SET @sync_row_co" +
                "unt = @@rowcount";
            this.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id_analisis", System.Data.SqlDbType.Int));
            System.Data.SqlClient.SqlParameter deletecommand_sync_row_countParameter = new System.Data.SqlClient.SqlParameter("@sync_row_count", System.Data.SqlDbType.Int);
            deletecommand_sync_row_countParameter.Direction = System.Data.ParameterDirection.Output;
            this.DeleteCommand.Parameters.Add(deletecommand_sync_row_countParameter);
            // tb_AnalisisSyncTableUpdateCommand command.
            this.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this.UpdateCommand.CommandText = @"UPDATE dbo.tb_Analisis SET [paciente_id] = @paciente_id, [fecha_solicitud] = @fecha_solicitud, [fecha_entrega] = @fecha_entrega, [estado_id] = @estado_id, [medico_id] = @medico_id, [enzim_id] = @enzim_id, [hepatog_id] = @hepatog_id, [matfecal_id] = @matfecal_id, [hemogram_id] = @hemogram_id, [hemostaciaycoag_id] = @hemostaciaycoag_id, [hormonas_id] = @hormonas_id, [inmunoglobul_id] = @inmunoglobul_id, [lipidogelectrof_id] = @lipidogelectrof_id, [microbiolog_id] = @microbiolog_id, [orinacomplet_id] = @orinacomplet_id, [orinacomplemen_id] = @orinacomplemen_id, [orinafisicoquimico_id] = @orinafisicoquimico_id, [orina_sediment_id] = @orina_sediment_id, [proteinogelectroforetic_id] = @proteinogelectroforetic_id, [quimica_hematica_id] = @quimica_hematica_id WHERE ([id_analisis] = @id_analisis) SET @sync_row_count = @@rowcount";
            this.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@paciente_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fecha_solicitud", System.Data.SqlDbType.Date));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fecha_entrega", System.Data.SqlDbType.Date));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@estado_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@medico_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@enzim_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@hepatog_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@matfecal_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@hemogram_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@hemostaciaycoag_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@hormonas_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@inmunoglobul_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lipidogelectrof_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@microbiolog_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orinacomplet_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orinacomplemen_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orinafisicoquimico_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orina_sediment_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@proteinogelectroforetic_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@quimica_hematica_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id_analisis", System.Data.SqlDbType.Int));
            System.Data.SqlClient.SqlParameter updatecommand_sync_row_countParameter = new System.Data.SqlClient.SqlParameter("@sync_row_count", System.Data.SqlDbType.Int);
            updatecommand_sync_row_countParameter.Direction = System.Data.ParameterDirection.Output;
            this.UpdateCommand.Parameters.Add(updatecommand_sync_row_countParameter);
            // selectIncrementalInsertsCommand command.
            this.SelectIncrementalInsertsCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectIncrementalInsertsCommand.CommandText = "SELECT * FROM dbo.tb_Analisis";
            this.SelectIncrementalInsertsCommand.CommandType = System.Data.CommandType.Text;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeAdapterProperties() {
            this.TableName = "tb_Analisis";
        }
    }
    
    public partial class tb_PacientesSyncAdapter : Microsoft.Synchronization.Data.Server.SyncAdapter {
        
        partial void OnInitialized();
        
        public tb_PacientesSyncAdapter() {
            this.InitializeCommands();
            this.InitializeAdapterProperties();
            this.OnInitialized();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeCommands() {
            // tb_PacientesSyncTableInsertCommand command.
            this.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this.InsertCommand.CommandText = @" SET IDENTITY_INSERT dbo.tb_Pacientes ON ;WITH CHANGE_TRACKING_CONTEXT (@sync_client_id_binary) INSERT INTO dbo.tb_Pacientes ([id_paciente], [nombre], [apellido], [dni], [grupo_sanguineo], [fecha_alta], [fecha_nacimiento], [obra_social_id], [medico_id], [es_donante], [donante_id], [borrado]) VALUES (@id_paciente, @nombre, @apellido, @dni, @grupo_sanguineo, @fecha_alta, @fecha_nacimiento, @obra_social_id, @medico_id, @es_donante, @donante_id, @borrado) SET @sync_row_count = @@rowcount; IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.tb_Pacientes')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.tb_Pacientes')  SET IDENTITY_INSERT dbo.tb_Pacientes OFF ";
            this.InsertCommand.CommandType = System.Data.CommandType.Text;
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id_paciente", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nombre", System.Data.SqlDbType.VarChar));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@apellido", System.Data.SqlDbType.VarChar));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dni", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@grupo_sanguineo", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fecha_alta", System.Data.SqlDbType.Date));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fecha_nacimiento", System.Data.SqlDbType.Date));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@obra_social_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@medico_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@es_donante", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@donante_id", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@borrado", System.Data.SqlDbType.Int));
            System.Data.SqlClient.SqlParameter insertcommand_sync_row_countParameter = new System.Data.SqlClient.SqlParameter("@sync_row_count", System.Data.SqlDbType.Int);
            insertcommand_sync_row_countParameter.Direction = System.Data.ParameterDirection.Output;
            this.InsertCommand.Parameters.Add(insertcommand_sync_row_countParameter);
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            // tb_PacientesSyncTableDeleteCommand command.
            this.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this.DeleteCommand.CommandText = @";WITH CHANGE_TRACKING_CONTEXT (@sync_client_id_binary) DELETE dbo.tb_Pacientes FROM dbo.tb_Pacientes JOIN CHANGETABLE(VERSION dbo.tb_Pacientes, ([id_paciente]), (@id_paciente)) CT  ON CT.[id_paciente] = dbo.tb_Pacientes.[id_paciente] WHERE (@sync_force_write = 1 OR CT.SYS_CHANGE_VERSION IS NULL OR CT.SYS_CHANGE_VERSION <= @sync_last_received_anchor OR (CT.SYS_CHANGE_CONTEXT IS NOT NULL AND CT.SYS_CHANGE_CONTEXT = @sync_client_id_binary)) SET @sync_row_count = @@rowcount; IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.tb_Pacientes')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.tb_Pacientes') ";
            this.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id_paciente", System.Data.SqlDbType.Int));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_force_write", System.Data.SqlDbType.Bit));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            System.Data.SqlClient.SqlParameter deletecommand_sync_row_countParameter = new System.Data.SqlClient.SqlParameter("@sync_row_count", System.Data.SqlDbType.Int);
            deletecommand_sync_row_countParameter.Direction = System.Data.ParameterDirection.Output;
            this.DeleteCommand.Parameters.Add(deletecommand_sync_row_countParameter);
            // tb_PacientesSyncTableUpdateCommand command.
            this.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this.UpdateCommand.CommandText = @";WITH CHANGE_TRACKING_CONTEXT (@sync_client_id_binary) UPDATE dbo.tb_Pacientes SET [nombre] = @nombre, [apellido] = @apellido, [dni] = @dni, [grupo_sanguineo] = @grupo_sanguineo, [fecha_alta] = @fecha_alta, [fecha_nacimiento] = @fecha_nacimiento, [obra_social_id] = @obra_social_id, [medico_id] = @medico_id, [es_donante] = @es_donante, [donante_id] = @donante_id, [borrado] = @borrado FROM dbo.tb_Pacientes  JOIN CHANGETABLE(VERSION dbo.tb_Pacientes, ([id_paciente]), (@id_paciente)) CT  ON CT.[id_paciente] = dbo.tb_Pacientes.[id_paciente] WHERE (@sync_force_write = 1 OR CT.SYS_CHANGE_VERSION IS NULL OR CT.SYS_CHANGE_VERSION <= @sync_last_received_anchor OR (CT.SYS_CHANGE_CONTEXT IS NOT NULL AND CT.SYS_CHANGE_CONTEXT = @sync_client_id_binary)) SET @sync_row_count = @@rowcount; IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.tb_Pacientes')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.tb_Pacientes') ";
            this.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nombre", System.Data.SqlDbType.VarChar));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@apellido", System.Data.SqlDbType.VarChar));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dni", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@grupo_sanguineo", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fecha_alta", System.Data.SqlDbType.Date));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fecha_nacimiento", System.Data.SqlDbType.Date));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@obra_social_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@medico_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@es_donante", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@donante_id", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@borrado", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id_paciente", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_force_write", System.Data.SqlDbType.Bit));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            System.Data.SqlClient.SqlParameter updatecommand_sync_row_countParameter = new System.Data.SqlClient.SqlParameter("@sync_row_count", System.Data.SqlDbType.Int);
            updatecommand_sync_row_countParameter.Direction = System.Data.ParameterDirection.Output;
            this.UpdateCommand.Parameters.Add(updatecommand_sync_row_countParameter);
            // tb_PacientesSyncTableSelectConflictDeletedRowsCommand command.
            this.SelectConflictDeletedRowsCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectConflictDeletedRowsCommand.CommandText = "SELECT CT.[id_paciente], CT.SYS_CHANGE_CONTEXT, CT.SYS_CHANGE_VERSION FROM CHANGE" +
                "TABLE(CHANGES dbo.tb_Pacientes, @sync_last_received_anchor) CT WHERE (CT.[id_pac" +
                "iente] = @id_paciente AND CT.SYS_CHANGE_OPERATION = \'D\')";
            this.SelectConflictDeletedRowsCommand.CommandType = System.Data.CommandType.Text;
            this.SelectConflictDeletedRowsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectConflictDeletedRowsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id_paciente", System.Data.SqlDbType.Int));
            // tb_PacientesSyncTableSelectConflictUpdatedRowsCommand command.
            this.SelectConflictUpdatedRowsCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectConflictUpdatedRowsCommand.CommandText = @"SELECT dbo.tb_Pacientes.[id_paciente], [nombre], [apellido], [dni], [grupo_sanguineo], [fecha_alta], [fecha_nacimiento], [obra_social_id], [medico_id], [es_donante], [donante_id], [borrado], CT.SYS_CHANGE_CONTEXT, CT.SYS_CHANGE_VERSION FROM dbo.tb_Pacientes JOIN CHANGETABLE(VERSION dbo.tb_Pacientes, ([id_paciente]), (@id_paciente)) CT  ON CT.[id_paciente] = dbo.tb_Pacientes.[id_paciente]";
            this.SelectConflictUpdatedRowsCommand.CommandType = System.Data.CommandType.Text;
            this.SelectConflictUpdatedRowsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id_paciente", System.Data.SqlDbType.Int));
            // tb_PacientesSyncTableSelectIncrementalInsertsCommand command.
            this.SelectIncrementalInsertsCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectIncrementalInsertsCommand.CommandText = @"IF @sync_initialized = 0 SELECT dbo.tb_Pacientes.[id_paciente], [nombre], [apellido], [dni], [grupo_sanguineo], [fecha_alta], [fecha_nacimiento], [obra_social_id], [medico_id], [es_donante], [donante_id], [borrado] FROM dbo.tb_Pacientes LEFT OUTER JOIN CHANGETABLE(CHANGES dbo.tb_Pacientes, @sync_last_received_anchor) CT ON CT.[id_paciente] = dbo.tb_Pacientes.[id_paciente] WHERE (CT.SYS_CHANGE_CONTEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary) ELSE  BEGIN SELECT dbo.tb_Pacientes.[id_paciente], [nombre], [apellido], [dni], [grupo_sanguineo], [fecha_alta], [fecha_nacimiento], [obra_social_id], [medico_id], [es_donante], [donante_id], [borrado] FROM dbo.tb_Pacientes JOIN CHANGETABLE(CHANGES dbo.tb_Pacientes, @sync_last_received_anchor) CT ON CT.[id_paciente] = dbo.tb_Pacientes.[id_paciente] WHERE (CT.SYS_CHANGE_OPERATION = 'I' AND CT.SYS_CHANGE_CREATION_VERSION  <= @sync_new_received_anchor AND (CT.SYS_CHANGE_CONTEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary)); IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.tb_Pacientes')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.tb_Pacientes')  END ";
            this.SelectIncrementalInsertsCommand.CommandType = System.Data.CommandType.Text;
            this.SelectIncrementalInsertsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_initialized", System.Data.SqlDbType.Bit));
            this.SelectIncrementalInsertsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalInsertsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            this.SelectIncrementalInsertsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt));
            // tb_PacientesSyncTableSelectIncrementalDeletesCommand command.
            this.SelectIncrementalDeletesCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectIncrementalDeletesCommand.CommandText = @"IF @sync_initialized > 0  BEGIN SELECT CT.[id_paciente] FROM CHANGETABLE(CHANGES dbo.tb_Pacientes, @sync_last_received_anchor) CT WHERE (CT.SYS_CHANGE_OPERATION = 'D' AND CT.SYS_CHANGE_VERSION <= @sync_new_received_anchor AND (CT.SYS_CHANGE_CONTEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary)); IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.tb_Pacientes')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.tb_Pacientes')  END ";
            this.SelectIncrementalDeletesCommand.CommandType = System.Data.CommandType.Text;
            this.SelectIncrementalDeletesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_initialized", System.Data.SqlDbType.Bit));
            this.SelectIncrementalDeletesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalDeletesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalDeletesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            // tb_PacientesSyncTableSelectIncrementalUpdatesCommand command.
            this.SelectIncrementalUpdatesCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectIncrementalUpdatesCommand.CommandText = @"IF @sync_initialized > 0  BEGIN SELECT dbo.tb_Pacientes.[id_paciente], [nombre], [apellido], [dni], [grupo_sanguineo], [fecha_alta], [fecha_nacimiento], [obra_social_id], [medico_id], [es_donante], [donante_id], [borrado] FROM dbo.tb_Pacientes JOIN CHANGETABLE(CHANGES dbo.tb_Pacientes, @sync_last_received_anchor) CT ON CT.[id_paciente] = dbo.tb_Pacientes.[id_paciente] WHERE (CT.SYS_CHANGE_OPERATION = 'U' AND CT.SYS_CHANGE_VERSION <= @sync_new_received_anchor AND (CT.SYS_CHANGE_CONTEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary)); IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.tb_Pacientes')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.tb_Pacientes')  END ";
            this.SelectIncrementalUpdatesCommand.CommandType = System.Data.CommandType.Text;
            this.SelectIncrementalUpdatesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_initialized", System.Data.SqlDbType.Bit));
            this.SelectIncrementalUpdatesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalUpdatesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalUpdatesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeAdapterProperties() {
            this.TableName = "tb_Pacientes";
        }
    }
    
    public partial class LabDBCacheServerSyncProvider : Microsoft.Synchronization.Data.Server.DbServerSyncProvider {
        
        private tb_AnalisisSyncAdapter _tb_AnalisisSyncAdapter;
        
        private tb_PacientesSyncAdapter _tb_PacientesSyncAdapter;
        
        partial void OnInitialized();
        
        public LabDBCacheServerSyncProvider() {
            string connectionString = global::LabDAL.Properties.Settings.Default.LabDBDAL;
            this.InitializeConnection(connectionString);
            this.InitializeSyncAdapters();
            this.InitializeNewAnchorCommand();
            this.OnInitialized();
        }
        
        public LabDBCacheServerSyncProvider(string connectionString) {
            this.InitializeConnection(connectionString);
            this.InitializeSyncAdapters();
            this.InitializeNewAnchorCommand();
            this.OnInitialized();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public tb_AnalisisSyncAdapter tb_AnalisisSyncAdapter {
            get {
                return this._tb_AnalisisSyncAdapter;
            }
            set {
                this._tb_AnalisisSyncAdapter = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public tb_PacientesSyncAdapter tb_PacientesSyncAdapter {
            get {
                return this._tb_PacientesSyncAdapter;
            }
            set {
                this._tb_PacientesSyncAdapter = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeConnection(string connectionString) {
            this.Connection = new System.Data.SqlClient.SqlConnection(connectionString);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeSyncAdapters() {
            // Create SyncAdapters.
            this._tb_AnalisisSyncAdapter = new tb_AnalisisSyncAdapter();
            this.SyncAdapters.Add(this._tb_AnalisisSyncAdapter);
            this._tb_PacientesSyncAdapter = new tb_PacientesSyncAdapter();
            this.SyncAdapters.Add(this._tb_PacientesSyncAdapter);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeNewAnchorCommand() {
            // selectNewAnchorCmd command.
            this.SelectNewAnchorCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectNewAnchorCommand.CommandText = "Select @sync_new_received_anchor = CHANGE_TRACKING_CURRENT_VERSION()";
            this.SelectNewAnchorCommand.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlParameter selectnewanchorcommand_sync_new_received_anchorParameter = new System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt);
            selectnewanchorcommand_sync_new_received_anchorParameter.Direction = System.Data.ParameterDirection.Output;
            this.SelectNewAnchorCommand.Parameters.Add(selectnewanchorcommand_sync_new_received_anchorParameter);
        }
    }
}

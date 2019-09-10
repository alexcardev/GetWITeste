using Dapper;
using GetWITeste.Core.Entities;
using GetWITeste.Core.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GetWITeste.Infra.Data
{
    public class DapperRepository : IDapperRepository
    {
        private IDbConnection _connection;
        private readonly AppSettings _config;

        public DapperRepository(IOptions<AppSettings> config)
        {
            _config = config.Value;
        }

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null || _connection.State == ConnectionState.Closed)
                {
                    _connection = new SqlConnection(_config.ConnectionDb);

                }
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();
        }

        public void IncluirWorkItem(WorkItems entity)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var storedProcedure = "[WorkItemsTeste].[dbo].[IncluirWorkItem]";
                var param = new DynamicParameters();

                param.Add("@Id", entity.Id);
                param.Add("@Tipo", entity.Tipo);
                param.Add("@Titulo", entity.Titulo);
                param.Add("@Data", entity.Data);

                dbConnection.Execute(storedProcedure, param, null, null, CommandType.StoredProcedure);
            }
        }

        public List<WorkItems> ListarWorkitems()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var storedProcedure = "[WorkItemsTeste].[dbo].[ListarWorkItems]";
                var param = new DynamicParameters();

                return dbConnection.Query<WorkItems>(storedProcedure, param, null, false, 0, CommandType.StoredProcedure).ToList();
            }
        }

        public int ObterUltimoIdWorkItem()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var storedProcedure = "[WorkItemsTeste].[dbo].[ObterUltimoIdWorkItem]";
                var param = new DynamicParameters();

                return dbConnection.ExecuteScalar<int>(storedProcedure, param, null, null, CommandType.StoredProcedure);
            }
        }

        public void AddLogAnalise(LogAnalise entity)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var storedProcedure = "[WorkItemsTeste].[dbo].[IncluirLogAnalise]";
                var param = new DynamicParameters();

                param.Add("@TipoLog", entity.TipoLog);
                param.Add("@Mensagem", entity.Mensagem);
                param.Add("@Data", entity.Data);

                dbConnection.Execute(storedProcedure, param, null, null, CommandType.StoredProcedure);
            }
        }
    }
}

using GetWITeste.Core.Entities;
using GetWITeste.Core.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

        public void InserirWorkItem(WorkItems workItems)
        {
            throw new NotImplementedException();
        }

        public List<WorkItems> ListarWorkitems()
        {
            throw new NotImplementedException();
        }

        public List<WorkItems> ListarWorkitemsPorTipo()
        {
            throw new NotImplementedException();
        }

        public void AddLogAnalise(LogAnalise entity)
        {
            throw new NotImplementedException();
        }
    }
}

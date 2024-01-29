using Dapper;
using IndraApiBack.DataAccess.Data;
using IndraApiBack.DataAccess.Interfaces;
using IndraApiBack.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndraApiBack.DataAccess.Implementacion
{
    public class EmpresaDA : IEmpresa
    {
        private readonly IDbConnection _connection;

        public EmpresaDA(ConexionService conexionService)
        {
            string connsql = conexionService.getConexion();
            _connection = new SqlConnection(connsql);
        }

        public async Task<dynamic> getEmpresas()
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@codsuc", 1, DbType.Int32);
            IEnumerable<dynamic> lista = await _connection.QueryAsync<dynamic>("sp_get_Empresas", parameters, commandType: CommandType.StoredProcedure);
            return lista.ToList();
        }

        public async Task<dynamic> getEmpresabyID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idempresa", id, DbType.Int32);
            IEnumerable<dynamic> lista = await _connection.QueryAsync<dynamic>("sp_get_Empresabyid", parameters, commandType: CommandType.StoredProcedure);
            return lista.FirstOrDefault();
        }


        public async Task<int> InsertEmpresa(Empresa obj)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@codsuc", 1, DbType.Int32);
            parameters.Add("@ruc", obj.ruc, DbType.String);
            parameters.Add("@nombre", obj.nombre, DbType.String);
            parameters.Add("@descripcion", obj.descripcion, DbType.String);
            parameters.Add("@user", "ADMIN", DbType.String);
            parameters.Add("@nResultado", dbType: DbType.Int32, direction: ParameterDirection.Output);

            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            var nResultado = await _connection.ExecuteAsync("sp_ins_empresa", parameters, commandType: CommandType.StoredProcedure);
            _connection.Close();

            return nResultado;
        }

        public async Task<int> EditEmpresa(Empresa obj)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idempresa", obj.idempresa, DbType.Int32);
            parameters.Add("@nombre", obj.nombre, DbType.String);
            parameters.Add("@descripcion", obj.descripcion, DbType.String);
            parameters.Add("@user", "ADMIN", DbType.String);
            parameters.Add("@nResultado", dbType: DbType.Int32, direction: ParameterDirection.Output);

            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            var nResultado = await _connection.ExecuteAsync("sp_upd_empresa", parameters, commandType: CommandType.StoredProcedure);

            _connection.Close();

            return nResultado;
        }


        public async Task<int> DeleteEmpresa(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idempresa", id, DbType.Int64);
            parameters.Add("@nResultado", dbType: DbType.Int32, direction: ParameterDirection.Output);
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            var nResultado = await _connection.ExecuteAsync("sp_del_empresa", parameters, commandType: CommandType.StoredProcedure);
            //var nResultado = parameters.Get<int>("@nResultado");
            _connection.Close();
            return nResultado;
        }

    }

}

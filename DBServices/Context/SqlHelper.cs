using System;
using System.Data;
using System.Data.SqlClient;

namespace DBServices.Context
{
    public class SqlHelper : ISqlHelper
    {
        /** Imyección de dependencia **/
        private readonly IDBConexion _dbConn;
        public SqlHelper(IDBConexion dbConn)
        {
            _dbConn = dbConn;
        }

        public SqlHelper() { }
        
        DBConexion conn = new DBConexion();
        private string connString;

        public string EjecutaSPScalar(string procName, string strDbConn, params SqlParameter[] paramters)
        {
            //connString = _dbConn.ObtConexionDB();
            connString = conn.ObtConexionDB();
            string result = "";
            using (var sqlConnection = new SqlConnection(connString))
            {
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = procName;
                    if (paramters != null)
                    {
                        command.Parameters.AddRange(paramters);
                    }
                    sqlConnection.Open();
                    var ret = command.ExecuteScalar();
                    if (ret != null)
                        result = Convert.ToString(ret);
                }
            }
            return result;
        }

        public DataTable EjecutaSPDatos(string procName, string strDbConn, params SqlParameter[] parameters)
        {
            connString = conn.ObtConexionDB();
            DataTable dtResult = new DataTable();

            using (var sqlConnection = new SqlConnection(strDbConn))
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                { 
                    try
                    {
                        /*sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.CommandText = procName;
                        if (parameters != null)
                        {
                            sqlCommand.Parameters.AddRange(parameters);
                        }*/
                        sqlConnection.Open();
                        using(SqlDataAdapter da = new SqlDataAdapter(procName, sqlConnection))
                        {
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            if (parameters != null)
                                da.SelectCommand.Parameters.AddRange(parameters);

                            da.Fill(dtResult);
                            return dtResult;
                        }
                        /*using (var reader = sqlCommand.ExecuteReader())
                        {
                            
                            if (reader.HasRows)
                                dtResult.Load(reader);
                            return dtResult;
                        }*/
                    }
                    catch(Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

    }

    public interface ISqlHelper
    {
        public string EjecutaSPScalar(string procName, string strDbConn, params SqlParameter[] paramters);
        public DataTable EjecutaSPDatos(string procName, string strDbConn, params SqlParameter[] parameters);
    }
}

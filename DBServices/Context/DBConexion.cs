using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServices.Context
{

    public class DBConexion : IDBConexion
    {
        public string ObtConexionDB()
        {
            return strConn;
        }

        private string strConn
        {
            get
            {
                return @"Data Source=(localdb)\MSSqlLocalDB;Initial Catalog=C:\USERS\AXEL-JOB\SOURCE\REPOS\CHUBB_API_TEST\DBSERVICES\DATA\EMPRESA.MDF;Integrated Security=True";
            }
        }
    }

    public interface IDBConexion
    {
        public string ObtConexionDB();        
    }
}

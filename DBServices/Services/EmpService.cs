using Chubb_Api_Test.Models;
using DBServices.Utililty;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServices.Context
{
    public class EmpService : IEmpService
    {
        /** Imyección de dependencia **/
        /*private readonly ISqlHelper _sqlHelper;
        //private readonly IUEmpleados _uEmpleados;
        public EmpService(ISqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }*/
        SqlHelper sqlHelper = new SqlHelper();

        string spName = "spGetEmpleados";

        public Empleado ObtEmpleadoPorId(string dbConn, int empId)
        {
            SqlParameter[] param = { new SqlParameter("@Id", empId) };
            var dtEmp = sqlHelper.EjecutaSPDatos(spName, dbConn, param);

            if (dtEmp.Rows.Count == 0)
                return null;

            UEmpleados utilEmp = new UEmpleados();

            return utilEmp.ObtEmpleado(dtEmp.Rows[0]);
        }

        public List<Empleado> GetEmpleados(string dbConn)
        {
            var drEmp = sqlHelper.EjecutaSPDatos(spName, dbConn, null);
            UEmpleados utilEmp = new UEmpleados();
            return utilEmp.ObtEmpleadosLista(drEmp);
        }

        public bool InsEmpleado(byte? Fotografia, string Nombre, string Apellido, int puestoId, DateTime FechaNacimiento, DateTime FechaContratacion,
            string Direccion, string Telefono, string CorreoElectronico, int Estado, string dbConn)
        {
            spName = "spInsEmpleado";

            SqlParameter[] param = { 
                new SqlParameter("@Fotografia", Fotografia),
                new SqlParameter("@Nombre", Nombre),
                new SqlParameter("@Apellido", Apellido),
                new SqlParameter("@PuestoId", puestoId),
                new SqlParameter("@FechaNac", FechaNacimiento),
                new SqlParameter("@FechaCont", FechaContratacion),
                new SqlParameter("@Dir", Direccion),
                new SqlParameter("@Telefono", Telefono),
                new SqlParameter("@CorreoE", CorreoElectronico),
                new SqlParameter("@EstadpId", Estado)
            };

            string result = sqlHelper.EjecutaSPScalar(spName, dbConn, param);

            int intResult = 0;
            if (!int.TryParse(result, out intResult))
                return false;

            if (intResult == 1)
                return true;
            else
                return false;
        }

        public string DeleteEmpleado(int empId, string dbConn)
        {
            spName = "spDelEmpleado";
            SqlParameter[] param = { new SqlParameter("@Id", empId) };
            return sqlHelper.EjecutaSPScalar(spName, dbConn, param);
        }
    }

    public interface IEmpService
    {
        public Empleado ObtEmpleadoPorId(string dbConn, int empId);
        public List<Empleado> GetEmpleados(string dbConn);
        public bool InsEmpleado(byte? Fotografia, string Nombre, string Apellido, int puestoId, DateTime FechaNacimiento, DateTime FechaContratacion,
            string Direccion, string Telefono, string CorreoElectronico, int Estado, string dbConn);
        public string DeleteEmpleado(int empId, string dbConn);
    }
}

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

        public string InsEmpleado(Empleado empleado, string dbConn)
        {
            spName = "spInsEmpleado";

            SqlParameter[] param = {
                new SqlParameter("@Fotografia", empleado.Fotografia),
                new SqlParameter("@Nombre", empleado.Nombre),
                new SqlParameter("@Apellido", empleado.Apellido),
                new SqlParameter("@PuestoId", empleado.PuestoId),
                new SqlParameter("@FechaNac", empleado.FechaNacimiento),
                new SqlParameter("@FechaCont", empleado.FechaContratacion),
                new SqlParameter("@Dir", empleado.Direccion),
                new SqlParameter("@Telefono", empleado.Telefono),
                new SqlParameter("@CorreoE", empleado.CorreoElectronico),
                new SqlParameter("@EstadoId", empleado.EstadoId)
            };

            string result = sqlHelper.EjecutaSPScalar(spName, dbConn, param);

            return result;
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
        public string InsEmpleado(Empleado empleado, string dbConn);
        public string DeleteEmpleado(int empId, string dbConn);
    }
}

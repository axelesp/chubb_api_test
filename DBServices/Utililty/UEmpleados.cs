using Chubb_Api_Test.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServices.Utililty
{
    public class UEmpleados : IUEmpleados
    {
        public Empleado ObtEmpleado(DataRow dr)
        {
            Empleado emp;
            
            emp = new Empleado
            {
                Id = Convert.ToInt32(dr["Id"]),
                Fotografia = (DBNull.Value == dr["Fotografia"]) ? null : (byte[])dr["Fotografia"],
                Nombre = dr["Nombre"].ToString(),
                Apellido = dr["Apellido"].ToString(),
                PuestoId = int.Parse(dr["PuestoId"].ToString()),
                FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                FechaContratacion = Convert.ToDateTime(dr["FechaContratacion"]),
                Direccion = dr["Direccion"].ToString(),
                Telefono = dr["Telefono"].ToString(),
                CorreoElectronico = dr["CorreoElectronico"].ToString(),
                EstadoId = int.Parse(dr["EstadoId"].ToString())
            };


            return emp;
        }

        public  List<Empleado> ObtEmpleadosLista(DataTable dtEmpleados)
        {
            var lstEmp = new List<Empleado>();

            if (dtEmpleados.Rows.Count == 0)
                return lstEmp;

            foreach(DataRow dr in dtEmpleados.Rows)
                lstEmp.Add(ObtEmpleado(dr));

            return lstEmp;
        }
    }

    public interface IUEmpleados
    {
        public List<Empleado> ObtEmpleadosLista(DataTable dtEmpleados);
        public Empleado ObtEmpleado(DataRow dr);
    }
}

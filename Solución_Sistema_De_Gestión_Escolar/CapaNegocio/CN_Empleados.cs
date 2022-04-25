using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;

namespace CapaNegocio
{
    public class CN_Empleados
    {
        public CD_Empleados objetoCD = new CD_Empleados();
        public DataTable MostrarDoc()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarEmpleado(string nombre, string apellido, string Correo_electrónico, string Teléfono, string Dirección, string Puesto, string Cédula, string Salario, string Fecha_De_Nacimiento, string sexo)
        {
            objetoCD.Insertar(nombre, apellido, Correo_electrónico, Teléfono, Dirección, Puesto, Cédula, Salario, Fecha_De_Nacimiento, sexo);
        }

        public void EditarEmpleado(string nombre, string apellido, string Correo_electrónico, string Teléfono, string Dirección, string Puesto, string Cédula, string Salario, string Fecha_De_Nacimiento, string Sexo, string Id_empleado)
        {
            objetoCD.Editar(nombre, apellido, Correo_electrónico, Teléfono, Dirección, Puesto, Cédula, Convert.ToInt32(Salario), Fecha_De_Nacimiento, Sexo, Convert.ToInt32(Id_empleado));
        }

        public void EliminarEmpleado(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }
    }
}

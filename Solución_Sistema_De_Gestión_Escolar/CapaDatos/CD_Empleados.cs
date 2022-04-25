using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Empleados
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand(); //Para ejecutar instrucciones transact sql

        public DataTable Mostrar()
        {
            //Transact sql

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarEmpleados";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string nombre, string apellido, string Correo_electrónico, string Teléfono, string Dirección, string Puesto, string Cédula, string Salario, string Fecha_De_Nacimiento, string Sexo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO empleados VALUES ('" + nombre + "', '" + apellido + "', '" + Correo_electrónico + "', '" + Teléfono + "', '" + Dirección + "', '" + Puesto + "', '" + Cédula + "', '" + Salario + "','" + Fecha_De_Nacimiento + "', '" + Sexo + "')";
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(string nombre, string apellido, string Correo_electrónico, string Teléfono, string Dirección, string Puesto, string Cédula, int Salario, string Fecha_De_Nacimiento, string Sexo, int id_empleado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarEmpleados";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@correo_electrónico", Correo_electrónico);
            comando.Parameters.AddWithValue("@teléfono", Teléfono);
            comando.Parameters.AddWithValue("@dirección", Dirección);
            comando.Parameters.AddWithValue("@puesto", Puesto);
            comando.Parameters.AddWithValue("@cédula", Cédula);
            comando.Parameters.AddWithValue("@salario", Salario);
            comando.Parameters.AddWithValue("@fecha_de_nacimiento", Fecha_De_Nacimiento);
            comando.Parameters.AddWithValue("@sexo", Sexo);
            comando.Parameters.AddWithValue("@id_empleado", id_empleado);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarEmpleados";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@id_empleado", id);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
    }
}

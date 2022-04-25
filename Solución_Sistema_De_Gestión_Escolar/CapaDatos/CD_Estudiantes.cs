using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Estudiantes
    {
         CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand(); //Para ejecutar instrucciones transact sql

        public DataTable Mostrar()
        {
            //Transact sql

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarEstudiantes";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

       



        public void Insertar(string nombre, string apellido, string Correo_electrónico, string Teléfono, string Dirección, string Fecha_De_Nacimiento, string sexo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO estudiantes VALUES ('" + nombre + "', '" + apellido + "', '" + Correo_electrónico + "', '" + Teléfono + "', '" + Dirección + "', '" + Fecha_De_Nacimiento + "', '" + sexo + "')";
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(string nombre, string apellido, string Correo_electrónico, string Teléfono, string Dirección, string Fecha_De_Nacimiento, string Sexo, int id_estudiante)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarEstudiantes";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@correo_electrónico", Correo_electrónico);
            comando.Parameters.AddWithValue("@teléfono", Teléfono);
            comando.Parameters.AddWithValue("@dirección", Dirección);
            comando.Parameters.AddWithValue("@fecha_de_nacimiento", Fecha_De_Nacimiento);
            comando.Parameters.AddWithValue("@sexo", Sexo);
            comando.Parameters.AddWithValue("@id_estudiante", id_estudiante);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarEstudiantes";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@id_estudiante", id);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
    }
}

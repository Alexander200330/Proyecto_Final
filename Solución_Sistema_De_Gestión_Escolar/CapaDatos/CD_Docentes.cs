using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Docentes
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand(); //Para ejecutar instrucciones transact sql

        public DataTable Mostrar()
        {
            //Transact sql

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarDocentes";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string nombre, string apellido, string Correo_electrónico, string Teléfono, string Dirección,  string Materia, string Cédula, string Salario, string Fecha_De_Nacimiento, string Sexo, string Sustituto)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO docentes VALUES ('" + nombre + "', '" + apellido + "', '" + Correo_electrónico + "', '" + Teléfono + "', '" + Dirección + "', '"+ Materia + "', '" + Cédula + "', '" + Salario + "','" + Fecha_De_Nacimiento + "', '" + Sexo + "','"+Sustituto+"')";
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(string Nombre, string Apellido, string Correo_electrónico, string Teléfono, string Dirección, string Materia, string Cédula, int Salario, string Fecha_De_Nacimiento, string Sexo, string Sustituto, int ID_Docente)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarDocentes";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", Nombre);
            comando.Parameters.AddWithValue("@apellido", Apellido);
            comando.Parameters.AddWithValue("@correo_electrónico", Correo_electrónico);
            comando.Parameters.AddWithValue("@teléfono", Teléfono);
            comando.Parameters.AddWithValue("@dirección", Dirección);
            comando.Parameters.AddWithValue("@materia", Materia);
            comando.Parameters.AddWithValue("@cédula", Cédula);
            comando.Parameters.AddWithValue("@salario", Salario);
            comando.Parameters.AddWithValue("@fecha_de_nacimiento", Fecha_De_Nacimiento);
            comando.Parameters.AddWithValue("@sexo", Sexo);
            comando.Parameters.AddWithValue("@sustituto", Sustituto);
            comando.Parameters.AddWithValue("@id_docente", ID_Docente);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarDocentes";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@id_docente", id);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
    }
}

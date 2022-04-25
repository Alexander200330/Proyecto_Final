using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Estudiantes
    {
        public CD_Estudiantes objetoCD = new CD_Estudiantes();
        public DataTable MostrarEst()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarEstudiante(string nombre, string apellido, string Correo_electrónico, string Teléfono, string Dirección, string Fecha_De_Nacimiento, string sexo){
            objetoCD.Insertar(nombre, apellido, Correo_electrónico, Teléfono, Dirección, Fecha_De_Nacimiento, sexo);
        }

        public void EditarEstudiantes(string nombre, string apellido, string Correo_electrónico, string Teléfono, string Dirección, string Fecha_De_Nacimiento, string Sexo, string id_estudiante)
        {
            objetoCD.Editar(nombre, apellido, Correo_electrónico, Teléfono, Dirección, Fecha_De_Nacimiento, Sexo, Convert.ToInt32(id_estudiante));
        }

        public void EliminarEstudiantes(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }
    }
}

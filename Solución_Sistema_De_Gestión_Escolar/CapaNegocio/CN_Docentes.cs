using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Docentes
    {
        public CD_Docentes objetoCD = new CD_Docentes();
        public DataTable MostrarDoc()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarDocente(string nombre, string apellido, string Correo_electrónico, string Teléfono, string Dirección,string Materia,string Cédula,string Salario, string Fecha_De_Nacimiento, string sexo, string Sustituto)
        {
            objetoCD.Insertar(nombre, apellido, Correo_electrónico, Teléfono, Dirección,Materia, Cédula, Salario, Fecha_De_Nacimiento, sexo, Sustituto);
        }

        public void EditarDocente(string Nombre, string Apellido, string Correo_electrónico, string Teléfono, string Dirección, string Materia, string Cédula,string Salario, string Fecha_De_Nacimiento, string Sexo, string Sustituto, string Id_Docente)
        {
            objetoCD.Editar(Nombre, Apellido, Correo_electrónico, Teléfono, Dirección, Materia, Cédula, Convert.ToInt32(Salario), Fecha_De_Nacimiento, Sexo, Sustituto, Convert.ToInt32(Id_Docente));
        }

        public void EliminarDocente(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }
    }
}

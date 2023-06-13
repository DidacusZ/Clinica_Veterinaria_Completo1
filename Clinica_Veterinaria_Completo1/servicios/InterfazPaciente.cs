using Clinica_Veterinaria_Completo1.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Veterinaria_Completo1.servicios
{
    internal interface InterfazPaciente
    {

        //con cabecera en la primera linea
        //todos los datos separados por comas
        //si no hay fecha salida se rellena con '----'
        void ListarPacientes(List<Paciente> lista);



        //Pide todos los datos
        //guarda los datos en una lista de objetos
        //lo escribe en un fichero que registra todos los ingresos
        void IngresoPaciente(List<Paciente> lista);


    }
}

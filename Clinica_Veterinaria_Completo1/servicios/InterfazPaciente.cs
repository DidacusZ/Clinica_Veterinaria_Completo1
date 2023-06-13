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
        //el fichero siempre tiene que estar actualizado


        //1
        //con cabecera en la primera linea
        //todos los datos separados por comas
        //si no hay fecha salida se rellena con '----'
        void ListarPacientes(List<Paciente> lista);

        //2
        //Pide todos los datos
        //guarda los datos en una lista de objetos
        //lo escribe en un fichero que registra todos los ingresos
        List<Paciente> IngresoPaciente(List<Paciente> lista);

        //3
        //busca por el tlf y muestra la info de ese paciente
        //te permite modificar la fecha de salida si el usuario quiere (PreguntaSiNo)
        //al modificarlo se modifica el paciente en la lista y en el fichero
        List<Paciente> AltaPaciente(List<Paciente> lista);
        

        //carga la lista con todos los pacientes del fichero
        List<Paciente> CargarLista(List<Paciente> lista);

        //captura solo numeros en el rango pedido
        int CapturaEntero(string texto, int min, int max);

        //muestra un mensaje (para controlar errores)
        void Error(string txt);
    }
}

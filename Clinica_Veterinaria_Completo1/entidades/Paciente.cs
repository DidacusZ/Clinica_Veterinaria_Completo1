using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Veterinaria_Completo1.entidades
{
    internal class Paciente
    {
        //atributos
        private string nombre;
        private string telefonoDuenio;
        private string fechaIngreso;
        private string fechaAlta;

        //contructor vacio
        public Paciente()
        {

        }

        //constructor con todos los atributos
        public Paciente(string nombre, string telefonoDuenio, string fechaIngreso, string fechaAlta)
        {
            this.nombre = nombre;
            this.telefonoDuenio = telefonoDuenio;
            this.fechaIngreso = fechaIngreso;
            this.fechaAlta = fechaAlta;
        }

        //getters y setters
        public string Nombre { get => nombre; set => nombre = value; }
        public string TelefonoDuenio { get => telefonoDuenio; set => telefonoDuenio = value; }
        public string FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public string FechaAlta { get => fechaAlta; set => fechaAlta = value; }
    }
}

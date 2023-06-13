using Clinica_Veterinaria_Completo1.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Veterinaria_Completo1.servicios
{
    internal class ImplPaciente : InterfazPaciente
    {
        public List<Paciente> AltaPaciente(List<Paciente> lista)
        {            
            string telefonoParaBorar = Pedir("Introduce el telefono del dueño de la mascota que quieras dar de alta");
            bool verdad = true;

            for (int i = 0; i < lista.Count; i++)//recorre la lista
            {
                if(lista[i].TelefonoDuenio.Equals(telefonoParaBorar))//comprueba si el telefono coincide con el solicitado
                {
                    verdad = false;
                    Console.WriteLine("Nombre,TelefonoDuenio,FechaIngreso,FechaAlta");
                    Console.WriteLine(lista[i].ToString());//muestra datos del paciente

                    if (PreguntaSiNo("Estas seguro de que quieres dar de alta a este paciente"))
                    {
                        lista[i].FechaAlta = Pedir("Introduce la Fecha de alta");
                        Error("¡¡ Has dado de alta al Pacient !!");
                    }
                    //lista.RemoveAt(i);//elimina esa posicion de la lista
                    break;
                }
            }

            if(verdad)
                Error("No existe un dueño con ese telefono");

            return lista;
        }

        public List<Paciente> IngresoPaciente(List<Paciente> lista)
        {
            Paciente paciente = new Paciente();
            string fecha;

            paciente.Nombre = Pedir("Nombre de la mascota");
            paciente.TelefonoDuenio = Pedir("Telefono del dueño");
            paciente.FechaIngreso = Pedir("Fecha de ingreso");

            fecha = Pedir("Fecha de alta");
            if (fecha == "")//controlamos la fecha vacía
                fecha = "------";

            paciente.FechaAlta = fecha;

            Console.ReadKey(true);
            lista.Add(paciente);
            return lista;
        }

        public void ListarPacientes(List<Paciente> lista)
        {
            Console.WriteLine("Nombre,TelefonoDuenio,FechaIngreso,FechaAlta");

            //imprime por pantalla la lista
            foreach (Paciente pacienteLista in lista)            
                Console.WriteLine(pacienteLista.ToString());
            
            Console.ReadKey(true);
        }

        public int CapturaEntero(string texto, int min, int max)
        {
            bool esCorrecto;
            int valor;
            do
            {
                Console.Write("{0} [{1}..{2}]:", texto, min, max);
                esCorrecto = Int32.TryParse(Console.ReadLine(), out valor);
                if (!esCorrecto)
                    Console.WriteLine("\n\n\t** Error: el valor introducido no es un número entero");
                else if (valor < min || valor > max)
                {
                    esCorrecto = false;
                    Console.WriteLine("\n\n\t** Error: el valor introducido no está dentro del rango");
                }
            } while (!esCorrecto);
            return valor;
        }


        private bool PreguntaSiNo(string texto)
        {
            char letra;

            do
            {
                Console.Write("\n\n\t{0}: ", texto);
                letra = Console.ReadKey().KeyChar;// capturamos una pulsacion

                if (letra == 's' || letra == 'S')
                    return true;


                if (letra == 'n' || letra == 'N')
                    return false;

                Console.Write("\n\n\t**Te has equivocado, porfavor introduce un valor correcto**");

            } while (true);
        }
                
        public void Error(string txt) 
        {
            Console.Write("\n\n\t\t{0}....", txt);
            Console.ReadKey(true);
        }

        private string Pedir(string mensaje)
        {
            Console.Write("\n\t\t{0}: ", mensaje);
            return Console.ReadLine();
        }
    }
}

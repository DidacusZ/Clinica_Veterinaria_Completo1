using Clinica_Veterinaria_Completo1.entidades;
using System;
using System.Collections.Generic;
using System.IO;
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
                    Console.WriteLine("\n\tNombre,Telefono,FechaIngreso,FechaAlta");
                    Console.WriteLine("\n\t"+lista[i].ToString());//muestra datos del paciente

                    if (PreguntaSiNo("Estas seguro de que quieres dar de alta a este paciente"))
                    {
                        lista[i].FechaAlta = PedirFecha("alta");
                        Error("¡¡ Has dado de alta al Pacient !!");
                    }
                    //lista.RemoveAt(i);//elimina esa posicion de la lista
                    break;
                }
            }

            if(verdad)
                Error("No existe un dueño con ese telefono");
            else
            {
                //borramos el fichero y creamos uno nuevo
                StreamWriter sw = File.CreateText("PacientesClinica.txt");
                sw.WriteLine("Nombre,Telefono,FechaIngreso,FechaAlta");//cabecera

                for (int i = 0; i < lista.Count; i++)//recorre la lista
                    sw.WriteLine(lista[i].ToString());//escribe lista en fichero

                sw.Close();
            }
            return lista;
        }

        public List<Paciente> IngresoPaciente(List<Paciente> lista)
        {
            Paciente paciente = new Paciente();

            paciente.Nombre = Pedir("Nombre de la mascota");
            paciente.TelefonoDuenio = Pedir("Telefono del dueño");
            paciente.FechaIngreso = PedirFecha("ingreso");

            paciente.FechaAlta = "------";
            
            //Guardar datos en fichero
            StreamWriter sw;

            //comprueba si existe el fichero para saber si escribir la cabecera o no
            if (File.Exists("PacientesClinica.txt"))
                sw = File.AppendText("PacientesClinica.txt");// AppendText para escribir sin borrar el fichero           
            else
            {
                sw = File.AppendText("PacientesClinica.txt");
                sw.WriteLine("Nombre,Telefono,FechaIngreso,FechaAlta");
            }

            sw.WriteLine(paciente.ToString());
            sw.Close();

            lista.Add(paciente);
            Error("Paciente ingresado con exito");            
            return lista;
        }

        public void ListarPacientes(List<Paciente> lista)
        {
            Console.WriteLine("\n\tNombre,Telefono,FechaIngreso,FechaAlta");

            //imprime por pantalla la lista
            foreach (Paciente pacienteLista in lista)            
                Console.WriteLine("\n\t" + pacienteLista.ToString());
            
            Console.ReadKey(true);
        }

        public List<Paciente> CargarLista(List<Paciente> lista)
        {
            if (File.Exists("PacientesClinica.txt"))
            {
                StreamReader sr = new StreamReader("PacientesClinica.txt", Encoding.Default);//asi      
                List<string> listaLineas = new List<string>();

                //leo todo el fichero            
                while (!(sr.EndOfStream)) // Mientras no estoy en el final del fichero
                {
                    string linea;
                    linea = sr.ReadLine();
                    Console.WriteLine(linea);
                    listaLineas.Add(linea); // guardo en la lista de todas las lineas del fichero
                }
                sr.Close();
                for (int i = 1; i < listaLineas.Count; i++)//empezamos desde i=1 para omitir la cabecera
                {
                    string[] vLineas = listaLineas[i].Split(','); // separo los campos en el vector

                    //guardamos los campos en el objeto persona
                    Paciente paciente = new Paciente();

                    paciente.Nombre = vLineas[0];
                    paciente.TelefonoDuenio = vLineas[1];
                    paciente.FechaIngreso = vLineas[2];
                    paciente.FechaAlta = vLineas[3];

                    //añadimos objeto a lista              
                    lista.Add(paciente);
                }                
            }
            return lista;
        }

        public int CapturaEntero(string texto, int min, int max)
        {
            bool esCorrecto;
            int valor;
            do
            {
                Console.Write("\n\t\t{0} [{1}..{2}]:", texto, min, max);
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

        public void Error(string txt) 
        {
            Console.Write("\n\n\t\t{0}....", txt);
            Console.ReadKey(true);
        }
            
        
        //muestra un mesaje y devuelve un string
        private string Pedir(string mensaje)
        {
            Console.Write("\n\t\t{0}: ", mensaje);
            return Console.ReadLine();
        }

        //lanza una pregunta con respuesta [s/n] y devuelve un boolenao
        private bool PreguntaSiNo(string texto)
        {
            char letra;
            do
            {
                Console.Write("\n\n\t¿{0}? [s/n]: ", texto);
                letra = Console.ReadKey().KeyChar;// capturamos una pulsacion

                if (letra == 's' || letra == 'S')
                    return true;

                if (letra == 'n' || letra == 'N')
                    return false;

                Console.Write("\n\n\t**Te has equivocado, porfavor introduce un valor correcto**");

            } while (true);
        }

        //pide la fecha y devuelve un string
        private string PedirFecha(string tipoFecha)
        {
            int dia = CapturaEntero("Introduce el dia de " + tipoFecha, 1, 31);
            int mes = CapturaEntero("Introduce el mes de " + tipoFecha, 1, 12);
            int anio = CapturaEntero("Introduce el año de " + tipoFecha, 1888, 2050);

            return String.Format("{0}-{1}-{2}", dia, mes, anio);
        }
    }
}

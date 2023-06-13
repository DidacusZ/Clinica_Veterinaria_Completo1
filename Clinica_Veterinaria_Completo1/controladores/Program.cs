using Clinica_Veterinaria_Completo1.entidades;
using Clinica_Veterinaria_Completo1.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Veterinaria_Completo1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //variables
            int opcion;

            //implementaciones con interfaz
            InterfazMenu implMenu = new ImplMenu();
            InterfazPaciente implPaciente = new ImplPaciente();

            //lista de pacientes
            List<Paciente> listaClinica = new List<Paciente>();

            Paciente paciente = new Paciente();

            paciente = new Paciente("perro","6111122331","2-2-1","12");
            listaClinica.Add(paciente);

            paciente = new Paciente("gato", "311213", "23-231-12", "421");
            listaClinica.Add(paciente);

            try
            {
                do
                {
                    opcion = implMenu.Menu();
                    Console.Clear();
                    switch (opcion)
                    {
                        //listar pacientes
                        case 1:
                            implPaciente.ListarPacientes(listaClinica);
                            break;

                        //ingresar paciente
                        case 2:
                            implPaciente.IngresoPaciente(listaClinica);
                            break;

                        //Alta paciente
                        case 3:
                            implPaciente.AltaPaciente(listaClinica);
                            break;

                        //salir
                        case 0:
                            break;

                        //control error
                        default:
                            implPaciente.Error("Opción no válida, pulsa una tecla para volver al menu");
                            break;
                    }
                } while (opcion != 0);
            }
            catch (Exception ex)
            {
                implPaciente.Error("ERROR GENERAL");
            }

            implPaciente.Error("Pulsa una tecla para SALIR");
        }
    }
}
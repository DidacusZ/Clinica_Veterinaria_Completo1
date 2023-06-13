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

            //lista de pacientes
            List<Paciente> listaClinica = new List<Paciente>();



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

                            break;

                        //ingresar paciente
                        case 2:

                            break;

                        //borrar paciente
                        case 3:

                            break;

                        //salir
                        case 0:
                            break;

                        //control error
                        default:
                            implMenu.Error("Opción no válida, pulsa una tecla para volver al menu");
                            break;
                    }
                } while (opcion != 0);
            }
            catch (Exception ex)
            {

                implMenu.Error("ERROR GENERAL");
            }

            implMenu.Error("Pulsa una tecla para SALIR");
        }
    }
}
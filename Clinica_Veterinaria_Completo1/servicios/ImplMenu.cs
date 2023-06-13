using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Veterinaria_Completo1.servicios
{
    internal class ImplMenu : InterfazMenu
    {
        private int CapturaNumPulsado(string mensaje, int min, int max)
        {
            Console.Write("{0} [{1}...{2}]:", mensaje, min, max);
            return Console.ReadKey(true).KeyChar - '0';
        }

        public int Menu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("\t\t\t╔═════════════════════╗");
            Console.WriteLine("\t\t\t║   MENÚ de PUERTA    ║");
            Console.WriteLine("\t\t\t╠═════════════════════╣");
            Console.WriteLine("\t\t\t║  1) Nueva persona   ║");
            Console.WriteLine("\t\t\t║                     ║");
            Console.WriteLine("\t\t\t║ 2) Mostrar personas ║");
            Console.WriteLine("\t\t\t║          y          ║");
            Console.WriteLine("\t\t\t║ escribir en fichero ║");
            Console.WriteLine("\t\t\t║_____________________║");
            Console.WriteLine("\t\t\t║                     ║");
            Console.WriteLine("\t\t\t║     0) Salir        ║");
            Console.WriteLine("\t\t\t╚═════════════════════╝");

            return CapturaNumPulsado("\t\t\tPulse su opción", 0, 2);
        }
    }
}

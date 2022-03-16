using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2
{
    public class Display : IDisplay
    {

        public void DisplayConnectPhone()
        {
            Console.WriteLine("Tilslut telefon");
        }

        public void DisplayReadRfid()
        {
            Console.WriteLine("Indlæs Rfid");
        }

        public void DisplayConnectError()
        {
            Console.WriteLine("Tilslutningsfejl");
        }

        public void DisplayOccupied()
        {
            Console.WriteLine("Ladeskab Optaget");
        }

        public void DisplayReadError()
        {
            Console.WriteLine("Rfid fejl");
        }

        public void DisplayRemovePhone()
        {
            Console.WriteLine("Fjern telefon");
        }

        public void DisplayCharging() //Tilføj til klassediagram?
        {
            Console.WriteLine("Ladning foregår");
        }

        public void DisplayFullyCharged() //Tilføj til klassediagram?
        {
            Console.WriteLine("Telefon er fuldt opladet");
        }

        public void DisplayChargingError() //Tilføj til klassediagram?
        {
            Console.WriteLine("FEJL");
        }
    }
}

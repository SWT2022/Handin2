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
            DisplayId = 1;
            Console.WriteLine("Tilslut telefon");
        }

        public void DisplayReadRfid()
        {
            DisplayId = 2;
            Console.WriteLine("Indlæs Rfid");
        }

        public void DisplayConnectError()
        {
            DisplayId = 3;
            Console.WriteLine("Tilslutningsfejl");
        }

        public void DisplayOccupied()
        {
            DisplayId = 4;
            Console.WriteLine("Ladeskab Optaget");
        }

        public void DisplayReadError()
        {
            DisplayId = 5;
            Console.WriteLine("Rfid fejl");
        }

        public void DisplayRemovePhone()
        {
            DisplayId = 6;
            Console.WriteLine("Fjern telefon");
        }

        public void DisplayCharging() //Tilføj til klassediagram?
        {
            DisplayId = 7;
            Console.WriteLine("Ladning foregår");
        }

        public void DisplayFullyCharged() //Tilføj til klassediagram?
        {
            DisplayId = 8;
            Console.WriteLine("Telefon er fuldt opladet");
        }

        public void DisplayChargingError() //Tilføj til klassediagram?
        {
            DisplayId = 9;
            Console.WriteLine("FEJL");
        }

        public int DisplayId;
    }
}

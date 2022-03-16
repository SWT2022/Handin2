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
            Console.WriteLine("Connect Phone");
        }

        public void DisplayReadRfid()
        {
            Console.WriteLine("Read Rfid");
        }

        public void DisplayConnectError()
        {
            Console.WriteLine("Connection Error");
        }

        public void DisplayOccupied()
        {
            Console.WriteLine("Occupied");
        }

        public void DisplayReadError()
        {
            Console.WriteLine("Read Error");
        }

        public void DisplayRemovePhone()
        {
            Console.WriteLine("Remove Phone");
        }

    }
}

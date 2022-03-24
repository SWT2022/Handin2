using Handin2;
using UsbSimulator;

class Program
{
    static void Main(string[] args)
    {
        //Assemble your system here from all the classes
        Door door = new Door();
        RfidReader rfidReader = new RfidReader();
        Display display = new Display();
        UsbChargerSimulator usbChargerSimulator = new UsbChargerSimulator();
        ChargeControl chargeControl = new ChargeControl(usbChargerSimulator, display);
        StationControl stationControl = new StationControl(chargeControl, door, rfidReader, display);

        bool finish = false;
        do
        {
            string input;
            System.Console.WriteLine("Indtast E, O, C, R, S, A: ");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) continue;

            switch (input[0])
            {
                case 'E':
                    finish = true;
                    break;

                case 'O':
                    door.UnlockDoor();
                    break;

                case 'C':
                    door.LockDoor();
                    break;

                case 'R':
                    System.Console.WriteLine("Indtast RFID id: ");
                    string idString = System.Console.ReadLine();

                    int id = Convert.ToInt32(idString);
                    rfidReader.setId(id);
                    break;
                case 'S':
                    usbChargerSimulator.SimulateConnected(true);
                    break;
                case 'A':
                    usbChargerSimulator.SimulateConnected(false);
                    break;

                default:
                    break;
            }

        } while (!finish);
    }
}


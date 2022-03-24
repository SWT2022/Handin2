using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Handin2
{

    public class StationControl
    {
        //Enum med tilstande("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Member variables
        private IChargeControl _charger;
        private bool _doorState;
        private int _oldId;
        private int _newId;
        private IDoor _door;
        private IRfidReader _reader;
        private IDisplay _display;
        private LadeskabState _state;

        private string logFile = "logfile.txt"; // Navnet på systemets log-fil
        
        public StationControl(IChargeControl charger, IDoor door, IRfidReader reader, IDisplay display)
        {
            _display = display;
            _charger = charger;
            _door = door;
            _reader = reader;
            _door.DoorStateEvent += HandleDoorStateEvent;
            _reader.RfidReaderEvent += HandleRfidReaderEvent;
            _state = LadeskabState.Available;

        }


        public void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.isConnected())
                    {
                        //_door.LockDoor();
                        _charger.StartCharge();
                        _oldId = id;
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", id);
                        }
                        _display.DisplayCharging();
                        _display.DisplayOccupied();
                        //Console.WriteLine("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        _display.DisplayConnectError();
                        //Console.WriteLine("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _charger.StopCharge();
                        //_door.UnlockDoor();
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
                        }

                        //Console.WriteLine("Tag din telefon ud af skabet og luk døren");
                        _display.DisplayRemovePhone();
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        _display.DisplayReadError();
                        //Console.WriteLine("Forkert RFID tag");
                    }

                    break;
            }
        }
        public void DoorOpened()
        {
            //Console.WriteLine("Door Opened");
            _state = LadeskabState.DoorOpen;
            _display.DisplayConnectPhone();
        }
        public void DoorClosed()
        {
            //Console.WriteLine("Door Closed");
            _state = LadeskabState.Available;
            _display.DisplayReadRfid();
        }



        public string GetState()
        {
            return ("Current state is: " + _state);
            //Console.WriteLine("Current state is: " + _state);
        }


        //Handle Events
        private void HandleDoorStateEvent(object s, DoorStateEventArgs e)
        {
            _doorState = e.DoorState;
            
            if (_doorState == true)
            {
                DoorClosed();
            }
            else
                DoorOpened();
        }

        private void HandleRfidReaderEvent(object s, RfidReaderEventArgs e)
        {
            _newId = e.Id;
            RfidDetected(_newId);
        }

    }
}

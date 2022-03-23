﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Handin2
{
    public class StationControl : IStationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private IChargeControl _charger;
        private bool _doorState;
        private int _oldId;
        private int _newId;
        private IDoor _door;
        private IRfidReader _reader;
        private IDisplay _display;

        private string logFile = "logfile.txt"; // Navnet på systemets log-fil

        // Her mangler constructor
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

        private void HandleDoorStateEvent(object s, DoorStateEventArgs e)
        {
            _doorState = e.DoorState;
            if (_doorState == true)
            {
                DoorOpened();
            }
            else
                DoorClosed();
        }

        private void HandleRfidReaderEvent(object s, RfidReaderEventArgs e)
        {
            _newId = e.Id;
            RfidDetected(_newId);
        }

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        public void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.isConnected())
                    {
                        _door.LockDoor();
                        _charger.StartCharge();
                        _oldId = id;
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", id);
                        }
                        _display.DisplayCharging();
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
                        _door.UnlockDoor();
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
                        }

                        Console.WriteLine("Tag din telefon ud af skabet og luk døren");
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        Console.WriteLine("Forkert RFID tag");
                    }

                    break;
            }
        }

        public void DoorOpened()
        {
            _display.DisplayConnectPhone();
        }
        public void DoorClosed()
        {
            _display.DisplayReadRfid();
        }

        // Her mangler de andre trigger handlere
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handin2;
using NSubstitute;
using NUnit.Framework;
using UsbSimulator;
using System.IO;

namespace Handin2_test
{
    public class UnitTestStationControl
    {
        private StationControl uut;

        private IDisplay _display;
        private IChargeControl _charger;
        private IDoor _door;
        private IRfidReader _reader;
        private IUsbCharger _usbCharger;


        [SetUp]
        public void Setup()
        {
            _usbCharger = Substitute.For<IUsbCharger>();
            _display = Substitute.For<IDisplay>();
            _reader = Substitute.For<IRfidReader>();
            _charger = Substitute.For<IChargeControl>();
            _door = Substitute.For<IDoor>();

            //Initialize ChargeControl
            _charger = new ChargeControl(_usbCharger, _display);

            uut = new StationControl( _charger, _door, _reader, _display );
        }

        #region Door Methods
        /// <summary>
        /// Test DoorOpened and DoorClosed
        /// </summary>

        [Test]
        public void Ladeskabe_isAvaible_DoorOpened_DisplayCorrect()
        {
            uut.DoorOpened();
            _display.Received().DisplayConnectPhone();

        }

        [Test]
        public void Ladeskabe_isAvaible_DoorOpened_StateCorrect()
        {
            uut.DoorOpened();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                uut.GetState();

                string expected = string.Format("Current state is: DoorOpen{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }

        }


        [Test]
        public void Ladeskabe_isOpen_DoorClosed_DisplayCorrect()
        {
            uut.DoorClosed();
            _display.Received().DisplayReadRfid();
        }

        [Test]
        public void Ladeskabe_isOpen_DoorClosed_StateCorrect()
        {

            uut.DoorClosed();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                uut.GetState();

                string expected = string.Format("Current state is: Available{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }

        }
        #endregion



        #region Ladeskab states

        /// <summary>
        /// Test behavior in different states
        /// </summary>

        // State Available
        [Test]
        public void Ladeskabe_isAvailable_initial_state()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                uut.GetState();

                string expected = string.Format("Current state is: Available{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }

        }
        [Test]
        public void Ladeskabe_isAvaible_Charger_isConnected_State_Correct()
        {
            _usbCharger.Connected.Returns(true);
            uut.RfidDetected(5);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                uut.GetState();

                string expected = string.Format("Current state is: Locked{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }

        }

        [Test]
        public void Ladeskabe_isAvaible_Charger_isConnected_Display_Correct()
        {
            _usbCharger.Connected.Returns(true);
            uut.RfidDetected(5);
            _display.Received().DisplayCharging();

        }

        [Test]
        public void Ladeskabe_isAvaible_Charger_NOTConnected_Display_Correct()
        {
            _usbCharger.Connected.Returns(false);
            uut.RfidDetected(5);
            _display.Received().DisplayConnectError();

        }

        // Door Locked
        [Test]
        public void Ladeskabe_isLocked_id_Correct_Display_Correct()
        {
            _usbCharger.Connected.Returns(true);
            uut.RfidDetected(5);
            _display.Received().DisplayCharging();
            uut.RfidDetected(5);
            _display.DisplayRemovePhone();

        }

        [Test]
        public void Ladeskabe_Locked_id_Wrong_Display_Correct()
        {
            _usbCharger.Connected.Returns(true);
            uut.RfidDetected(5);
            _display.Received().DisplayCharging();
            uut.RfidDetected(6);
            _display.DisplayReadError();

        }

        [Test]
        public void Ladeskabe_Locked_Charger_Id_Correct_State_Correct()
        {
            _usbCharger.Connected.Returns(true);
            uut.RfidDetected(5);
            uut.RfidDetected(5);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                uut.GetState();

                string expected = string.Format("Current state is: Available{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());

            }

        }

        [Test]
        public void Ladeskabe_Locked_Charger_Id_Wrong_State_Correct()
        {
            _usbCharger.Connected.Returns(true);
            uut.RfidDetected(5);
            uut.RfidDetected(6);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                uut.GetState();

                string expected = string.Format("Current state is: Locked{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());

            }

        }

        // Door Opened

        #endregion

        #region Events
        /// <summary>
        /// Test events Doorstate and RfidReader
        /// </summary>

        // Doorstate Event
        [Test]
        public void Doorstate_event_state_true_DisplayCorrect()
        {
            _door.DoorStateEvent += Raise.EventWith(new DoorStateEventArgs { DoorState = true } ); // True = Open

            _display.Received().DisplayConnectPhone();

        }

        [Test]
        public void Doorstate_event_state_false_StateCorrect()
        {
            _door.DoorStateEvent += Raise.EventWith(new DoorStateEventArgs { DoorState = false }); // False = Closed

            _display.Received().DisplayReadRfid();

        }

        // RfidReader Event

        [TestCase(3)]
        public void RfidReaderEvent_Lock_DisplayCorrect(int newId)
        {
            _usbCharger.Connected.Returns(true);

            _reader.RfidReaderEvent += Raise.EventWith(new RfidReaderEventArgs{ Id = newId });

            _display.Received().DisplayCharging();

        }

        [TestCase(3)]
        public void RfidReaderEvent_Unlock_Correct_Id_DisplayCorrect(int sameId)
        {
            _usbCharger.Connected.Returns(true);

            _reader.RfidReaderEvent += Raise.EventWith(new RfidReaderEventArgs { Id = sameId });

            _reader.RfidReaderEvent += Raise.EventWith(new RfidReaderEventArgs { Id = sameId });

            _display.Received().DisplayRemovePhone();

        }

        [TestCase(3)]
        public void RfidReaderEvent_Unlock_Correct_Id_StateCorrect(int sameId)
        {
            _usbCharger.Connected.Returns(true);

            _reader.RfidReaderEvent += Raise.EventWith(new RfidReaderEventArgs { Id = sameId });

            _door.Received().LockDoor();
           
            _reader.RfidReaderEvent += Raise.EventWith(new RfidReaderEventArgs { Id = sameId });

            _door.Received().UnlockDoor();

        }

        [TestCase(3, 5)]
        public void RfidReaderEvent_Unlock_Wrong_Id_DisplayCorrect(int firstId, int secondId)
        {
            _usbCharger.Connected.Returns(true);

            _reader.RfidReaderEvent += Raise.EventWith(new RfidReaderEventArgs { Id = firstId });

            _reader.RfidReaderEvent += Raise.EventWith(new RfidReaderEventArgs { Id = secondId });

            _display.Received().DisplayReadError();

        }



        #endregion

    }


}


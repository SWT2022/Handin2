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

        //Helper 
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
        [Test]
        public void DoorOpened_returnsCorrect()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                uut.DoorOpened();

                string expected = string.Format("Door Opened{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }

        }
        [Test]
        public void DoorClosed_returnsCorrect()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                uut.DoorClosed();

                string expected = string.Format("Door Closed{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }

            
        }
        #endregion

        #region Ladeskab states
        [Test]
        public void Ladeskabe_isAvaible_initial_state()
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
        public void Ladeskabe_isAvaible_Charger_isConnected()
        {
            _usbCharger.Connected.Returns(true);
            _charger.isConnected(); // returns false
            uut.RfidDetected(5);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                uut.GetState();

                string expected = string.Format("Current state is: Locked{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }

        }
        #endregion

        #region Events
        [Test]
        public void Doorstate_event_state_true_DisplayCorrect()
        {
            _door.DoorStateEvent += Raise.EventWith(new DoorStateEventArgs { DoorState = true } ); // True = Open

            _display.Received().DisplayConnectPhone();

        }

        [Test]
        public void Doorstate_event_state_false_DisplayCorrect()
        {
            _door.DoorStateEvent += Raise.EventWith(new DoorStateEventArgs { DoorState = false }); // True = Open

            _display.Received().DisplayReadRfid();

        }

        


        #endregion

    }


}


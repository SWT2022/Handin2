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

        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _reader = Substitute.For<IRfidReader>();
            _charger = Substitute.For<IChargeControl>();
            _door = Substitute.For<IDoor>();    

            uut = new StationControl( _charger, _door, _reader, _display );
        }

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

    }


}


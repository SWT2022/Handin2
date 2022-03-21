using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handin2;
using NUnit.Framework;

namespace Handin2_test
{
    public class UnitTestDisplay
    {
        public Display _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new Display();
        }

        [Test]
        public void DisplayConnectPhone_CorrectId()
        {
            
            _uut.DisplayConnectPhone();

            Assert.That(_uut.DisplayId, Is.EqualTo(1));

        }

        [Test]
        public void DisplayReadRfid_CorrectId()
        {
           
            _uut.DisplayReadRfid();

            Assert.That(_uut.DisplayId, Is.EqualTo(2));

        }

        [Test]
        public void DisplayConnectError_CorrectId()
        {
            _uut.DisplayConnectError();

            Assert.That(_uut.DisplayId, Is.EqualTo(3));
        }

        [Test]
        public void DisplayOccupied_CorrectId()
        {
            _uut.DisplayOccupied();

            Assert.That(_uut.DisplayId, Is.EqualTo(4));
        }

        [Test]
        public void DisplayReadError_CorrectId()
        {
            _uut.DisplayReadError();

            Assert.That(_uut.DisplayId, Is.EqualTo(5));
        }

        [Test]
        public void DisplayRemovePhone_CorrectId()
        {
            _uut.DisplayRemovePhone();

            Assert.That(_uut.DisplayId, Is.EqualTo(6));
        }

        [Test]
        public void DisplayCharging_CorrectId()
        {
            _uut.DisplayCharging();

            Assert.That(_uut.DisplayId, Is.EqualTo(7));
        }

        [Test]
        public void DisplayFullyCharged_CorrectId()
        {
            _uut.DisplayFullyCharged();

            Assert.That(_uut.DisplayId, Is.EqualTo(8));
        }

        [Test]
        public void DisplayChargingError_CorrectId()
        {
            _uut.DisplayChargingError();

            Assert.That(_uut.DisplayId, Is.EqualTo(9));
        }
    }
}

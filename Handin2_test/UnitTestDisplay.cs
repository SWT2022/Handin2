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
        private Display _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new Display();
        }

        [Test]
        public void DisplayConnectPhone_CorrectId()
        {
            int DisplayId = 0;
            _uut.DisplayConnectPhone();

            Assert.That(DisplayId, Is.EqualTo(1));

        }

        [Test]
        public void DisplayReadRfid_CorrectId()
        {
            int Id = 0;
            _uut.DisplayReadRfid();

            Assert.That(Id, Is.EqualTo(2));

        }

        [Test]
        public void DisplayConnectError_CorrectId()
        {
            int Id = 0;
            _uut.DisplayConnectError();

            Assert.That(Id, Is.EqualTo(3));
        }

        [Test]
        public void DisplayOccupied_CorrectId()
        {
            int Id = 0;
            _uut.DisplayOccupied();

            Assert.That(Id, Is.EqualTo(4));
        }

        [Test]
        public void DisplayReadError_CorrectId()
        {
            int Id = 0;
            _uut.DisplayReadError();

            Assert.That(Id, Is.EqualTo(5));
        }

        [Test]
        public void DisplayRemovePhone_CorrectId()
        {
            int Id = 0;
            _uut.DisplayRemovePhone();

            Assert.That(Id, Is.EqualTo(6));
        }

        [Test]
        public void DisplayCharging_CorrectId()
        {
            int Id = 0;
            _uut.DisplayCharging();

            Assert.That(Id, Is.EqualTo(7));
        }

        [Test]
        public void DisplayFullyCharged_CorrectId()
        {
            int DisplayId = 0;
            _uut.DisplayFullyCharged();

            Assert.That(DisplayId, Is.EqualTo(8));
        }

        [Test]
        public void DisplayChargingError_CorrectId()
        {
            int Id = 0;
            _uut.DisplayChargingError();

            Assert.That(Id, Is.EqualTo(9));
        }
    }
}

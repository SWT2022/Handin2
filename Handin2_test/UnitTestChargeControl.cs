using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handin2;
using NSubstitute;
using NUnit.Framework;
using UsbSimulator;

namespace Handin2_test
{
    public class UnitTestChargeControl
    {
        private ChargeControl uut;
        private IUsbCharger usbCharger;
        private IDisplay display;
        [SetUp]
        public void Setup()
        {
            usbCharger = Substitute.For<IUsbCharger>();
            display = Substitute.For<IDisplay>();
            uut = new ChargeControl(usbCharger, display);
        }

        [Test]
        public void Test_isConnected_true()
        {

            usbCharger.Connected.Returns(true);

            Assert.That(uut.isConnected, Is.True);

        }

        [Test]
        public void Test_isConnected_false()
        {

            usbCharger.Connected.Returns(false);

            Assert.That(uut.isConnected, Is.False);
        }

        [Test]
        public void Test_StartCharge()
        {

            uut.StartCharge();

            usbCharger.Received().StartCharge();
        }

        [Test]
        public void Test_StopCharge()
        {

            uut.StopCharge();

            usbCharger.Received().StopCharge();
        }


        [TestCase(10)]
        [TestCase(25)]
        [TestCase(30)]
        [TestCase(45)]
        public void Test_CurrentChagned_currentIsCorrect(double newCurrent)
        {

            usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = newCurrent });
            Assert.That(uut._current, Is.EqualTo(newCurrent));

        }


        [TestCase(3)]
        [TestCase(5)]
        public void Test_CurrentChagned_State_FullyCharged(double newCurrent)
        {

            usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = newCurrent });

            display.Received().DisplayFullyCharged();


        }

        [TestCase(300)]
        [TestCase(500)]
        public void Test_CurrentChagned_State_Charging(double newCurrent)
        {

            usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = newCurrent });

            display.Received().DisplayCharging();


        }


        [TestCase(600)]
        public void Test_CurrentChagned_State_ChargingError(double newCurrent)
        {

            usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = newCurrent });

            display.Received().DisplayChargingError();

        }

        [TestCase(0)]
        [TestCase(-23)]
        public void Test_InvalidValues_ExeptionThrown(double newCurrent)
        {

            usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = newCurrent });

            Assert.That(() => uut.RegulateCharger(), Throws.TypeOf<ArgumentOutOfRangeException>());

        }





    }


}


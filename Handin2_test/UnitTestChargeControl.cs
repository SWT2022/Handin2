using System;
using System.Collections.Generic;
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

        //[Test]
        //public void Test_isConnected_true_StartCharge_isCalled()
        //{

        //    usbCharger.Connected.Returns(true);

        //    usbCharger.Received().StartCharge();

        //}


    }
}

using System;
using System.Collections.Generic;
using System.IO;
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
        public void DisplayConnectPhone_CorrectText()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                _uut.DisplayConnectPhone();

                string expected = string.Format("Tilslut telefon{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }


        [Test]
        public void DisplayReadRfid_CorrectText()
        {

            //StringWriter sw = new StringWriter();
            //Console.SetOut(sw);

            //_uut.DisplayReadRfid();

            //string expected = string.Format("Indlæs Rfid{0}", Environment.NewLine);
            //Assert.AreEqual(expected, sw.ToString());
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                _uut.DisplayReadRfid();

                string expected = string.Format("Indlæs Rfid{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void DisplayConnectError_CorrectText()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                _uut.DisplayConnectError();

                string expected = string.Format("Tilslutningsfejl{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void DisplayOccupied_CorrectText()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                _uut.DisplayOccupied();

                string expected = string.Format("Ladeskab optaget{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void DisplayReadError_CorrectText()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                _uut.DisplayReadError();

                string expected = string.Format("Rfid fejl{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void DisplayRemovePhone_CorrectText()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                _uut.DisplayRemovePhone();

                string expected = string.Format("Fjern telefon{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void DisplayCharging_CorrectText()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                _uut.DisplayCharging();

                string expected = string.Format("Ladning foregår{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void DisplayFullyCharged_CorrectText()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                _uut.DisplayFullyCharged();

                string expected = string.Format("Telefon er fuldt opladet{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void DisplayChargingError_CorrectText()
        {
            {

                using (StringWriter sw = new StringWriter())
                {
                    Console.SetOut(sw);

                    _uut.DisplayChargingError();

                    string expected = string.Format("FEJL{0}", Environment.NewLine);
                    Assert.AreEqual(expected, sw.ToString());
                }
            }
        }
    }
}

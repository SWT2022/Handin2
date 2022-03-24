using NUnit.Framework;
using Handin2;

namespace Handin2_test
{
    public class TestRfidReader
    {
        private RfidReader _uut;
        private RfidReaderEventArgs _RfidReaderEventArgs;
        [SetUp]
        public void Setup()
        {
            _RfidReaderEventArgs = null;

            _uut = new RfidReader();

            _uut.RfidReaderEvent +=
                (o, args) =>
                {
                    _RfidReaderEventArgs = args;
                };
        }

        [Test]
        public void SetID_NO_EventFired()
        {
            Assert.That(_RfidReaderEventArgs, Is.Null);
        }

        [Test]
        public void SetID_NO_EventFired_NO_Lisentner()
        {
            _uut.RfidReaderEvent -=
                (o, args) =>
                {
                    _RfidReaderEventArgs = args;
                };

            Assert.That(_RfidReaderEventArgs, Is.Null);
        }

        [Test]
        public void SetID_EventFired()
        {
            //Act
            _uut.setId(5);

            Assert.That(_RfidReaderEventArgs, Is.Not.Null);
        }

        [Test]
        public void SetId_CorrectValue()
        {
            //Act
            _uut.setId(5);

            Assert.That(_RfidReaderEventArgs.Id, Is.EqualTo(5));

        }
            
        [Test]
        public void SetId_Twice_CorrectValue()
        {
            //Act
            _uut.setId(5);
            _uut.setId(6);

            Assert.That(_RfidReaderEventArgs.Id, Is.EqualTo(6));
        }

        [Test]
        public void NewId_SameAs_OldId_CorrectValue()
        {
           
            //Act
            _uut.setId(5);
            _uut.setId(5);

            Assert.That(_RfidReaderEventArgs.Id, Is.EqualTo(5));
        }

        [Test]
        public void NewId_SameAs_OldId_EventFired()
        {

            //Act
            _uut.setId(5);
            _uut.setId(5);

            Assert.That(_RfidReaderEventArgs, Is.Not.Null);
        }

    }
}
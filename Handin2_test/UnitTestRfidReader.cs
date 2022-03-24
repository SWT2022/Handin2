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

        }

        [Test]
        public void SetID_NO_EventFired()
        {
            //
            Assert.That(_RfidReaderEventArgs, Is.Null);
        }

        

        [Test]
        public void SetID_EventFired_NO_Lisentner()
        {
            //Act
            _uut.setId(5);

            Assert.That(_RfidReaderEventArgs, Is.Null);
        }

        [Test]
        public void SetID_EventFired()
        {
            _uut.RfidReaderEvent +=
                (o, args) =>
                {
                    _RfidReaderEventArgs = args;
                };

            //Act
            _uut.setId(5);

            Assert.That(_RfidReaderEventArgs, Is.Not.Null);
        }



    

        [Test]
        public void SetId_CorrectValue()
        {
            _uut.RfidReaderEvent +=
                (o, args) =>
                {
                    _RfidReaderEventArgs = args;
                };
            //Act
            _uut.setId(5);

            Assert.That(_RfidReaderEventArgs.Id, Is.EqualTo(5));

        }
        //[Test]
        //public void SetId_CorrectValue_NO_Lisentner()
        //{
  
        //    //Act
        //    _uut.setId(5);

        //    Assert.That(_RfidReaderEventArgs.Id, Is.Null);

        //}

        [Test]
        public void SetId_Twice_CorrectValue()
        {
            _uut.RfidReaderEvent +=
                (o, args) =>
                {
                    _RfidReaderEventArgs = args;
                };
            //Act
            _uut.setId(5);
            _uut.setId(6);

            Assert.That(_RfidReaderEventArgs.Id, Is.EqualTo(6));
        }
        //[Test]
        //public void SetId_Twice_CorrectValue_NO_Lisentner()
        //{


        //    //Act
        //    _uut.setId(5);
        //    _uut.setId(6);

        //    Assert.That(_RfidReaderEventArgs.Id, Is.EqualTo(6));
        //}

        [Test]
        public void NewId_SameAs_OldId_CorrectValue()
        {
            _uut.RfidReaderEvent +=
                 (o, args) =>
                 {
                     _RfidReaderEventArgs = args;
                 };
            //Act
            _uut.setId(5);
            _uut.setId(5);

            Assert.That(_RfidReaderEventArgs.Id, Is.EqualTo(5));
        }
        //[Test]
        //public void NewId_SameAs_OldId_CorrectValue_NO_Lisentner()
        //{
        //    _uut.RfidReaderEvent -=
        //       (o, args) =>
        //       {
        //           _RfidReaderEventArgs = args;
        //       };
        //    //Act
        //    _uut.setId(5);
        //    _uut.setId(5);

        //    Assert.That(_RfidReaderEventArgs.Id, Is.EqualTo(5));
        //}

        [Test]
        public void NewId_SameAs_OldId_EventFired()
        {
            _uut.RfidReaderEvent +=
                (o, args) =>
                {
                    _RfidReaderEventArgs = args;
                };

            //Act
            _uut.setId(5);
            _uut.setId(5);

            Assert.That(_RfidReaderEventArgs, Is.Not.Null);
        }

        //[Test]
        //public void NewId_SameAs_OldId_EventFired_NO_Lisentner()
        //{
        //    _uut.RfidReaderEvent -=
        //       (o, args) =>
        //       {
        //           _RfidReaderEventArgs = args;
        //       };
        //    //Act
        //    _uut.setId(5);
        //    _uut.setId(5);

        //    Assert.That(_RfidReaderEventArgs, Is.Not.Null);
        //}

    }
}
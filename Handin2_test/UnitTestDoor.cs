using NUnit.Framework;
using Handin2;

namespace Handin2_test
{
    public class UnitTestDoor
    {
        private Door _uut;
        private DoorStateEventArgs _DoorstateEventArgs;
        [SetUp]
        public void Setup()
        {
            _DoorstateEventArgs = null;

            _uut = new Door();

            
        }

        [Test]
        public void Door_Locked_EventFired()
        {
            _uut.DoorStateEvent +=
                (o, args) =>
                {
                    _DoorstateEventArgs = args;
                };
            //Act
            _uut.UnlockDoor();
            _uut.LockDoor();

            Assert.That(_DoorstateEventArgs, Is.Not.Null);
        }
        [Test]
        public void Door_Locked_EventFired_NO_Lisentner()
        {

            //Act
            _uut.UnlockDoor();
            _uut.LockDoor();

            Assert.That(_DoorstateEventArgs, Is.Null);
        }

        [Test]
        public void Door_Locked_CorrectValue()
        {
            _uut.DoorStateEvent +=
                (o, args) =>
                {
                    _DoorstateEventArgs = args;
                };
            //Act
            _uut.UnlockDoor();
            _uut.LockDoor();

            Assert.That(_DoorstateEventArgs.DoorState, Is.EqualTo(true));
        }

        [Test]
        public void Door_UnLocked_EventFired()
        {
            _uut.DoorStateEvent +=
                (o, args) =>
                {
                    _DoorstateEventArgs = args;
                };
            //Act
            _uut.LockDoor();
            _uut.UnlockDoor();

            Assert.That(_DoorstateEventArgs, Is.Not.Null);
        }

        [Test]
        public void Door_Unlocked_CorrectValue()
        {
            _uut.DoorStateEvent +=
                (o, args) =>
                {
                    _DoorstateEventArgs = args;
                };
            //Act
            _uut.LockDoor();
            _uut.UnlockDoor();

            Assert.That(_DoorstateEventArgs.DoorState, Is.EqualTo(false));
        }

    }
}
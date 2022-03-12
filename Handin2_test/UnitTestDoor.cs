using NUnit.Framework;
using Handin2;

namespace Handin2_test
{
    public class Tests
    {
        private Door _uut;
        private DoorStateEventArgs _DoorstateEventArgs;
        [SetUp]
        public void Setup()
        {
            _DoorstateEventArgs = null;

            _uut = new Door();

            _uut.DoorStateEvent +=
                (o, args) =>
                {
                    _DoorstateEventArgs = args;
                };
        }

        [Test]
        public void Door_Locked_EventFired()
        {
            //Act
            _uut.UnlockDoor();
            _uut.LockDoor();

            Assert.That(_DoorstateEventArgs, Is.Not.Null);
        }

        [Test]
        public void Door_Locked_CorrectValue()
        {
            //Act
            _uut.UnlockDoor();
            _uut.LockDoor();

            Assert.That(_DoorstateEventArgs.DoorState, Is.EqualTo(true));
        }

        [Test]
        public void Door_UnLocked_EventFired()
        {
            //Act
            _uut.LockDoor();
            _uut.UnlockDoor();

            Assert.That(_DoorstateEventArgs, Is.Not.Null);
        }

        [Test]
        public void Door_Unlocked_CorrectValue()
        {
            //Act
            _uut.LockDoor();
            _uut.UnlockDoor();

            Assert.That(_DoorstateEventArgs.DoorState, Is.EqualTo(false));
        }

    }
}
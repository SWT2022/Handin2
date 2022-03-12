using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2
{
    public class Door : IDoor
    {
        private bool _DoorState { get; set; }  

        public event EventHandler<DoorStateEventArgs> DoorStateEvent;

        public void LockDoor()
        {
            _DoorState = true;
            OnDoorStateChanged(new DoorStateEventArgs { DoorState = _DoorState });
        }

        public void UnlockDoor()
        {
            _DoorState = false;
            OnDoorStateChanged(new DoorStateEventArgs { DoorState = _DoorState });
        }

        private void OnDoorStateChanged(DoorStateEventArgs e)
        {
            DoorStateEvent?.Invoke(this, e);
        }

    }
}

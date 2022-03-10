using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2
{
    internal interface IDoor
    {
        event EventHandler<DoorStateEventArgs> DoorStateEvent;

        void LockDoor();

        void UnlockDoor();

        bool DoorState { get; set; }


    }
}

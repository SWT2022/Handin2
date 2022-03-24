using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2
{
    public interface IDoor
    {
        event EventHandler<DoorStateEventArgs> DoorStateEvent;

        void LockDoor();

        void UnlockDoor(); 

    }
}

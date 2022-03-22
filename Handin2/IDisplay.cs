using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2
{
    public interface IDisplay
    {
        void DisplayConnectPhone();

        void DisplayReadRfid();

        void DisplayConnectError();

        void DisplayOccupied();

        void DisplayReadError();

        void DisplayRemovePhone();

        void DisplayCharging();

        void DisplayFullyCharged();

        void DisplayChargingError();
        

    }
}

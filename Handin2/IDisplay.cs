using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2
{
    internal interface IDisplay
    {
        void DisplayConnectPhone();

        void DisplayReadRfid();

        void DisplayConnectError();

        void DisplayOccupied();

        void DisplayReadError();

        void DisplayRemovePhone();

    }
}

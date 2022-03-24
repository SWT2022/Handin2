using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2
{
    public interface IRfidReader
    {
        event EventHandler<RfidReaderEventArgs> RfidReaderEvent;
        void setId(int id);

    }
}

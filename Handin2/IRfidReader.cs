﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2
{
    internal interface IRfidReader
    {
        event EventHandler<RfidReaderEventArgs> RfidReaderEvent;
        void setId(int id);

    }
}

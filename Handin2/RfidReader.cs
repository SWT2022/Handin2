using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2
{
    public class RfidReader : IRfidReader
    {
        
        public event EventHandler<RfidReaderEventArgs> RfidReaderEvent;

        private int _oldId;

        public void setId(int newId)
        {
            //if(_oldId != newId)
            {
                OnRfiRead(new RfidReaderEventArgs { Id = newId });
                _oldId = newId;
            }
        }

        private void OnRfiRead(RfidReaderEventArgs e)
        {
            RfidReaderEvent?.Invoke(this, e);
        }
    }
}

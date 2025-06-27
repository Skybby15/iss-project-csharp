using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_App.Utils
{
    public interface Subscriber
    {
        public void GetNotified(UpdateEvent upEvent);
    }
}

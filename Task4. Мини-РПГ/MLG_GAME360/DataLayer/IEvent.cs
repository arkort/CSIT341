using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IEvent
    {
        string EventHandle(Player player, Data data);
        IEvent CloneEvent();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Data
    {
        private List<IEvent> _HistoryEvents = new List<IEvent>();
        private Dictionary<int, Tuple<int, string>> _weapons = new Dictionary<int, Tuple<int, string>>(4);
        public bool ForceEvent { get; set; }
        public Player player { get; set; }
       
        public List<IEvent> HistoryEvents
        {
            get { return _HistoryEvents; }
            set { _HistoryEvents = value; }
        }

        public Dictionary<int, Tuple<int, string>> weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        public Data(Player player)
        {
            this.player = player;
        }

        public void AddEvent(IEvent gameEvent)
        {
            HistoryEvents.Add(gameEvent);
        }
    }
}

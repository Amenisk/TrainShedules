using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TrainShedules.ADOModel;

namespace TrainShedules.Classes
{
    public class StopInformation
    {
        public int StopId { get; set; }

        public string StationName { get;set; } 

        public string Time { get; set; }

        public string Highlighting { get; set; }

        public Color Color { get; set; }

        public StopInformation(Stop stop, DateTime time) 
        {
            StopId = stop.StopId;
            StationName = stop.Station.Name;
            Time = time.TimeOfDay.ToString();
            if(time < DateTime.Now)
            {
                Color = Colors.Gray;
            }
            else
            {
                Color = Colors.Black;
            }
        }
    }
}

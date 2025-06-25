using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datez.Helpers.Models
{
    public class EventUIModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime EventDate { get; set; }
        public string TimeDifferenceString { get; set; }
        public int TimeDifferenceProgress { get; set; }
    }
}

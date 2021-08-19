using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Models
{
    public class SortFilterModel
    {
        public string SortType { get; set; }
        public string SortVal { get; set; }

        public string FilterType { get; set; }
        public string SortCountry { get; set; }
        public string SortSports { get; set; }
        public string Filter { get; set; }
    }
}

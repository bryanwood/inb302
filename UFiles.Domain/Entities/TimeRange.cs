using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFiles.Domain.Entities
{
    public class TimeRange
    {
        public int TimeRangeId { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public virtual ICollection<TimeRangeRestriction> TimeRangeRestrictions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEventDelegateDemo
{
    public class WorkPerformedEventArgs
    {
        public int Hours { get; set; }
        public WorkType WorkType { get; set; }
    }
}

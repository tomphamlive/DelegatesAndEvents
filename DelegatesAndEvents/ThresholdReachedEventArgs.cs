using System;

namespace DelegatesAndEvents
{
    /// <summary>
    /// A class for returning data in the ThresholdReached event
    /// </summary>
    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public int TotalCount { get; set; }
    }
}

using System;

namespace DelegatesAndEvents
{
    /// <summary>
    /// A counter with an event that is published when its threshold has been reached.
    /// </summary>
    public class Counter
    {
        #region Constructors

        /// <summary>
        /// Creates a counter with a count threshold.
        /// </summary>
        /// <param name="threshold"></param>
        public Counter(int threshold)
        {
            Threshold = threshold;
        }

        #endregion

        #region Events

        /// <summary>
        /// An event for getting notified when the counter has reached its threshold.
        /// The event type is a delegate of type EventHandler, which is a method that takes 2 arguments and returns void.
        /// </summary>
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
        // public delegate void EventHandler<TEventArgs>(object sender, TEventArgs args);

        #endregion

        #region Properties

        /// <summary>
        /// Get the counter's threshold
        /// </summary>
        public int Threshold { get; }

        /// <summary>
        /// Get the counter's total count
        /// </summary>
        public int TotalCount { get; private set; }

        /// <summary>
        /// Get if counter has reached its threshold
        /// </summary>
        public bool HasReachedThreshold => TotalCount >= Threshold;

        #endregion

        #region Public Methods

        /// <summary>
        /// Increment the counter by the specified amount.
        /// </summary>
        /// <param name="amount"></param>
        public void Increment(int amount)
        {
            TotalCount += amount;

            if (HasReachedThreshold)
            {
                PublishThresholdReachedEvent(new ThresholdReachedEventArgs
                {
                    Threshold = Threshold,
                    TotalCount = TotalCount
                });
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Publish the ThresholdReached event when the threshold has been reached
        /// </summary>
        /// <param name="args"></param>
        private void PublishThresholdReachedEvent(ThresholdReachedEventArgs args)
        {
            ThresholdReached?.Invoke(this, args);
        }

        #endregion
    }
}

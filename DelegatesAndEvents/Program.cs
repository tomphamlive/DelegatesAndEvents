using System;

namespace DelegatesAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a counter with an initial threshold
            const int threshold = 10;
            var counter = new Counter(threshold);

            // subscribe to the counter's ThresholdReached event to get notified when the counter reaches its threshold
            counter.ThresholdReached += CounterOnThresholdReached;

            // increment the counter by 1
            Console.WriteLine("press 'a' key to increment counter");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                counter.Increment(1);
                Console.WriteLine($"Total Count = {counter.TotalCount}, Has reached threshold = {counter.HasReachedThreshold}");
            }
        }

        /// <summary>
        /// The delegate that the counter calls when it has reached its threshold
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void CounterOnThresholdReached(object sender, ThresholdReachedEventArgs args)
        {
            Console.WriteLine($"Counter has reached its threshold.  Threshold = {args.Threshold}, Total Count = {args.TotalCount} ");
        }
    }
}

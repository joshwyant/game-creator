using System.Collections.Generic;

namespace GameCreator.Engine
{
    internal class EventProcessor
    {
        /// <summary>
        /// Room creation code, etc.
        /// </summary>
        public Queue<PriorityEvent> PriorityEvents { get; set; } = new Queue<PriorityEvent>();

        public void PerformEvents()
        {
            // Perform priority events, such as room creation code, first.
            while (PriorityEvents.Count > 0)
            {
                var pe = PriorityEvents.Dequeue();
                pe.Process();
            }
            
            
        }
    }
}
using System;

namespace Project
{
    /// <summary>
    /// Basic task class.
    /// </summary>
    public class Task
    {
        public enum StatusType
        {
            Opened,
            InProgress,
            Closed
        }

        public string Name { get; private set; }
        public DateTime CreationTime { get; private set; }
        public StatusType Status { get; set; }


        public Task(string name, DateTime creationTime)
        {
            Name = name;
            CreationTime = creationTime;
        }
    }
}

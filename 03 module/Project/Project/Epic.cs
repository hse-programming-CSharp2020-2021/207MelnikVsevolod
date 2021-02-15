using System;
using System.Collections.Generic;

namespace Project
{
    /// <summary>
    /// Epic task class.
    /// </summary>
    public class Epic : Task
    {
        List<Task> subTasks;

        public Epic(string name, DateTime creationTime) : base(name, creationTime)
        {
        }
    }
}

using System;
using System.Collections.Generic;

namespace Project
{
    /// <summary>
    /// Project class.
    /// </summary>
    public class Project
    {
        public string Name { get; set; }
        public List<Task> tasks = new List<Task>();

        public int TasksCount { get { return tasks.Count; } }

        public Project(string name)
        {
            Name = name;
        }
    }
}

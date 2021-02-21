using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Project
{
    /// <summary>
    /// Project class.
    /// </summary>
    [Serializable, XmlInclude(typeof(Task)), XmlInclude(typeof(Epic)),
        XmlInclude(typeof(Story)), XmlInclude(typeof(Bug)), XmlInclude(typeof(User))]
    public class Project
    {
        public string Name { get; set; }
        public List<Task> tasks = new List<Task>();

        public int TasksCount { get { return tasks.Count; } }

        public Project(string name)
        {
            Name = name;
        }


        public Project()
        {
            Name = "new_project";
        }
    }
}

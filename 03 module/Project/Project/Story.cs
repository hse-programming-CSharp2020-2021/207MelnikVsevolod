using System;
namespace Project
{
    /// <summary>
    /// Story task class.
    /// </summary>
    public class Story : Task
    {
        public Story(string name, DateTime creationTime) : base(name, creationTime)
        {
        }
    }
}

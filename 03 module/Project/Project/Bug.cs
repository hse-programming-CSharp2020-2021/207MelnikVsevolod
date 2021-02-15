using System;
namespace Project
{
    /// <summary>
    /// Bug task class.
    /// </summary>
    public class Bug : Task
    {
        public Bug(string name, DateTime creationTime) : base(name, creationTime)
        {
        }
    }
}

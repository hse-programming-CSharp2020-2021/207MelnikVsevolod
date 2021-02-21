using System;
using System.Collections.Generic;

namespace Project
{
    /// <summary>
    /// Epic task class.
    /// </summary>
    [Serializable]
    public class Epic : Task, IAssignable
    {
        public List<Task> subTasks = new List<Task>();

        public Epic(string name, DateTime creationTime) : base(name, creationTime)
        {
        }

        public Epic() : base()
        { }

        void IAssignable.Assign(User user)
        {
            return;
        }

        void IAssignable.Remove(User user)
        {
            return;
        }

        public override string ToString()
        {
            return $"[Epic] {Name}   {CreationTime}   {GetStatus()}";
        }
    }
}

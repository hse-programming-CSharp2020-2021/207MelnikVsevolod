using System;
namespace Project
{
    /// <summary>
    /// Bug task class.
    /// </summary>
    [Serializable]
    public class Bug : Task, IAssignable
    {
        public Bug(string name, DateTime creationTime) : base(name, creationTime)
        {
        }

        public Bug() : base()
        { }

        public override string ToString()
        {
            return $"[Bug] {Name}   {CreationTime}   {GetStatus()}";
        }
    }
}

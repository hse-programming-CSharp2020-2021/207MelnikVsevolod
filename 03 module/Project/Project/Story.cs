using System;
namespace Project
{
    /// <summary>
    /// Story task class.
    /// </summary>
    [Serializable]
    public class Story : Task, IAssignable
    {
        void IAssignable.Assign(User user)
        {
            if (!users.Contains(user))
                users.Add(user);
        }

        public Story(string name, DateTime creationTime) : base(name, creationTime)
        {
        }

        public Story() : base()
        { }

        public override string ToString()
        {
            return $"[Story] {Name}   {CreationTime}   {GetStatus()}";
        }
    }
}

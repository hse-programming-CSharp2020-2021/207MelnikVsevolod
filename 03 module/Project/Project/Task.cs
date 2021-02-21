using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Project
{
    /// <summary>
    /// Basic task class.
    /// Everything is public for serialization to xml file.
    /// </summary>
    [Serializable]
    public class Task : IAssignable
    {
        public enum StatusType
        {
            Opened,
            InProgress,
            Closed
        }

        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public StatusType Status { get; set; }
        // Users assigned to this task.
        // This list is public for serialization.
        public List<User> users = new List<User>();

        public string GetStatus()
        {
            if (Status == StatusType.Closed)
                return "Закрыта";
            else if (Status == StatusType.InProgress)
                return "В работе";
            else
                return "Открыта";
        }

        List<User> IAssignable.Users
        {
            get
            {
                return users;
            }
        }

        void IAssignable.Assign(User user)
        {
            if (users.Count > 0)
                users.Clear();
            users.Add(user);
        }

        void IAssignable.Remove(User user)
        {
            if(users.Contains(user))
                users.Remove(user);
        }

        public Task(string name, DateTime creationTime)
        {
            Name = name;
            CreationTime = creationTime;
            Status = StatusType.Opened;
        }

        public Task()
        {
            Name = "new_task";
            CreationTime = DateTime.Now;
            Status = StatusType.Opened;
        }

        public override string ToString()
        {
            return $"[Task] {Name}   {CreationTime}   {GetStatus()}";
        }
    }
}

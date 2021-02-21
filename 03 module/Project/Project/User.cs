using System;
namespace Project
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }

        public User(string name)
        {
            Name = name;
        }

        public User()
        {
            Name = "new user.";
        }
    }
}

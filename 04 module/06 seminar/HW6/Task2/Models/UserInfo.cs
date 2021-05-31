using System;
namespace Task2.Models
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }

        public UserInfo()
        {
        }

        public UserInfo(string name, string mail, int id)
        {
            UserName = name;
            Email = mail;
            Id = id;
        }
    }
}

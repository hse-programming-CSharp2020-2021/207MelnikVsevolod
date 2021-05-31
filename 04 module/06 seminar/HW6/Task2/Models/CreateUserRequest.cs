using System;
namespace Task2.Models
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public CreateUserRequest()
        {
        }
    }
}

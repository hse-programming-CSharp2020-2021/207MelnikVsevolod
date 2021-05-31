using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        private static List<UserInfo> users = new List<UserInfo>();

        public UserController()
        {
        }

        [HttpPost("create-user")]
        public IActionResult CreateUser([FromBody] CreateUserRequest req)
        {
            var user = new UserInfo()
            {
                Id = users.Count + 1,
                Email = req.Email,
                UserName = req.UserName
            };
            users.Add(user);
            return Ok(user);
        }

        [HttpPost("get-user-by-id")]
        public IActionResult GetUserById([FromQuery] int id)
        {
            var result = users.Where(x => x.Id == id).ToList();
            if (result.Count == 0)
                return NotFound(new { Message = $"Пользователь с Id = {id} не найден" });
            return Ok(result.First());
        }

        [HttpPost("get-all-users")]
        public IActionResult GetAllUsers()
        {
            return Ok(users);
        }
    }
}

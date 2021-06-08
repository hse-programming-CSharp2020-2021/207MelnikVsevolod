using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using PiMessage.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace PiMessage.Controllers
{
    [Route("/api/[controller]")]
    public class MessangerController : Controller
    {
        Random rnd = new Random();

        public MessangerController()
        {
        }

        /// <summary>
        /// Save users.
        /// </summary>
        void SaveUsers()
        {
            Models.User.SaveUsers();
        }

        /// <summary>
        /// Save messages.
        /// </summary>
        void SaveMessages()
        {
            Models.Message.SaveMessages();
        }

        /// <summary>
        /// Get random string.
        /// </summary>
        /// <param name="length">Length of the string.</param>
        /// <param name="firstCapital">Is first letter capital.</param>
        /// <returns></returns>
        string GetRandomString(int length, bool firstCapital = false)
        {
            string str = "";
            if (firstCapital)
                str += (char)(rnd.Next('Z' - 'A' + 1) + 'A');
            else
                str += (char)(rnd.Next('z' - 'a' + 1) + 'a');
            for (int i = 1; i < length; ++i)
                str += (char)(rnd.Next('z' - 'a' + 1) + 'a');
            return str;
        }

        /// <summary>
        /// Greet user of the application.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("text/html")]
        public ActionResult<string> GreetUser()
        {
            string str = "";
            try
            {
                str = System.IO.File.ReadAllText("GreetingWindow.html");
            }
            catch
            {
                str = "Добро пожаловать в PiMessage!";
            }
            return str;
        }

        /// <summary>
        /// Initialize users and messages with random values.
        /// </summary>
        /// <returns></returns>
        [HttpPost("Init")]
        public IActionResult Init()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Models.User.Users = new List<User>();
            for (int i = 0; i < 5; ++i)
            {
                Models.User.Users.Add(new Models.User(GetRandomString(rnd.Next(4, 7), true),
                                                      GetRandomString(rnd.Next(4, 5)) + "@hse.edu.ru"));
            }
            Models.User.Users.Sort();
            Models.Message.Messages = new List<Message>();
            for (int i = 0; i < 10; ++i)
            {
                Models.Message.Messages.Add(new Message(GetRandomString(rnd.Next(4, 8), true),
                                                        GetRandomString(rnd.Next(4, 8)),
                                                        Models.User.Users[rnd.Next(5)].Email,
                                                        Models.User.Users[rnd.Next(5)].Email));
            }

            SaveMessages();
            SaveUsers();
            return Ok();
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUsers")]
        public IEnumerable<Models.User> GetUsers() => Models.User.Users;

        /// <summary>
        /// Get user with given email.
        /// </summary>
        /// <param name="email">Email of the user.</param>
        /// <returns></returns>
        [HttpGet("GetUser:{email}")] // параметр для маршрутизации
        public IActionResult GetUser(string email)
        {
            var user = Models.User.Users.SingleOrDefault(p => p.Email == email);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        /// <summary>
        /// Get messages sent from one user to another.
        /// </summary>
        /// <param name="emailSender">Sender email.</param>
        /// <param name="emailReceiver">Receiver email.</param>
        /// <returns>Messages or 404 if users do not exist.</returns>
        [HttpGet("GetChat:{emailSender},{emailReceiver}")] // параметр для маршрутизации
        public IActionResult GetChat(string emailSender, string emailReceiver)
        {
            var user1 = Models.User.Users.SingleOrDefault(p => p.Email == emailSender);
            var user2 = Models.User.Users.SingleOrDefault(p => p.Email == emailReceiver);

            // Check if users exist.
            if (user1 == null || user2 == null)
            {
                return NotFound();
            }

            var messages = Models.Message.Messages.FindAll(x => x.SenderId == emailSender && x.ReceiverId == emailReceiver);

            return Ok(messages);
        }

        /// <summary>
        /// Get all messages sent from user.
        /// </summary>
        /// <param name="emailSender">Sender's email.</param>
        /// <returns>Messages or 404 if user does not exist.</returns>
        [HttpGet("GetSent:{emailSender}")] // параметр для маршрутизации
        public IActionResult GetSent(string emailSender)
        {
            var user = Models.User.Users.SingleOrDefault(p => p.Email == emailSender);

            // Check if user exist.
            if (user == null)
            {
                return NotFound();
            }

            var messages = Models.Message.Messages.FindAll(x => x.SenderId == emailSender);

            return Ok(messages);
        }

        /// <summary>
        /// Get all messages received by the user.
        /// </summary>
        /// <param name="emailReceiver">Reciver's email.</param>
        /// <returns>Messages or 404 if user does not exist.</returns>
        [HttpGet("GetReceived:{emailReceiver}")] // параметр для маршрутизации
        public IActionResult GetReceived(string emailReceiver)
        {
            var user = Models.User.Users.SingleOrDefault(p => p.Email == emailReceiver);

            // Check if user exist.
            if (user == null)
            {
                return NotFound();
            }

            var messages = Models.Message.Messages.FindAll(x => x.ReceiverId == emailReceiver);

            return Ok(messages);
        }

        /// <summary>
        /// Get all users after offset, not more than limit.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUsers:limit:{limit},offset{offset}")]
        public IActionResult GetUsersWithLimit(int limit, int offset)
        {
            if (offset < 0 || limit <= 0)
                return BadRequest();
            Models.User.Users.Sort();
            return Ok(Models.User.Users.Skip(offset).Take(Math.Min(limit, Models.User.Users.Count - offset)));
        }

        /// <summary>
        /// Get all messages after offset, not more then limit.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetMessages")]
        public IEnumerable<Models.Message> GetMessages() => Models.Message.Messages;

        /// <summary>
        /// Create user and add it to all users.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns></returns>
        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] Models.User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // If user with this email exists - error.
            if (Models.User.Users.FindAll(x => x.Email == user.Email).Count > 0)
            {
                return BadRequest("User with this email already exists.");
            }
            else if (user.Email.Contains(','))
            {
                return BadRequest("User's email can't have charecter ',' in it.");
            }
            else
            {
                Models.User.Users.Add(user);
                Models.User.Users.Sort();
                SaveUsers();
                return CreatedAtAction(nameof(GetUsers), user);
            }
        }

        /// <summary>
        /// Add new message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <returns></returns>
        [HttpPost("AddMessage")]
        public IActionResult AddMessage([FromBody] Models.Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Check if users exist.
            if (Models.User.Users.FindAll(x => x.Email == message.SenderId).Count == 0)
            {
                return BadRequest("Sender with given email does not exist.");
            }
            if (Models.User.Users.FindAll(x => x.Email == message.ReceiverId).Count == 0)
            {
                return BadRequest("Receiver with given email does not exist.");
            }

            Message.Messages.Add(message);
            SaveMessages();
            return CreatedAtAction(nameof(GetMessages), message);
        }
    }
}

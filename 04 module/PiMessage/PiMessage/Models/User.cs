using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace PiMessage.Models
{
    /// <summary>
    /// User class.
    /// </summary>
    public class User : IComparable<User>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// All users in the app.
        /// </summary>
        static public List<User> Users = new List<User>();

        public User()
        {
            UserName = "NewUser";
            Email = "NewEmail";
        }

        public User(string name, string mail)
        {
            UserName = name;
            Email = mail;
        }

        public int CompareTo(User other)
        {
            return Email.CompareTo(other.Email);
        }

        /// <summary>
        /// Save users in memory.
        /// </summary>
        public static void SaveUsers()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(Users);
                File.WriteAllText("users.json", jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения: {ex.Message}");
            }
        }

        /// <summary>
        /// Load users from the memory.
        /// </summary>
        public static void LoadUsers()
        {
            // Initialize users from json files in memory.
            try
            {
                if (File.Exists("users.json"))
                {
                    string jsonString = File.ReadAllText("users.json");
                    Users = JsonSerializer.Deserialize<List<User>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки: {ex.Message}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;

namespace PiMessage.Models
{
    /// <summary>
    /// Message class.
    /// </summary>
    public class Message
    {
        // "Message" member's name was changed to "Text",
        // because class' name is already "Message".
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string SenderId { get; set; }
        [Required]
        public string ReceiverId { get; set; }

        /// <summary>
        /// All messages.
        /// </summary>
        static public List<Message> Messages = new List<Message>();

        public Message()
        {
            Subject = "New subject";
            Text = "Empty message";
            SenderId = "Sender ID";
            ReceiverId = "Receiver ID";
        }

        public Message(string subject, string text, string sender, string receiver)
        {
            Subject = subject;
            Text = text;
            SenderId = sender;
            ReceiverId = receiver;
        }

        /// <summary>
        /// Save message in memory.
        /// </summary>
        public static void SaveMessages()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(Messages);
                File.WriteAllText("messages.json", jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения: {ex.Message}");
            }
        }

        /// <summary>
        /// Load messages from the memory.
        /// </summary>
        public static void LoadMessages()
        {
            // Initialize users from json files in memory.
            try
            {
                if (File.Exists("messages.json"))
                {
                    string jsonString = File.ReadAllText("messages.json");
                    Messages = JsonSerializer.Deserialize<List<Message>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки: {ex.Message}");
            }
        }
    }
}

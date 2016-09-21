using System;

namespace Chatroom.ViewModels
{
    public class MessageViewModel
    {
        public string Message { get; set; }
        public string User { get; set; }
        public DateTimeOffset When { get; set; }
    }
}
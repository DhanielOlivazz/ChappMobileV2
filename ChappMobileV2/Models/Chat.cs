using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChappMobileV2.Models
{
    public class Chat
    {
        public int ChatId { get; set; }
        public string? UserName { get; set; }
        public string? LastMessage { get; set; }
        public string? ProfileImage { get; set; }
    }
}

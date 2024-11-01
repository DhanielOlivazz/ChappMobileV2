using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChappMobileV2.Models
{
    public class Message
    {
        public string? UserName { get; set; }
        public string? Content { get; set; }
        public bool IsOwnMessage { get; set; }
    }
}

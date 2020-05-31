using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnightsBridge.Models
{
    public class ChatMsg
    {
        public int ID { get; set; }
        public string User { get; set; }
        public string Message { get; set; }
        public DateTime Posted { get; set; }
    }
}

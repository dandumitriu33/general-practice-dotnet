﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsConsole.Models
{
    public class LogEntry
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public DateTime TimeOfEvent { get; set; } = DateTime.UtcNow;
    }
}

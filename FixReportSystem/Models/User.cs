﻿using System.Collections.Generic;

namespace FixReportSystem.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public List<Report> Reports { get; set; }
    }
}

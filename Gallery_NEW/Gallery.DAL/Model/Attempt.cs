﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.DAL.Model
{
    public class Attempt
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string IpAddress { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsSuccess { get; set; }

    }
}

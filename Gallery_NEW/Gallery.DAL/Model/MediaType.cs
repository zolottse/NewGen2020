﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.DAL.Model
{
    public class MediaType
    {
        public int Id { get; set; }
        public string Type { get; set; }


        public ICollection<Media> Media { get; set; } = 
            new List<Media>();

    }
}

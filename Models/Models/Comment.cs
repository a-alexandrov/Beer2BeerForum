﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Comment:BaseEntity
    {
        public string Content { get; set; }
        public int PostID { get; set; }
        public Post Post { get; set; }

    }
}

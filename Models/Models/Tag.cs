﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Tag:HasID
    {
        public string Name { get; set; }
        public List<TagPost> TagPosts { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer2Beer
{
    public class Tag:BaseEntity
    {
        public string Name { get; set; }
        public List<TagPost> TagPosts { get; set; }
    }
}
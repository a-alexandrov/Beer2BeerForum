﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer2Beer
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
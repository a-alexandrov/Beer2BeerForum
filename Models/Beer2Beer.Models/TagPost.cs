using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer2Beer
{
    public class TagPost
    {
        public int TagID { get; set; }
        public Tag Tag { get; set; }
        public int PostID { get; set; }
        public Post Post { get; set; }
    }
}

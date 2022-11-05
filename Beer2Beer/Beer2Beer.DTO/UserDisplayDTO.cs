using System;
using System.Collections.Generic;
using System.Text;

namespace Beer2Beer.DTO
{
    public class UserDisplayDto
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public byte[] AvatarImage { get; set; }
        public string ImageType { get; set; }
    }
}

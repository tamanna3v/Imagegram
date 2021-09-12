using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Imagegram.Dto
{
    public class PostDto
    {
        public PostDto()
        {
            ImagePath= $"/Temp/Downloads/";
        }
        public long Id{ get; set; }
        public string Caption { get; set; }
        public string Image { get; set; }
        public string ImagePath { get;}
        public List<Comments> Comments{ get; set; }
        public long CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}

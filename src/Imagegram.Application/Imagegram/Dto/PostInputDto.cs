using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Imagegram.Dto
{
    [AutoMapFrom(typeof(Post))]
    public class PostInputDto
    {
        public string Caption { get; set; }
        public string Image { get; set; }
    }
}

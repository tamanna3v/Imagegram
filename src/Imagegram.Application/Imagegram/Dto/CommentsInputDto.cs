using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Imagegram.Dto
{
    [AutoMapFrom(typeof(Comments))]
    public class CommentsInputDto
    {
        public string Content { get; set; }
        public long PostId { get; set; }
    }
}

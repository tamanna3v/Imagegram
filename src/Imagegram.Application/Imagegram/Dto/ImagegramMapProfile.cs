using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Imagegram.Dto
{
    public class ImagegramMapProfile:Profile
    {
        public ImagegramMapProfile()
        {
            CreateMap<PostInputDto, Post>();
            CreateMap<CommentsInputDto, Comments>();
            CreateMap<PostInputDto, Post>().ForMember(x => x.Comments, opt => opt.Ignore());
            CreateMap<Post, PostDto>();
            //.ForMember(x => x.Comments, opt => opt.Ignore());
            
        }

    }
}

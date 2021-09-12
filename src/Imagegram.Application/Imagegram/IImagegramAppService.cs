using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Imagegram.Imagegram.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Imagegram
{
    public interface IImagegramAppService : IApplicationService
    {
       /// <summary>
       /// Create Post with images
       /// </summary>
       /// <param name="input"></param>
       /// <returns></returns>
       Task<long> CreatePost(PostInputDto input);
        /// <summary>
        ///Create Comments  
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<long> CreateComments(CommentsInputDto input);
        /// <summary>
        /// Fetch all posts by user
        /// </summary>
        /// <returns></returns>
        Task<PagedPostResultDto> GetAllPostsWithComments(Pagination input);
    }
}

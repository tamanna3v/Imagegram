using Abp.Application.Services.Dto;

namespace Imagegram.Imagegram.Dto
{
    public class PagedPostResultDto
    {
        public ListResultDto<PostDto> Posts { get; set; }
        public Pagination Pagination { get; set; }
    }
}


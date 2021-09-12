using Abp.Application.Services.Dto;

namespace Imagegram.Imagegram.Dto
{
    public class Pagination
    {
        public long? Before { get; set; }
        public long? After { get; set; }
    }
}


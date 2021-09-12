using System.Collections.Generic;
using Imagegram.Roles.Dto;

namespace Imagegram.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}

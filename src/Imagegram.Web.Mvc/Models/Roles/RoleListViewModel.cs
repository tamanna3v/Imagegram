using System.Collections.Generic;
using Imagegram.Roles.Dto;

namespace Imagegram.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}

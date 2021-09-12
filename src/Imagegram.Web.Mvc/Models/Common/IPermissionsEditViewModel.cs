using System.Collections.Generic;
using Imagegram.Roles.Dto;

namespace Imagegram.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}
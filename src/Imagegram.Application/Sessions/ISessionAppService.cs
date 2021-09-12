﻿using System.Threading.Tasks;
using Abp.Application.Services;
using Imagegram.Sessions.Dto;

namespace Imagegram.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

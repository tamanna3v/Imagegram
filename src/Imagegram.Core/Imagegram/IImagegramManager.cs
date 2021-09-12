using Abp.Domain.Services;
using Imagegram.Authorization.Users;
using System.Threading.Tasks;

namespace Imagegram.Imagegram
{
    public interface IImagegramManager: IDomainService
    {
        Task DeleteAllObjects(User user);
    }
}
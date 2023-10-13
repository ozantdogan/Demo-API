using OTD.Core.Models;

namespace OTD.Business.Abstract
{
    public interface IAuthBusiness
    {
        public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);
    }
}
using OTD.Core.Helper;

namespace OTD.Business.Abstract
{
    public interface ITokenBusiness
    {
        public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
    }
}
using OTD.Business.Helper;
using OTD.Core.Models;

namespace OTD.Business.Abstract
{
    public class BaseBusiness
    {
        internal ResponseViewModel GenerateResponse<T>(bool success, ResponseCode code, T? data)
        {
            return new ResponseViewModel
            {
                Success = success,
                Message = code.Message,
                Data = data
            };
        }
    }
}

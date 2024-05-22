namespace OTD.Business.Helper;

public class ResponseCode
{
    public static ResponseCode Success = new ResponseCode("0", "Entity not found");
    public static ResponseCode NotFound = new ResponseCode("1", "Entity not found");
    public static ResponseCode CreatedSuccess = new ResponseCode("2", "Created success");
    public static ResponseCode CreatedFailure = new ResponseCode("3", "Created failure");
    public static ResponseCode UpdatedSuccess = new ResponseCode("4", "Updated success");
    public static ResponseCode UpdatedFailure = new ResponseCode("5", "Updated failure");
    public static ResponseCode DeletedSuccess = new ResponseCode("6", "Deleted success");
    public static ResponseCode DeletedFailure = new ResponseCode("7", "Deleted failure");

    public ResponseCode(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; set; }
    public string Message { get; set; }
}

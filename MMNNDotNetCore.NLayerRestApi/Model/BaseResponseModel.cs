namespace MMNNDotNetCore.NLayerRestApi.Model;

public class BaseResponseModel
{
    public ResponseModel Response { get; set; } = new ResponseModel();
    
}

public class ResponseModel
{
    public bool IsSuccess
    {
        get
        {
            return ResType == EnumResType.Success;
        }
    }

    public EnumResType ResType{get;set;}
    public string ResMessage { get; set; }
    
}

public enum EnumResType
{
    Default,
    Success,
    Fail
}
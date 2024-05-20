namespace MMNNDotNetCore.NLayerRestApi.Model;

public class BaseResponseModel
{
    public ResponseModel Response { get; set; }

    
}

public class ResponseModel
{
    public ResponseModel(EnumResType resType, string message)
    {
        ResType = resType;
        ResMessage = message;
    }
    
    public bool IsSuccess
    {
        get
        {
            return ResType == EnumResType.Success;
        }
    }

    public bool IsError
    {
        get
        {
            return ResType == EnumResType.Fail;
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
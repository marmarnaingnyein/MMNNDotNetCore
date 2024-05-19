namespace MMNNDotNetCore.Shared;

public static class DevCode
{
    public static bool IsNull(object? str)
    {
        if (str is null)
            return false;

        if ((string)str == "")
            return false;
        
        return true;
    }
}
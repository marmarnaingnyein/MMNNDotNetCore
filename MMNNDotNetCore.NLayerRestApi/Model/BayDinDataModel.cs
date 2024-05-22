namespace MMNNDotNetCore.NLayerRestApi.Model;

public class BayDinDataModel
{
    public Questions[] questions { get; set; }
    public Answers[] answers { get; set; }
    public string[] numberList { get; set; }
}

public class Questions
{
    public int questionNo { get; set; }
    public string questionName { get; set; }
}

public class Answers
{
    public int questionNo { get; set; }
    public int answerNo { get; set; }
    public string answerResult { get; set; }
}

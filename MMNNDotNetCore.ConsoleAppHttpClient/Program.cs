﻿// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

string jsonData = await File.ReadAllTextAsync("data.json");
MainDto? model = JsonConvert.DeserializeObject<MainDto>(jsonData);

foreach (var item in model!.questions)
{
    Console.WriteLine(item.questionNo);
}

Console.ReadLine();

public class MainDto
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


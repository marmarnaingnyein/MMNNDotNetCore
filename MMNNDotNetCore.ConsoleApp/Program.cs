using MMNNDotNetCore.ConsoleApp;

AdoDotNetExamples blogService = new AdoDotNetExamples();

Console.WriteLine("===============================");
Console.WriteLine("1. Select All");
Console.WriteLine("2. Select By Filter");
Console.WriteLine("3. Create");
Console.WriteLine("4. Update");
Console.WriteLine("5. Delete");
Console.WriteLine("===============================");
string process = "c";

while (string.Equals(process.ToLower(), "c"))
{
    Console.WriteLine("===============================");
    Console.WriteLine("1. Select All");
    Console.WriteLine("2. Select By Filter");
    Console.WriteLine("3. Create");
    Console.WriteLine("4. Update");
    Console.WriteLine("5. Delete");
    Console.WriteLine("===============================");
    Console.WriteLine("Enter your choice number:");
    string? strChoice = Console.ReadLine();
    int choice = string.IsNullOrEmpty(strChoice) ? 0 : Convert.ToInt32(strChoice);

// ReSharper disable once LoopVariableIsNeverChangedInsideLoop
    while (string.IsNullOrEmpty(strChoice) || choice is <= 0 or > 6)
    {
        Console.WriteLine("Enter your choice number:");
        strChoice = Console.ReadLine()!;
        choice = string.IsNullOrEmpty(strChoice) ? 0 : Convert.ToInt32(strChoice);
    }

    switch (choice)
    {
        case 1: 
            blogService.SelectAll();
            break;
        case 2:
            blogService.SelectBy();
            break;
        case 3:
            blogService.Create();
            break;
        case 4:
            blogService.Update();
            break;
        case 5:
            blogService.Delete();
            break;
    }
    
    Console.WriteLine("Please enter [E] to exit or [C] to continue");
    process = Console.ReadLine()!;

    if (string.Equals(process.ToLower(), "e"))
    {
        Console.WriteLine("Thanks for using....");
    }
}


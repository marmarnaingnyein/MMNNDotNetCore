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
    
    Console.WriteLine("Enter your choice number:");
    int choice = Convert.ToInt32(Console.ReadLine());

// ReSharper disable once LoopVariableIsNeverChangedInsideLoop
    while (choice is <= 0 or > 6)
    {
        Console.WriteLine("Enter your choice number:");
        choice = Convert.ToInt32(Console.ReadLine());
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
    }
    
    Console.WriteLine("Please enter [E] to exit or [C] to continue");
    process = Console.ReadLine()!;

    if (string.Equals(process.ToLower(), "e"))
    {
        Console.WriteLine("Thanks for using....");
    }
}


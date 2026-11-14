using System.Net;

List<string?> tasks = new();
HashSet<int> CompletedTask = new();


while (true)
{
    Console.WriteLine("Select an Option: ");
    Console.WriteLine("1: Add task");
    Console.WriteLine("2: List all task");
    Console.WriteLine("3: Mark a task complete");
    Console.WriteLine("4: Delete a task");
    Console.WriteLine("5: Show all unfinished task");
    Console.WriteLine("6: Quit Program");
    string? response = Console.ReadLine();

    if (response == "6")
    {
        break;
    }

    if (!int.TryParse(response, out int choice) || choice > 6)
    {
        Console.WriteLine("Invalid Input");

    }
    else
    {


        ChooseOption(choice, tasks);
    }





}


static void PrintAllTask(List<string?> list)
{
    for (int n = 0; n < list.Count; n++)
    {
        Console.WriteLine($"{n} :{list[n]}");
    }

}

static void ChooseOption(int option, List<string?> list)
{
    switch (option)
    {
        case 1:
            AddTask(list);
            break;
        case 2:
            PrintAllTask(list);
            break;
    }
}



static void AddTask(List<string?> tasks)
{
    Console.Write("Insert name of task: ");

    tasks.Add(Console.ReadLine());
}

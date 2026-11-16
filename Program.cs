using System.Data.Common;
using System.Globalization;
using System.Net;
List<(int Id, string Title)> tasks = new();
HashSet<int> completedTask = new();
int taskID = 0;


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

    if (!int.TryParse(response, out int choice) || choice < 1 || choice > 6)
    {
        Console.WriteLine("Invalid Input");

    }
    else
    {

        switch (choice)
        {
            case 1:
                AddTask(tasks);
                break;
            case 2:
                PrintAllTask(tasks);
                break;
            case 3:
                MarkComplete(taskID, tasks, completedTask);
                break;
        }
    }

}


static void PrintAllTask(List<(int Id, string Title)> list)
{
    for (int n = 0; n < list.Count; n++)
    {
        Console.WriteLine($"{list[n].Id}: {list[n].Title}");
    }

}



static void AddTask(List<(int Id, string Title)> tasks)
{
    int taskID = tasks.Count + 1;
    Console.Write("Insert name of task to add: ");
    string taskname = Console.ReadLine();
    tasks.Add((taskID, taskname));

}

static void MarkComplete(int n, List<(int Id, string Title)> tasks, HashSet<int> completionStatuses)
{
    completionStatuses.Add(n);
}

static void DeleteTask(int n, List<string> tasks, HashSet<int> completionStatuses)
{
    Console.Write("Insert task number to delete: ");
    if (!int.TryParse(Console.ReadLine(), out int choice) || n < 1 || choice > tasks.Count)
    {
        Console.WriteLine($"Please enter a number from 1 to {tasks.Count}.");
        return;
    }

    int index = n - 1;
    completionStatuses.Remove(index);
    tasks.RemoveAt(index);


}
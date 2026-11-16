using System.Data.Common;
using System.Globalization;
using System.Net;
List<(int Id, string Title)> tasks = new();
HashSet<int> completedTask = new();
var deleted = new Stack<(int Index, int Id, string Title)>();
int nextId = 1;


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
                AddTask(tasks, ref nextId);
                break;
            case 2:
                PrintAllTask(tasks, completedTask);
                break;
            case 3:
                MarkComplete(tasks, completedTask);
                break;
        }
    }

}


static void PrintAllTask(List<(int Id, string Title)> tasks, HashSet<int> completedIds)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("There are no tasks.");
        return;
    }

    for (int n = 0; n < tasks.Count; n++)
    {
        var task = tasks[n];
        string completion = completedIds.Contains(task.Id) ? "Completed" : "Incomplete";
        Console.WriteLine($"{n + 1}: {task.Title} - {completion}");
    }

}






static void AddTask(List<(int Id, string Title)> tasks, ref int nextId)
{
    Console.Write("Name of task to add: ");
    string? title = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(title))
    {
        Console.WriteLine("Task name can't be empty.");
        return;
    }

    tasks.Add((nextId, title));
    nextId++;
}

static void MarkComplete(List<(int Id, string Title)> tasks, HashSet<int> completedIds)
{
    if (ReadTaskIndex(tasks, "Task number to mark complete: ") is not int index)
    {
        return;
    }

    var task = tasks[index];
    if (completedIds.Add(task.Id))
    {
        Console.WriteLine($"Marked \"{task.Title}\" as complete.");

    }
    else
    {
        Console.WriteLine($"\"{task.Title}\" was already complete.");
    }

}

static void DeleteTask(List<(int Id, string Title)> tasks, Stack<(int Index, int Id, string Title)> deleted)
{
    if (ReadTaskIndex(tasks, "Task number to delete: ") is not int index)
    {
        return;
    }

    var task = tasks[index];
    tasks.RemoveAt(index);
    deleted.Push((index, task.Id, task.Title));



}


static int? ReadTaskIndex(List<(int Id, string Title)> tasks, string prompt)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("There are no tasks.");
        return null;
    }

    Console.Write(prompt);
    if (!int.TryParse(Console.ReadLine(), out int number) || number < 1 || number > tasks.Count)
    {
        Console.WriteLine($"Please enter a number from 1 to {tasks.Count}.");
        return null;
    }

    return number - 1;
}
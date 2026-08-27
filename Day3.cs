using System;
using System.Collections.Generic;

public abstract class Entity
{
    public abstract int Id { get; set; }
}

public class TaskItem : Entity
{
    private static int nextId = 1;

    public override int Id { get; set; }

    public string Description { get; set; }

    private string status;

    public string Status
    {
        get
        {
            return status;
        }

        set
        {
            if (value.ToLower() == "new" ||
                value.ToLower() == "pending" ||
                value.ToLower() == "completed")
            {
                status = value;
            }
            else
            {
                throw new Exception(
                    "Invalid status. Please enter New, Pending, or Completed."
                );
            }
        }
    }

    public TaskItem(string description, string status)
    {
        Id = nextId++;
        Description = description;
        Status = status;
    }
}

class Program
{
    static List<TaskItem> tasks = new List<TaskItem>();

    // Add Task
    static void AddTask()
    {
        Console.Write("Enter the description of your task: ");

        string description = Console.ReadLine();

        TaskItem task = new TaskItem(description, "New");

        tasks.Add(task);

        Console.WriteLine("Task is added successfully.");
    }

    // List Tasks
    static void ListTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        foreach (TaskItem task in tasks)
        {
            Console.WriteLine("Task ID: " + task.Id);
            Console.WriteLine("Description: " + task.Description);
            Console.WriteLine("Status: " + task.Status);
            Console.WriteLine();
        }
    }

    // Complete Task
    static void CompleteTask()
    {
        Console.Write("Enter ID: ");

        int id = int.Parse(Console.ReadLine());

        foreach (TaskItem task in tasks)
        {
            if (task.Id == id)
            {
                task.Status = "Completed";

                Console.WriteLine("Task is completed.");

                return;
            }
        }

        Console.WriteLine("Task is not found.");
    }

    // Delete Task
    static void DeleteTask()
    {
        Console.Write("Enter ID: ");

        int id = int.Parse(Console.ReadLine());

        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].Id == id)
            {
                tasks.RemoveAt(i);

                Console.WriteLine("Task is deleted.");

                return;
            }
        }

        Console.WriteLine("Task is not found.");
    }

    // Update Task Status
    static void UpdateTaskStatus()
    {
        Console.Write("Enter the ID: ");

        int id = int.Parse(Console.ReadLine());

        foreach (TaskItem task in tasks)
        {
            if (task.Id == id)
            {
                Console.Write(
                    "Enter status (New, Pending, or Completed): "
                );

                string status = Console.ReadLine();

                try
                {
                    task.Status = status;

                    Console.WriteLine("Status updated successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return;
            }
        }

        Console.WriteLine("Task not found.");
    }

    // Search By Status
    static void SearchByStatus()
    {
        Console.Write(
            "Enter the status (New, Pending, or Completed): "
        );

        string status = Console.ReadLine();

        bool searchFound = false;

        foreach (TaskItem task in tasks)
        {
            if (task.Status.ToLower() == status.ToLower())
            {
                Console.WriteLine("Task ID: " + task.Id);
                Console.WriteLine(
                    "Description: " + task.Description
                );
                Console.WriteLine("Status: " + task.Status);
                Console.WriteLine();

                searchFound = true;
            }
        }

        if (!searchFound)
        {
            Console.WriteLine(
                "No task found with status: " + status
            );
        }
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- TASK MANAGEMENT SYSTEM ---");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. List Tasks");
            Console.WriteLine("3. Complete Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Search By Status");
            Console.WriteLine("6. Update Status");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice: ");

            int choice;

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddTask();
                    break;

                case 2:
                    ListTasks();
                    break;

                case 3:
                    CompleteTask();
                    break;

                case 4:
                    DeleteTask();
                    break;

                case 5:
                    SearchByStatus();
                    break;

                case 6:
                    UpdateTaskStatus();
                    break;

                case 7:
                    Console.WriteLine("Program exited.");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
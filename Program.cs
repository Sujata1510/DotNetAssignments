using System;
using System.Collections.Generic;


public class WorkItem : IComparable<WorkItem>
{
    public string Title { get; set; } = "";

    public int Priority { get; set; }

    public virtual void Describe()
    {
        Console.WriteLine($"{Title} - Priority: {Priority}");
    }

    public int CompareTo(WorkItem? other)
    {
        if (other == null)
            return 1;

        return Priority.CompareTo(other.Priority);
    }
}

public class TaskItem : WorkItem
{
    public override void Describe()
    {
        Console.WriteLine($"Task: {Title} - Priority: {Priority}");
    }
}


class Program
{
    static void Main()
    {
        List<WorkItem> tasks = new List<WorkItem>();

        tasks.Add(new TaskItem
        {
            Title = "Write Documentation",
            Priority = 3
        });

        tasks.Add(new TaskItem
        {
            Title = "Fix Login Bug",
            Priority = 1
        });

        tasks.Add(new TaskItem
        {
            Title = "Test Application",
            Priority = 2
        });

        Console.WriteLine("Before Sorting:");

        foreach (var task in tasks)
        {
            task.Describe();
        }

        tasks.Sort();

        Console.WriteLine("\nAfter Sorting:");

        foreach (var task in tasks)
        {
            task.Describe();
        }

        Queue<WorkItem> reviewQueue = new Queue<WorkItem>();

        foreach (var task in tasks)
        {
            reviewQueue.Enqueue(task);
        }

        Console.WriteLine("\nReview Queue:");

        while (reviewQueue.Count > 0)
        {
            WorkItem item = reviewQueue.Dequeue();
            item.Describe();
        }
    }
}
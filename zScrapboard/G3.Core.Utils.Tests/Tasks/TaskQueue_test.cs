Sure, here are some test cases for the TaskQueue. We will use XUnit framework for the test creation.

```C#
using System;
using System.Threading.Tasks;
using Xunit;
using G3.Core.Utils.Tasks;

public class TaskQueueTests
{
    [Fact]
    public async Task Test_AddMethod_LessThanMax()
    {
        // Arrange
        var task = new Task<string>(() => "Task");
        var taskQueue = new TaskQueue<string>(2); // MaxQueueLength is 2

        // Act
        await taskQueue.Add(task);

        // Assert
        Assert.Single(taskQueue._internalList);
    }

    [Fact]
    public async Task Test_AddMethod_MoreThanMax()
    {
        // Arrange
        var task = new Task<string>(() => "Task");
        var task2 = new Task<string>(() => "Task2");
        var task3 = new Task<string>(() => "Task3");
        var taskQueue = new TaskQueue<string>(2); // MaxQueueLength is 2

        // Act
        await taskQueue.Add(task);
        await taskQueue.Add(task2);
        await taskQueue.Add(task3);

        // Assert
        Assert.Equal(2, taskQueue._internalList.Count);
    }

    [Fact]
    public async Task Test_CompleteTasks()
    {
        // Arrange
        var task = Task.Factory.StartNew(() => "Task");
        var task2 = Task.Factory.StartNew(() => "Task2");
        var taskQueue = new TaskQueue<string>(2); // MaxQueueLength is 2
        await taskQueue.Add(task);
        await taskQueue.Add(task2);

        // Act
        var result = await taskQueue.CompleteTasks();

        // Assert
        Assert.Equal(2, result.Length);
        Assert.Empty(taskQueue._internalList); // The list should be cleared after completion
    }
}
```
This code provides 3 test scenarios:
- Adding a single task to the queue and validating that it was added successfully.
- Adding 3 tasks to a queue with a limit of 2, validating that only 2 tasks are allowed in the queue.
- Testing the "CompleteTasks" method to ensure it can successfully run and complete tasks.

NOTE: "_internalList" is a private field, and in order to access it in test cases, it would be great to have a method or a property to be able to access this field in a more proper way, without breaking encapsulation principles.
---
title: TaskQueue Class Documentation
date: 2023-10-09
description: Documentation for the TaskQueue class in the G3.Core.Utils.Tasks namespace for Hugo.
draft: false
---

## Overview

The `TaskQueue<T>` class is a utility that manages asynchronous tasks with an upper limit on the number of concurrent tasks in the queue. It is part of the `G3.Core.Utils.Tasks` namespace.

## Namespace

```csharp
namespace G3.Core.Utils.Tasks
```

## Class Declaration

```csharp
public class TaskQueue<T>
```

### Fields

- **_internalList**: A private `List<Task<T>>` that holds the tasks in the queue.

- **_maxQueueLength**: A private `int` that defines the maximum length of the task queue.

### Constructors

#### `TaskQueue(int maxQueueLength)`

Initializes a new instance of the `TaskQueue<T>` class with a specified maximum queue length.

- **Parameters**
  - `maxQueueLength`: An `int` representing the maximum number of tasks allowed in the queue.

### Methods

#### `Add(Task<T> task)`

Adds a task to the task queue. If the number of in-progress tasks exceeds the maximum queue length, it awaits the first incomplete task before adding new tasks.

- **Parameters**
  - `task`: A `Task<T>` to be added to the queue.

- **Returns**
  - `Task`: An awaitable task that completes when the current task can be added to the queue.

#### `CompleteTasks()`

Waits for all tasks in the queue to complete and returns their results as an array.

- **Returns**
  - `Task<T[]>`: An awaitable task that returns an array of results from the completed tasks.

## Usage

Here is a basic example of how to use the `TaskQueue<T>` class:

```csharp
var taskQueue = new TaskQueue<int>(maxQueueLength: 3);

for (int i = 0; i < 5; i++)
{
    var task = new Task<int>(() => i);
    await taskQueue.Add(task);
}

var results = await taskQueue.CompleteTasks();
```

In the example above, `TaskQueue<int>` is used with an integer result type, and the maximum queue length is set to 3. The tasks are added to the queue, and their results are retrieved and stored in an array after they complete.
```
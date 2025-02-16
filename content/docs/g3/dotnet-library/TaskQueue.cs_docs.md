# TaskQueue

The `TaskQueue` class provides a way to manage, limit and complete tasks in a controlled manner. It is a generic class that operates on items of type `T`.

```csharp
public class TaskQueue<T>
```

## Fields

- `_internalList` is used as a storage for queued tasks.
- `_maxQueueLength` is the maximum number of allowed tasks in the queue.

```csharp
private readonly List<Task<T>> _internalList;
private readonly int _maxQueueLength;
```

## Constructor

The `TaskQueue` constructor takes an int `maxQueueLength` as an input which sets the maximum number of tasks for the queue. It initializes `_internalList` as a new list of `Task<T>`.

```csharp
public TaskQueue(int maxQueueLength)
```

## Methods

### Add

This method adds a task to `_internalList`. If the number of unfinished tasks in the queue exceeds `_maxQueueLength`, the first unfinished task is completed before adding more tasks.

```csharp
public async Task Add(Task<T> task)
```

### CompleteTasks

This method completes all tasks in `_internalList`. The results are returned as an array of type `T` and `_internalList` is cleared.

```csharp
public async Task<T[]> CompleteTasks()
```
Overall, `TaskQueue` allows you to manage tasks in a queue, preventing the queue from becoming overloaded. The maximum length of the queue is set at instantiation, and the class ensures that this is never exceeded during operation.
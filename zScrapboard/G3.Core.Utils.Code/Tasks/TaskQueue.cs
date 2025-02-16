Sure, here are XML summary comments for the given code:

```CSharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.Tasks
{
    /// <summary>
    /// A class for creating and managing a task queue with a specified maximum length.
    /// </summary>
    /// <typeparam name="T">The type of the Tasks in the queue.</typeparam>
    public class TaskQueue<T>
    {
        private readonly List<Task<T>> _internalList;
        private readonly int _maxQueueLength;

        /// <summary>
        /// Initializes a new instance of the TaskQueue class.
        /// </summary>
        /// <param name="maxQueueLength">Maximum length of the task queue.</param>
        public TaskQueue(int maxQueueLength)
        {
            _maxQueueLength = maxQueueLength;
            _internalList = new List<Task<T>>();
        }

        /// <summary>
        /// Adds a new Task to the queue. 
        /// </summary>
        /// <param name="task">The Task to add.</param>
        /// <returns>A Task that represents the process of adding task into the queue.</returns>
        public async Task Add(Task<T> task)
        {
            _internalList.Add(task);

            var remaining = _internalList.Where(t => !t.IsCompleted).ToArray();
            if (remaining.Length > _maxQueueLength)
            {
                var qTask = remaining.FirstOrDefault();
                if (qTask != null) await qTask; //cause it to complete before adding more
            }
        }

        /// <summary>
        /// Waits for all the Tasks in the queue to complete and returns the results.
        /// </summary>
        /// <returns>An array of results from completed tasks.</returns>
        public async Task<T[]> CompleteTasks()
        {
            var result = await _internalList.Select(async t => await t)
                .ToAsyncEnumerable()
                .ToArrayAsync();

            _internalList.Clear();
            return await Task.WhenAll(result);
        }
    }
}
```
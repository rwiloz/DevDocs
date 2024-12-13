using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.Tasks
{
    public class TaskQueue<T>
    {
        private readonly List<Task<T>> _internalList;
        private readonly int _maxQueueLength;

        public TaskQueue(int maxQueueLength)
        {
            _maxQueueLength = maxQueueLength;
            _internalList = new List<Task<T>>();
        }

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

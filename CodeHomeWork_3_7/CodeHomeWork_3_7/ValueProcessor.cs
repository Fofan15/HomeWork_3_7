using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHomeWork_3_7
{

    public class ValuesProcessedEventArgs : EventArgs
    {
        public List<User> UniqueValues { get; set; }
        public List<User> FirstThreeValues { get; set; }
        public List<User> SortedValues { get; set; }
    }

    public class ValueProcessor
    {

        public event EventHandler<ValuesProcessedEventArgs> ValuesProcessed;

        public async Task ProcessValuesAsync(List<User> values)
        {
            var uniqueValuesTask = GetUniqueValuesAsync(values);
            var firstThreeValuesTask = GetFirstThreeValuesAsync(values);
            var sortedValuesTask = GetSortedValuesAsync(values);

            await Task.WhenAll(uniqueValuesTask, firstThreeValuesTask, sortedValuesTask);

            var e = new ValuesProcessedEventArgs
            {
                UniqueValues = await uniqueValuesTask,
                FirstThreeValues = await firstThreeValuesTask,
                SortedValues = await sortedValuesTask
            };

            ValuesProcessed?.Invoke(this, e);

        }

        static async Task<List<User>> GetUniqueValuesAsync(List<User> values)
        {
            await Task.Delay(3000);
            return values.Distinct().ToList();
        }

        static async Task<List<User>> GetFirstThreeValuesAsync(List<User> values)
        {
            await Task.Delay(3000);
            return values.Take(3).ToList();
        }

        static async Task<List<User>> GetSortedValuesAsync(List<User> values)
        {
            await Task.Delay(3000);
            return values.OrderBy(x => x.Id).ThenByDescending(x => x.Name).ToList();
        }
    }
}

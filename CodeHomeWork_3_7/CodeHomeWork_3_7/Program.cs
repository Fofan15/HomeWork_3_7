namespace CodeHomeWork_3_7
{


    internal class Program
    {
        static async Task Main(string[] args)
        {
            var values = new List<User>
        {
            new User { Name = "Andriy", Id = 1 },
            new User { Name = "Vanya", Id = 2 },
            new User { Name = "Svitlana", Id = 3 },
            new User { Name = "Dima", Id = 4 },
            new User { Name = "Egor", Id = 5 },
            new User { Name = "Sasha", Id = 6 },
            new User { Name = "Nastya", Id = 7 },
        };

            var processor = new ValueProcessor();

            processor.ValuesProcessed += (sender, e) =>
            {
                var result = e.UniqueValues.Concat(e.FirstThreeValues).Concat(e.SortedValues);

                Console.WriteLine("Result:");
                foreach (var value in result)
                {
                    Console.WriteLine($"{value.Name}: {value.Id}");
                }
            };

            await processor.ProcessValuesAsync(values);
        }
    }
}

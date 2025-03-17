using System.Text.Json;
using Domain.Entities;
using Domain.Logic.Interfaces;

namespace Domain.Logic
{
    public class ReadBeansFile : IReadBeansFile
    {
        public async Task<IEnumerable<Bean>> ReadBeansFileAsync()
        {
            string text = await File.ReadAllTextAsync("../Domain/Files/AllTheBeans_1.json");
            var beans = JsonSerializer.Deserialize<List<Bean>>(text);

            return beans;
        }
    }
}
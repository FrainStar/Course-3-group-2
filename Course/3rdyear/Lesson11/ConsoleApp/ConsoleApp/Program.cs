using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;


namespace ConsoleApp;



public class TaskItem
{
    public int Id { get; set; }
    public string Name { get; set; }

    public TaskItem(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

static class Program
{
    
    
    static async Task Main(string[] args)
    {
        TaskItem? task = await Func1();
        Console.WriteLine(task.Name);
        TaskItem? task2 = await Func2();
        Console.WriteLine(task2.Name);
    }


    static async Task<TaskItem> Func1()
    {
        
        using (var client = new HttpClient())
        {
            var url = $"http://localhost:5230/api/tasks";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Проверяем статус код ответа

            var result = await response.Content.ReadAsStringAsync();
            // Десериализация полученного JSON-объекта
            TaskItem? item = JsonConvert.DeserializeObject<TaskItem>(result);
            return item;
        }
    }

    static async Task<TaskItem> Func2()
    {
        using (var client = new HttpClient())
        {
            var url = $"http://localhost:5180/api/tasks";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Проверяем статус код ответа

            var result = await response.Content.ReadAsStringAsync();
            // Десериализация полученного JSON-объекта
            TaskItem? item = JsonConvert.DeserializeObject<TaskItem>(result);
            return item;
        }
    }
}
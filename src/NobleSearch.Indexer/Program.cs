using NobleSearch.Model;
using Redis.OM;
using System.Text.Json;

// Get the data from the File attached to the process
string jsonString = File.ReadAllText("Noble.json");
List<Person>? persons = JsonSerializer.Deserialize<List<Person>>(jsonString);

// Connect to the Redis(docker) which is running locally
var provider = new RedisConnectionProvider("redis://localhost:6379");
var connection = provider.Connection;

// Create a the index with the class(data) model created
connection.CreateIndex(typeof(Person));
var personCollection = provider.RedisCollection<Person>();

// Insert the data and the data will automatically get inserted into the database
List<Task> tasks = new List<Task>();
foreach (var item in persons)
{
    tasks.Add(personCollection.InsertAsync(item));
}

await Task.WhenAll(tasks);

Console.WriteLine("Indexed");




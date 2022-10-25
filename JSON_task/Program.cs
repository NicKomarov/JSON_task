
using System.Text.Json;

string path = @"D:\cyber_knu\degree2\oop\JSON_task\SerializeJsonExample.json";
using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
{
    var books = await JsonSerializer.DeserializeAsync<List<Book>>(fs);
    foreach (var book in books)
    {
        Console.WriteLine($"{book.PublishingHouseId} - {book.Title} - {book.PublishingHouse.Name}");
    }
}
Console.ReadKey();

class PublishingHouse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }

    public PublishingHouse(int id, string name, string adress)
    {
        Id = id;
        Name = name;
        Adress = adress;
    }
}

class Book
{
    //[JsonIgnore]
    public int PublishingHouseId { get; set; }

    //[JsonPropertyName ("Name")]
    public string Title { get; set; }
    public PublishingHouse PublishingHouse { get; set; }

    public Book(int publishingHouseId, string title, PublishingHouse publishingHouse)
    {
        PublishingHouseId = publishingHouseId;
        Title = title;
        PublishingHouse = publishingHouse;
    }
}
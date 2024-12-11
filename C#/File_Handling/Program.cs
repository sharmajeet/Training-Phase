using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

internal class File_Handling
{
    static void Main()
    {
        //json  serialization
        Purchase purchase = new Purchase
        {
        ProductName = "Asus Vivobook-17",
        DateTime = DateTime.UtcNow,
        productPrice = 50000,
        };

        string jsonString = JsonSerializer.Serialize(purchase);

        Console.WriteLine(jsonString);

        string path = "D:\\Training\\C#\\File_Handling\\sample.txt";

        // Write text to a file
        File.WriteAllText(path, "Hello, world!");

        // Read text from a file
        string content = File.ReadAllText(path);
        Console.WriteLine(content);

        // Append text to the file
        File.AppendAllText(path, "\nThis is an appended line.");

        // Read the updated content
        content = File.ReadAllText(path);
        Console.WriteLine(content);
    }

    public class Purchase
    {
        public string ProductName { get; set; }
        public DateTime DateTime { get; set; }

        public decimal productPrice { get; set; }   

    }

}

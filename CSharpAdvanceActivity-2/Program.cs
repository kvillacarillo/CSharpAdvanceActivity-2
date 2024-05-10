using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class NumberProcessor
{
    public void ProcessNumber(int number)
    {
        // Simulate time-consuming operation
        Random random = new Random();
        int sleepTime = random.Next(1000, 5000); // Random sleep time between 1 and 5 seconds
        Thread.Sleep(sleepTime);
        Console.WriteLine($"Processed number: {number}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Multi-threading

        NumberProcessor processor = new NumberProcessor();
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        foreach (int number in numbers)
        {
            // Create a new thread for each number
            Thread thread = new Thread(() => processor.ProcessNumber(number));
            thread.Start();
        }

        // LINQ

        List<Product> products = new List<Product>
        {
            new Product { Name = "Product 1", Price = 10.50 },
            new Product { Name = "Product 2", Price = 20.75 },
            new Product { Name = "Product 3", Price = 30.00 },
            new Product { Name = "Product 4", Price = 40.25 }
        };

        // Find all products with price greater than or equal to a specified value
        double specifiedPrice = 25.00;
        var selectedProducts = products.Where(p => p.Price >= specifiedPrice);

        // Select the names of all products and convert them to uppercase
        var upperCaseProductNames = selectedProducts.Select(p => p.Name.ToUpper());

        Console.WriteLine("\nProducts with price greater than or equal to $25.00:");
        foreach (var productName in upperCaseProductNames)
        {
            Console.WriteLine(productName);
        }

        // Events

        Downloader downloader = new Downloader();
        downloader.ProgressChanged += ProgressUpdateHandler;

        // Simulate download progress
        for (int i = 0; i <= 100; i += 10)
        {
            downloader.Progress = i;
            Thread.Sleep(1000); // Simulate download progress change
        }
    }

    static void ProgressUpdateHandler(int progress)
    {
        Console.WriteLine($"Download progress: {progress}%");
    }
}

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
}

class Downloader
{
    public int Progress { get; set; }
    public event ProgressUpdate ProgressChanged;
}

delegate void ProgressUpdate(int progress);

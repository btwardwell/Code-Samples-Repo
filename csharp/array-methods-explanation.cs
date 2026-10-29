// Reference documentation: https://learn.microsoft.com/en-us/dotnet/api/system.array?view=net-10.0

using System;
using System.Collections.Generic;
using System.IO;

public class ArrayMethods
{
    public static void Main()
    {
        // Array basics and common methods
        int[] numbers = { 5, 3, 8, 1, 9 };

        Console.WriteLine("Original numbers: " + string.Join(", ", numbers));

        Array.Sort(numbers);
        Console.WriteLine("Sorted numbers: " + string.Join(", ", numbers));

        Array.Reverse(numbers);
        Console.WriteLine("Reversed numbers: " + string.Join(", ", numbers));

        // Examples of searching and transforming arrays
        bool containsThree = Array.Exists(numbers, value => value == 3);
        Console.WriteLine("Contains 3? " + containsThree);

        // Dictionary example using file extensions
        string[] filePaths = { "document.txt", "image.png", "notes.txt", "archive.tar.gz" };
        Dictionary<string, FileAnalyzer> extensionMap = AnalyzeFileExtensions(filePaths);

        foreach (KeyValuePair<string, FileAnalyzer> entry in extensionMap)
        {
            Console.WriteLine($"Extension: {entry.Key} | Count: {entry.Value.Count}");
        }

        // Product example
        Product product = new Product("Laptop", 999.99m);
        Console.WriteLine($"Product: {product.Name} - {product.Price:C}");
    }

    public static Dictionary<string, FileAnalyzer> AnalyzeFileExtensions(string[] filePaths)
    {
        Dictionary<string, FileAnalyzer> extensionMap = new Dictionary<string, FileAnalyzer>(StringComparer.OrdinalIgnoreCase);

        foreach (string path in filePaths)
        {
            string extension = Path.GetExtension(path);

            if (extensionMap.ContainsKey(extension))
            {
                extensionMap[extension].Count++;
            }
            else
            {
                extensionMap[extension] = new FileAnalyzer
                {
                    Extension = extension,
                    Count = 1
                };
            }
        }

        return extensionMap;
    }
}

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public void MoveFileThroughDirectories(string sourceFilePath, string firstDirectory, string secondDirectory)
    {
        string fileName = Path.GetFileName(sourceFilePath);

        string firstDestination = Path.Combine(firstDirectory, fileName);
        File.Move(sourceFilePath, firstDestination);

        string secondDestination = Path.Combine(secondDirectory, fileName);
        File.Move(firstDestination, secondDestination);
    }
}

public class FileAnalyzer
{
    public string Extension { get; set; }
    public int Count { get; set; }
}
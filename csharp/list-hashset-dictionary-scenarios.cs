
using System.Collections.Generic;

public class ListHashSetDictionaryScenarios
{
    public static void Main()
    {
        // List example
        List<int> list = new List<int> { 1, 2, 3, 4, 5 };
        list.Add(6); // Add an element
        list.RemoveAt(0); // Remove element at index 0
        bool contains = list.Contains(3); // Check if element exists

        // HashSet example
        HashSet<int> hashSet = new HashSet<int> { 1, 2, 3, 4, 5 };
        hashSet.Add(6); // Add an element
        hashSet.Remove(1); // Remove element
        bool hasElement = hashSet.Contains(3); // Check if element exists

        // Dictionary example
        Dictionary<string, int> dictionary = new Dictionary<string, int>
        {
            { "Alice", 25 },
            { "Bob", 30 },
            { "Charlie", 35 }
        };
        dictionary["David"] = 40; // Add or update an element
        int age = dictionary["Alice"]; // Get an element
        bool hasKey = dictionary.ContainsKey("Bob"); // Check if key exists

        // Dictionary counter example
        var counts = new Dictionary<char, int>();
        foreach (char c in str) 
        {
            // Modern C# shorthand for updating or initializing
            counts[c] = counts.GetValueOrDefault(c, 0) + 1;
        }

        // Fast lookup with HashSet
        var set = new HashSet<int> { 1, 2, 3, 4, 5 };
        bool exists = set.Contains(3); // O(1) average time complexity for lookup   
        // Set initialization from Collection
        var set = new HashSet<int>(list); // Initialize a HashSet from a List

        // Pre-allocating capacity for performance, avoids expensive internal resizing
        var largeList = new List<int>(1000); // Pre-allocate space for 1000 elements    
    }

    public static void HashSets()
    {
        // add simple HashSet example for converting, removing, convertal, findindex and getrange
        HashSet<int> set = new HashSet<int>(nums);
        int[] uniqueViaSet = set.ToArray(); // Convert HashSet to array

        // Remove duplicates from a list using HashSet
        List<int> listWithDuplicates = new List<int> { 1, 2, 2, 3, 3, 4 };
        HashSet<int> uniqueSet = new HashSet<int>(listWithDuplicates); // Remove duplicates
        List<int> uniqueList = uniqueSet.ToList(); // Convert back to List

        // FindIndex equivalent for HashSet (not directly supported, but can be done via LINQ)
        int index = listWithDuplicates.FindIndex(x => x == 3); // Find index

        // GetRange equivalent for HashSet (not directly supported, but can be done via LINQ)
        List<int> rangeList = listWithDuplicates.GetRange(1, 3); // Get a range of elements from a List
        // Note: HashSet does not maintain order, so GetRange is not applicable directly to HashSet

        // Example of using HashSet for fast lookups
        var set = new HashSet<int> { 1, 2, 3, 4, 5 };
        bool exists = set.Contains(3); // O(1) average time complexity for lookup

        // Set initialization from Collection
        var setFromList = new HashSet<int>(listWithDuplicates); // Initialize a HashSet from a List

        // Pre-allocating capacity for performance, avoids expensive internal resizing 
        var largeList = new HashSet<int>(1000); // Pre-allocate space for 1000 elements     
        
    }

    public static void DictionaryScenarios()
    {
        // Dictionary example
        Dictionary<string, int> dictionary = new Dictionary<string, int>
        {
            { "Alice", 25 },
            { "Bob", 30 },
            { "Charlie", 35 }
        };

        // Add or update an element
        dictionary["David"] = 40; // Add or update an element   

        // Get an element
        int age = dictionary["Alice"]; // Get an element

        // Check if key exists
        bool hasKey = dictionary.ContainsKey("Bob"); // Check if key exists

        // Dictionary counter example
        var counts = new Dictionary<char, int>();
        foreach (char c in str)
        {
            // Modern C# shorthand for updating or initializing
            counts[c] = counts.GetValueOrDefault(c, 0) + 1;
        }

        // Fast lookup with Dictionary
        var dict = new Dictionary<string, int>
        {
            { "Alice", 25 },
            { "Bob", 30 },
            { "Charlie", 35 }
        };  

        // O(1) average time complexity for lookup
        bool exists = dict.ContainsKey("Bob"); // Check if key exists
        // Pre-allocating capacity for performance, avoids expensive internal resizing
        var largeDict = new Dictionary<string, int>(1000); // Pre-allocate space for 1000 elements
    }
}
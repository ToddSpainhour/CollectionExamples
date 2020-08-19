using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;  // must import this to use LINQ
using System.Text.Json.Serialization;
//using JsonSerializerOptions;

namespace CollectionExamples.LinqStuff
{
    class Example
    {
        public void Run()
        {

            var animals = new List<string> { "Dog", "Cat", "Goat", "Elephant" };

            Console.WriteLine(string.Join(",", animals));

            // map method doesn't exist in C#, instead use Select(), used for transformation
            var realAnimals = animals.Select(animal => new Animal { Name = animal, Color = "Brown" });

            var jsonAnimals = System.Text.Json.JsonSerializer.Serialize(realAnimals, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });

            Console.WriteLine(jsonAnimals);


            // the Where() method is similar to javascript's filter()
            var filteredAnimals = realAnimals.Where(animal => animal.Name.Contains('a'));

           // because each linq method returns a collection, they are able to be chained
            var chainedResults = animals
                .Select(animal => new Animal { Name = animal, Color = "Brown" })
                .Where(animal => animal.Name.Contains('a'));

            // Where() looks through whole collection...
            var anyAnimalsWithAJ = animals.Where(animal => animal.Contains('j')).Count() > 0;

            // Contains() stops when one is found; more efficient; "is there ay match at all"
            var anyAnimalsWithAF = animals.Any(animal => animal.Contains('f'));

            // First() returns the first one it finds that matches; will throw an exception if collection doesn't contain it
            var firstAnimalWithA = realAnimals.First(animal => animal.Name.Contains('a'));

            // FirstOrDefault returns the first items that matches, or default value of the collection type if no match
            var firstAnimalWithAZ = realAnimals.FirstOrDefault(animal => animal.Name.Contains('z'));

            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 6, 3 };

            var biggestNumber = numbers.Max();

            var animalWithTheLongestName = realAnimals.Max(animal => animal.Name.Length);


            // Distinct removes duplicates
            var uniqueNumbers = numbers.Distinct();


            // ordering numbers list in accending order
            var orderedNumbers = numbers.OrderBy(number => number);


            // order alphabetically 
            var orderAnimals = realAnimals.OrderBy(animal => animal.Name);


            // immediately runs this code instead of waiting for someone to call it
            var orderAnimalsToAList = realAnimals.OrderBy(animal => animal.Name).ToList();

            // the genaric term for 'linq' is called 'list comprehension' 


            var animalsToGroup = new List<Animal>
            {
                new Animal {Name = "Steve", Color = "blue", Type = "bird"},
                new Animal {Name = "Jimbo", Color = "green", Type = "bee"},
                new Animal {Name = "Tim", Color = "yellow", Type = "bear"},
                new Animal {Name = "Cindy", Color = "blue", Type = "bird"}

            };

            //spits out a list of key value pairs
            var groupedAnimals = animalsToGroup.GroupBy(animal => animal.Type);

            foreach (var group in groupedAnimals)
            {
                Console.WriteLine($"Animal type is {group.Key}");

                foreach (var animal in group)
                {
                    Console.WriteLine($"{animal.Name} is a {animal.Color} {animal.Type}");
                }
            }



            /*
            Console.WriteLine($"anyAnimalsWithAJ: {anyAnimalsWithAJ}");
            Console.WriteLine($"anyAnimalsWithAF: {anyAnimalsWithAF}");
            Console.WriteLine($"firstAnimalWithA: {firstAnimalWithA}");
            Console.WriteLine($"firstAnimalWithAZ: {firstAnimalWithAZ}");
            Console.WriteLine($"biggestNumber: {biggestNumber}");
            Console.WriteLine($"uniqueNumbers: {uniqueNumbers}");
            */



        }


    }
}

using System;
using System.Collections.Generic; // most collections will be found here
using System.Runtime.InteropServices;
using System.Security;

namespace CollectionExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Collections!");


            // list are general purpose collection that is pretty good at everything. "The world's most OK collection."

            var instructors = new List<string>();   // set a variable called 'name' which is a new list of type string
            var students = new List<string>();      // set a variable called 'students' which is a new list of type string
            var numbers = new List<int>();          // set a variable called 'numbers' which is a new list of type int
            var evening11 = new List<string>();     // set a variable called 'evening11' which is a new list of type string


            instructors.Add("Nathan");
            instructors.Add("Dylan");
            instructors.Add("Jemeka");

            students.Add("Monique");
            students.Add("Anca");
            students.Add("Joey");

            numbers.Add(39);
            numbers.Add(38);
            numbers.Add(8);

            // AddRange add one list to another to make a new one
            evening11.AddRange(students);
            evening11.AddRange(instructors);


            foreach (string individual in evening11)
            {
                Console.WriteLine($"{individual} is also a part of Evening 11.");
            }


            // is this item in a list?
            var isToddInTheList = evening11.Contains("Todd");

            // ternary inside interpolated strings have to be in parenthases 
            Console.WriteLine($"Todd is {(isToddInTheList ? "in this list." : "is not in this list.")}");

            // Find only gets first match
            var matchingPerson = evening11.Find(person => person.StartsWith("M"));

            Console.WriteLine($"{matchingPerson} is the first string in this list that starts with 'M'");


            // in a list the index number is the key
            Console.WriteLine($"{students[1]} is the student at the index of 1.");


            //--------------------------------------------------------------

            // dictionaries have 2 genaric type parameters; pairs of keys and values; every single key must be unique; one key can hold any values 
            // optimised to find one thing at a time
            // declaring a variable that is a dictionary of string string... or string keys and string values
            // use when you are reading more than writing

            var words = new Dictionary<string,string>();

            // add an item to my dictionary that has the key 'pedantic' and a value that goes with it which is 'Like a pedant'
            words.Add("pedantic", "Like a pedant");
            words.Add("congratulate", "to be excited for; celebrate");
            words.Add("scrupulous", "thouough, extremely attentive to details");
            // words.Add("congratulate", "not a real thing");  // this gves errors


            // what if they try to add the same word? validate uniquess so you don't get an exception
            if (words.ContainsKey("congratulate"))
            {
                words["congratulate"] = "asfakfak";
            }
            else
            {
                words.Add("congratulate", "asfakfak");
            }

            // same as above but different syntax; add a key value os possible
            if (!words.TryAdd("congratulate", "asfakfak"))
            {
                words["congratulate"] = "asfakfak";
            }




            Console.WriteLine($"The fake definition of Congratulations is {words["congratulate"]}");


            foreach (var entry in words)
            {
                Console.WriteLine($"The definition of {entry.Key} is {entry.Value}");
            }


            // setting an existing key to a new value
            words["congratulate"] = "stuff";



            // destructuring 
            foreach (var (word, definition) in words)
            {
                Console.WriteLine($"The definition of {word} is {definition}");
            }


            // value of the dictionary is a list of strings
            var wordsWithMultipleDefinitions = new Dictionary<string, List<string>>();


            // collection initializer
            wordsWithMultipleDefinitions.Add("scrupulous", new List<string>()
            {
                "Diligent",
                "Thorough",
                "Extremely attentive to detail"
            });   
        
        foreach (var(word, definitions) in wordsWithMultipleDefinitions)
            {
                Console.WriteLine($"{word} is defined as : ");
                    foreach (var definition in definitions)
                    {
                        Console.WriteLine($" {definition}");
                    }
            }


            

            var queue = new Queue<string>();

            queue.Enqueue("first");
            queue.Enqueue("second");
            queue.Enqueue("third");


            ///FIFO - first in first out
            
            foreach (var item in queue)
            {
                Console.WriteLine($"Enqueue: {item}");
            }

        
        
        
        
        }
    }
}

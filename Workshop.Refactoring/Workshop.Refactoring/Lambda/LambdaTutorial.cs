using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Refactoring;

namespace Workshop.Refactoring.Lambda
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class LambdaTutorial
    {
        public static void Tutorial()
        {
            var list = new List<Person>()
            {
                new Person() {Name = "Maryam", Age = 28 },
                new Person() {Name = "Mehran", Age = 31 },
                new Person() {Name = null, Age = 25},
                new Person() {Name = "Mina" , Age = 64},
            };

            List<Person> validList;


            // Method 1. Using a loop
            validList = new List<Person>();
            foreach (var person in list)
            {
                if (!string.IsNullOrWhiteSpace(person.Name))
                    validList.Add(person);
            }


            // Method 2. Using a loop with predefined method
            validList = new List<Person>();
            foreach (var person in list)
            {
                if (IsValid(person))
                    validList.Add(person);
            }


            // Method 3. Using a loop, declaring method in a variable
            Func<Person, bool> validationFunc =
                (Person person) =>
                {
                    return !string.IsNullOrWhiteSpace(person.Name);
                };

            validList = new List<Person>();
            foreach (var person in list)
            {
                if (validationFunc(person))
                    validList.Add(person);
            }


            // Method 4. Using Where
            var validListQuery = list.Where(p => !string.IsNullOrWhiteSpace(p.Name));
            validList = validListQuery.ToList();

            // Method 4. Using Where with predefined method
            validListQuery = list.Where(p => IsValid(p));
            validList = validListQuery.ToList();
        }


        static bool IsValid(Person person)
        {
            return !string.IsNullOrWhiteSpace(person.Name);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson38
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person(1,"Aram", "Sargsyan", 25);
            Person person2 = new Person(2, "Vazgen", "Virabyan", 30);
            Person person3 = new Person(3, "Lilit", "Babayan", 16);
            Person person4 = new Person(4, "Anna", "Azatyan", 28);
            Person person5 = new Person(5, "Vazgen", "Gevorgyan", 33);

            List<Person> people = Filter<Person>((x=>x.Age>24),new List<Person>() 
            { 
                person1,
                person2,
                person3,
                person4,
                person5
            });
            Console.WriteLine("\n Filtered List:");
            foreach (var el in people) 
            {
                Console.WriteLine($"{el.Id} | {el.Name} | {el.SurName} | {el.Age}");
            }

            List<Person> sortedList = Sort<Person>((x, y) => y.Age.CompareTo(x.Age), people);
            Console.WriteLine("\n Sorted List:");
            foreach (var el in sortedList)
            {
                Console.WriteLine($"{el.Id} | {el.Name} | {el.SurName} | {el.Age}");
            }

        }
        public static List<T> Filter<T>(Predicate<T> condition, List<T> list)
        {
            List<T> result = new List<T>();
            foreach (var el in list) 
            {
                if (condition.Invoke(el))
                {
                    result.Add(el);
                }
            }
            return result;
        }

        public static List<T> Sort<T>(Comparison<T> comparison, List<T> list)
        {
            List<T> sortedList = new List<T>(list);
            sortedList.Sort(comparison);
            return sortedList;
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }

        public Person(int id, string name, string surname, int age) 
        {
            Id = id;
            Name = name;
            SurName = surname;
            Age = age;
        }

        public Person()
        {
        }
    }

    public class PersonManagment
    {
        List<Person> persons = new List<Person>();
        public void AddPerson(Person person)
        {
            persons.Add(person);
        }
        public void RemovePerson(Person person)
        {
            persons.Remove(person);
        }
    }
}

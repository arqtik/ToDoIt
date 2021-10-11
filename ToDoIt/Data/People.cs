using System;
using System.Collections.Generic;
using System.Linq;
using ToDoIt.Model;

namespace ToDoIt.Data
{
    public class People
    {
        private static Person[] Persons = new Person[0];

        /// <summary>
        /// Get the size of the persons array
        /// </summary>
        /// <returns>Lenght of the persons array</returns>
        public int Size()
        {
            return Persons.Length;
        }

        /// <summary>
        /// Get an array of all the people objects
        /// </summary>
        /// <returns>Array containing all Person objects</returns>
        public Person[] FindAll()
        {
            return Persons;
        }
        
        /// <summary>
        /// Find person based on it's Id
        /// </summary>
        /// <param name="personId">Id to find person by</param>
        /// <returns>Returns first found person with that Id</returns>
        public Person FindById(int personId)
        {
            Person person = null;
            try
            {
                person = Persons.First(p => p.PersonId == personId);
            }
            catch (InvalidOperationException)
            {
                return null;
            }

            return person;
        }

        /// <summary>
        /// Create a new Person object and add it to an array of Person objects
        /// </summary>
        /// <param name="firstName">First name of the person</param>
        /// <param name="lastName">Last name of the person</param>
        /// <returns>Returns the person created</returns>
        public Person CreatePerson(string firstName, string lastName)
        {
            Array.Resize(ref Persons, Persons.Length + 1);
            Person person = new Person(firstName, lastName, PersonSequencer.nextPersonId());
            Persons[^1] = person;
            return person;
        }

        /// <summary>
        /// Removes all Person objects from array
        /// </summary>
        public void Clear()
        {
            Array.Resize(ref Persons, 0);
        }
        
        /// <summary>
        /// Remove a person from the array of persons
        /// </summary>
        /// <param name="personToRemove">The person that should be remove from the array</param>
        public void RemovePerson(Person personToRemove)
        {
            Persons = Persons.Where(todo => !todo.Equals(personToRemove)).ToArray();
        }
    }
}
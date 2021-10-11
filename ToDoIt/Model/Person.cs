using System;

namespace ToDoIt.Model
{
    public class Person
    {
        private readonly int personId;
        private string firstName;
        private string lastName;

        /// <summary>
        /// Set or get the first name of this person
        /// </summary>
        /// <exception cref="ArgumentException">Throws exception if value is null or empty</exception>
        public string FirstName
        {
            get => firstName;
            private set
            {
                if (value == null || value.Equals(String.Empty))
                {
                    throw new ArgumentException("Value can not be empty or null");
                }

                firstName = value;
            }
        }

        /// <summary>
        /// Set or get the last name of this person
        /// </summary>
        /// <exception cref="ArgumentException">Throws exception if value is null or empty</exception>
        public string LastName
        {
            get => lastName;
            private set
            {
                if (value == null || value.Equals(String.Empty))
                {
                    throw new ArgumentException("Value can not be empty or null");
                }

                lastName = value;
            }
        }

        /// <summary>
        /// Create a new instance of person
        /// </summary>
        /// <param name="firstName">First name of person</param>
        /// <param name="lastName">Last name of person</param>
        /// <param name="personId">ID that this person should have</param>
        public Person(string firstName, string lastName, int personId)
        {
            FirstName = firstName;
            LastName = lastName;
            this.personId = personId;
        }
    }
}
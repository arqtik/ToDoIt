using System;
using ToDoIt.Data;
using ToDoIt.Model;
using Xunit;

namespace ToDoIt.Tests
{
    public class PeopleTests
    {
        [Fact]
        private void SizeClearTest()
        {
            People people = new People();

            // We clear as to make sure other tests did not impact the static variable Persons
            people.Clear();
            Assert.Equal(0, people.Size());

            people.CreatePerson("Billy", "Jones");
            
            Assert.Equal(1, people.Size());
        }

        [Fact]
        private void CreatePersonTest()
        {
            People people = new People();
            
            // We clear as to make sure other tests did not impact the static variable Persons
            people.Clear();
            
            Assert.Equal(0, people.Size());
            
            people.CreatePerson("Henry", "George");
            Assert.Equal(1, people.Size());

            string nameOfLastPersonInArray = people.FindAll()[people.Size() - 1].FirstName;
            
            Assert.Equal("Henry", nameOfLastPersonInArray);
            
        }

        [Fact]
        private void FindAllTest()
        {
            People people = new People();
            
            // We clear as to make sure other tests did not impact the static variable Persons
            people.Clear();

            Person[] personsExpected = new Person[2];

            for (int i = 0; i < personsExpected.Length; i++)
            {
                personsExpected[i] = people.CreatePerson("Bob", "Henderson");
            }

            Person[] personsActual = people.FindAll();
            
            for (int i = 0; i < personsExpected.Length; i++)
            {
                Assert.Equal(personsExpected[i], personsActual[i]);
            }
        }

        [Fact]
        private void FindByIdTest()
        {
            People people = new People();
            Person personExpected = people.CreatePerson("Lukas", "Minsk");
            Person personActual = people.FindById(personExpected.PersonId);

            Assert.Equal(personExpected, personActual);
        }
        
        [Fact]
        private void FindByIdExceptionTest()
        {
            People people = new People();
            
            // Clear to make sure it's empty from other tests
            people.Clear();
            Person personActual = people.FindById(45643);

            Assert.Null(personActual);
        }
    }
}
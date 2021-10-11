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
            
            Person expectedPerson = people.CreatePerson("Henry", "George");
            Person actualPerson = people.FindAll()[people.Size() - 1];
            
            Assert.Equal(1, people.Size());
            Assert.Equal(expectedPerson, actualPerson);
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
            
            // We clear as to make sure other tests did not impact the static variable Persons
            people.Clear();
            Person personActual = people.FindById(9999);

            Assert.Null(personActual);
        }
    }
}
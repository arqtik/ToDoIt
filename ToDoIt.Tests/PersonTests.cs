using System;
using ToDoIt.Model;
using Xunit;

namespace ToDoIt.Tests
{
    public class PersonTests
    {
        [Fact]
        private void Constructor()
        {
            // Expected names
            string exFirstName = "Billy";
            string exLastName = "Johnson";
            int personId = 42;

            Person person = new Person(exFirstName, exLastName, personId);
            
            Assert.Equal(exFirstName, person.FirstName);
            Assert.Equal(exLastName, person.LastName);
        }

        [Theory]
        [InlineData("Billy", "")]
        [InlineData("", "Johnson")]
        [InlineData("Billy", null)]
        [InlineData(null, "Johnson")]
        private void NullEmptyConstructor(string firstName, string lastName)
        {
            int personId = 42;

            ArgumentException e = Assert.Throws<ArgumentException>(() => new Person(firstName, lastName, personId));
            Assert.Equal("Value can not be empty or null", e.Message);
        }
    }
}
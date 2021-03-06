using ToDoIt.Model;
using Xunit;

namespace ToDoIt.Tests
{
    public class ToDoTests
    {
        [Fact]
        private void ToDoTest()
        {
            Person person = new Person("Billy", "Johnson", 42);
            Todo toDo = new Todo(1, "Test Desc")
            {
                Assignee = person,
                Done = true
            };

            Assert.Equal(person, toDo.Assignee);
            Assert.True(toDo.Done);
        }
    }
}
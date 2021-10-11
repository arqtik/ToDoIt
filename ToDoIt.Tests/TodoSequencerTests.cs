using ToDoIt.Data;
using Xunit;

namespace ToDoIt.Tests
{
    public class TodoSequencerTests
    {
        [Fact]
        private void nextTodoIdTest()
        {
            int firstId = TodoSequencer.nextTodoId();
            int secondId = TodoSequencer.nextTodoId();
            
            Assert.Equal(firstId + 1, secondId);
        }
        
        [Fact]
        private void resetTest()
        {
            for (int i = 0; i < 10; i++)
            {
                TodoSequencer.nextTodoId();
            }
            
            TodoSequencer.reset();

            int expected = 1;
            int actual = TodoSequencer.nextTodoId();
            
            Assert.Equal(expected, actual);
        }
    }
}
using ToDoIt.Data;
using Xunit;

namespace ToDoIt.Tests
{
    public class PersonSequencerTests
    {
        [Fact]
        private void nextPersonIdTest()
        {
            int firstId = PersonSequencer.nextPersonId();
            int secondId = PersonSequencer.nextPersonId();
            
            Assert.Equal(firstId + 1, secondId);
        }

        [Fact]
        private void resetTest()
        {
            for (int i = 0; i < 10; i++)
            {
                PersonSequencer.nextPersonId();
            }
            
            PersonSequencer.reset();

            int expected = 1;
            int actual = PersonSequencer.nextPersonId();
            
            Assert.Equal(expected, actual);
        }
    }
}
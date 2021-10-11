using ToDoIt.Data;
using ToDoIt.Model;
using Xunit;

namespace ToDoIt.Tests
{
    public class TodoItemsTests
    {
        [Fact]
        private void SizeClearTest()
        {
            TodoItems todoItems = new TodoItems();

            // We clear as to make sure other tests did not impact the static variable Persons
            todoItems.Clear();
            Assert.Equal(0, todoItems.Size());

            todoItems.CreateTodo("Test Description");
            
            Assert.Equal(1, todoItems.Size());
        }

        [Fact]
        private void CreateTodoTest()
        {
            TodoItems todoItems = new TodoItems();
            
            // We clear as to make sure other tests did not impact the static variable Persons
            todoItems.Clear();
            
            Todo expectedTodo = todoItems.CreateTodo("Test Description");
            Todo actualTodo = todoItems.FindAll()[todoItems.Size() - 1];
            
            Assert.Equal(1, todoItems.Size());
            Assert.Equal(expectedTodo, actualTodo);
        }

        [Fact]
        private void FindAllTest()
        {
            TodoItems todoItems = new TodoItems();
            
            // We clear as to make sure other tests did not impact the static variable Persons
            todoItems.Clear();

            Todo[] todosExpected = new Todo[2];

            for (int i = 0; i < todosExpected.Length; i++)
            {
                todosExpected[i] = todoItems.CreateTodo("Test Description");
            }

            Todo[] todosActual = todoItems.FindAll();
            
            for (int i = 0; i < todosExpected.Length; i++)
            {
                Assert.Equal(todosExpected[i], todosActual[i]);
            }
        }

        [Fact]
        private void FindByIdTest()
        {
            TodoItems todoItems = new TodoItems();
            Todo todoExpected = todoItems.CreateTodo("Test Description");
            Todo todoActual = todoItems.FindById(todoExpected.TodoId);

            Assert.Equal(todoExpected, todoActual);
        }
        
        [Fact]
        private void FindByIdExceptionTest()
        {
            TodoItems todoItems = new TodoItems();
            
            // We clear as to make sure other tests did not impact the static variable Persons
            todoItems.Clear();
            Todo todoActual = todoItems.FindById(9999);

            Assert.Null(todoActual);
        }
    }
}
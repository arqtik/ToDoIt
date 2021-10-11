using System.Linq;
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

            // We clear as to make sure other tests did not impact the static variable Todos
            todoItems.Clear();
            Assert.Equal(0, todoItems.Size());

            todoItems.CreateTodo("Test Description");
            
            Assert.Equal(1, todoItems.Size());
        }

        [Fact]
        private void CreateTodoTest()
        {
            TodoItems todoItems = new TodoItems();
            
            // We clear as to make sure other tests did not impact the static variable Todos
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
            
            // We clear as to make sure other tests did not impact the static variable Todos
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
            
            // We clear as to make sure other tests did not impact the static variable Todos
            todoItems.Clear();
            Todo todoActual = todoItems.FindById(9999);

            Assert.Null(todoActual);
        }

        [Fact]
        private void FindByDoneStatusTest()
        {
            TodoItems todoItems = new TodoItems();
            // We clear as to make sure other tests did not impact the static variable Todos
            todoItems.Clear();
            
            Todo[] refTodos = new Todo[5];

            for (int i = 0; i < refTodos.Length; i++)
            {
                refTodos[i] = todoItems.CreateTodo("Test");
            }
            
            refTodos[^1].Done = true;
            refTodos[^2].Done = true;

            Todo[] doneTodos = todoItems.FindByDoneStatus(true);
            Assert.Equal(2, doneTodos.Length);
            Assert.True(doneTodos[0].Done);
            Assert.True(doneTodos[1].Done);
        }

        [Fact]
        private void FindByAssigneeIdTest()
        {
            TodoItems todoItems = new TodoItems();
            // We clear as to make sure other tests did not impact the static variable Todos
            todoItems.Clear();
            
            Todo[] refTodos = new Todo[5];

            for (int i = 0; i < refTodos.Length; i++)
            {
                refTodos[i] = todoItems.CreateTodo("Test");
            }

            Person p = new Person("Billy", "Rec", 42);
            
            refTodos[^1].Assignee = p;
            refTodos[^2].Assignee = p;

            Todo[] foundTodos = todoItems.FindByAssignee(p.PersonId);
            Assert.Equal(2, foundTodos.Length);
            Assert.Equal(foundTodos[0].Assignee.PersonId, p.PersonId);
            Assert.Equal(foundTodos[1].Assignee.PersonId, p.PersonId);
        }

        [Fact]
        private void FindByAssigneePersonTest()
        {
            TodoItems todoItems = new TodoItems();
            // We clear as to make sure other tests did not impact the static variable Todos
            todoItems.Clear();
            
            Todo[] refTodos = new Todo[5];

            for (int i = 0; i < refTodos.Length; i++)
            {
                refTodos[i] = todoItems.CreateTodo("Test");
            }

            Person p = new Person("Billy", "Rec", 42);
            
            refTodos[^1].Assignee = p;
            refTodos[^2].Assignee = p;

            Todo[] foundTodos = todoItems.FindByAssignee(p);
            Assert.Equal(2, foundTodos.Length);
            Assert.Equal(foundTodos[0].Assignee, p);
            Assert.Equal(foundTodos[1].Assignee, p);
        }

        [Fact]
        private void FindUnassignedTodoItems()
        {
            TodoItems todoItems = new TodoItems();
            // We clear as to make sure other tests did not impact the static variable Todos
            todoItems.Clear();
            
            Todo[] refTodos = new Todo[5];

            for (int i = 0; i < refTodos.Length; i++)
            {
                refTodos[i] = todoItems.CreateTodo("Test");
            }

            Person p = new Person("Billy", "Rec", 42);
            
            refTodos[^1].Assignee = p;
            refTodos[^2].Assignee = p;

            Todo[] foundTodos = todoItems.FindUnassignedTodoItems();
            Assert.Equal(3, foundTodos.Length);
            foreach (Todo todo in foundTodos)
            {
                Assert.Null(todo.Assignee);
            }
        }
        
        [Fact]
        private void RemoveTodoTest()
        {
            TodoItems todoItems = new TodoItems();
            // We clear as to make sure other tests did not impact the static variable Todos
            todoItems.Clear();
            
            Todo[] refTodos = new Todo[5];

            for (int i = 0; i < refTodos.Length; i++)
            {
                refTodos[i] = todoItems.CreateTodo("Test");
            }

            todoItems.RemoveTodo(refTodos[2]);
            
            Todo[] todosAfterRemove = todoItems.FindAll();

            foreach (Todo todo in todosAfterRemove)
            {
                Assert.Contains(todo, refTodos);
            }

            Assert.DoesNotContain(refTodos[2], todosAfterRemove);
        }
    }
}
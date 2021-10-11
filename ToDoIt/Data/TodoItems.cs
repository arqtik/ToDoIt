using System;
using System.Linq;
using ToDoIt.Model;

namespace ToDoIt.Data
{
    public class TodoItems
    {
        private static Todo[] Todos = new Todo[0];
        
        /// <summary>
        /// Get the size of the Todos array
        /// </summary>
        /// <returns>Lenght of the Todos array</returns>
        public int Size()
        {
            return Todos.Length;
        }
        
        /// <summary>
        /// Get an array of all the To-do objects
        /// </summary>
        /// <returns>Array containing all To-do objects</returns>
        public Todo[] FindAll()
        {
            return Todos;
        }
        
        /// <summary>
        /// Find to-do based on it's Id
        /// </summary>
        /// <param name="todoId">Id to find the to-do by</param>
        /// <returns>Returns first to-do found with that Id</returns>
        public Todo FindById(int todoId)
        {
            Todo todo = null;
            try
            {
                todo = Todos.First(t => t.TodoId == todoId);
            }
            catch (InvalidOperationException)
            {
                return null;
            }

            return todo;
        }
        
        /// <summary>
        /// Create a new To-do object and add it to an array of To-do objects
        /// </summary>
        /// <param name="description">Description that this to-do should have</param>
        /// <returns>Returns the to-do instance created</returns>
        public Todo CreateTodo(string description)
        {
            Array.Resize(ref Todos, Todos.Length + 1);
            Todo todo = new Todo(TodoSequencer.nextTodoId(), description);
            Todos[^1] = todo;
            return todo;
        }
        
        /// <summary>
        /// Removes all To-do objects from array
        /// </summary>
        public void Clear()
        {
            Array.Resize(ref Todos, 0);
        }
    }
}
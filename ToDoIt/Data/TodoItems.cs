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

        /// <summary>
        /// Get all todos based on doneStatus parameter
        /// </summary>
        /// <param name="doneStatus">Find todos with this status</param>
        /// <returns>Returns an array of all Todos that match the status</returns>
        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            return Todos.Where(todo => todo.Done == doneStatus).ToArray();
        }

        /// <summary>
        /// Get all todos based on the personId of the assignee
        /// </summary>
        /// <param name="personId">PersonId of the assignee</param>
        /// <returns>Returns an array of all the Todos that match the personId of the assignee</returns>
        public Todo[] FindByAssignee(int personId)
        {
            return Todos.Where(todo => todo.Assignee?.PersonId == personId).ToArray();
        }

        /// <summary>
        /// Get all todos based on the assignee person instance
        /// </summary>
        /// <param name="assignee">The assignee of the todos</param>
        /// <returns>Returns an array of all the Todos that match the assignee</returns>
        public Todo[] FindByAssignee(Person assignee)
        {
            return Todos.Where(todo => todo.Assignee != null && todo.Assignee.Equals(assignee)).ToArray();
        }

        /// <summary>
        /// Get all todos that don't have an assignee set
        /// </summary>
        /// <returns>Returns an array of all the Todos without an assignee</returns>
        public Todo[] FindUnassignedTodoItems()
        {
            return Todos.Where(todo => todo.Assignee == null).ToArray();
        }

        /// <summary>
        /// Removes a to-do from the array
        /// </summary>
        /// <param name="todoToRemove">The to-do to remove from the array of Todos</param>
        public void RemoveTodo(Todo todoToRemove)
        {
            Todos = Todos.Where(todo => !todo.Equals(todoToRemove)).ToArray();
        }
    }
}
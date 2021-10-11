namespace ToDoIt.Data
{
    public class TodoSequencer
    {
        private static int todoId;

        /// <summary>
        /// Get the id for next to-do
        /// </summary>
        /// <returns>ID for the to-do</returns>
        public static int nextTodoId()
        {
            todoId++;
            return todoId;
        }

        /// <summary>
        /// Resets the todoId counter to 0
        /// </summary>
        public static void reset()
        {
            todoId = 0;
        }
    }
}
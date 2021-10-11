namespace ToDoIt.Model
{
    public class Todo
    {
        private string description;
        
        /// <summary>
        /// The ID of this to-do instance
        /// </summary>
        public int TodoId { get; }

        /// <summary>
        /// If the To-Do is done or not
        /// </summary>
        public bool Done { get; set; }

        /// <summary>
        /// Assignee person of this To-Do
        /// </summary>
        public Person Assignee { get; set; }

        public Todo(int todoId, string description)
        {
            TodoId = todoId;
            this.description = description;
        }
    }
}
namespace ToDoIt.Model
{
    public class ToDo
    {
        private readonly int todoId;
        private string description;
        private bool done;
        private Person assignee;

        public ToDo(int todoId, string description)
        {
            this.todoId = todoId;
            this.description = description;
        }
    }
}
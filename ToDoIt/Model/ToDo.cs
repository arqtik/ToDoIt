﻿namespace ToDoIt.Model
{
    public class ToDo
    {
        private readonly int todoId;
        private string description;

        /// <summary>
        /// If the To-Do is done or not
        /// </summary>
        public bool Done { get; set; }

        /// <summary>
        /// Assignee person of this To-Do
        /// </summary>
        public Person Assignee { get; set; }

        public ToDo(int todoId, string description)
        {
            this.todoId = todoId;
            this.description = description;
        }
    }
}
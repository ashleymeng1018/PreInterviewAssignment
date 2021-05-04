using DataStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BackendAPI.Interfaces
{
    public interface ITask
    {
        //Read
        public IEnumerable<Task> GetAllTasks();

        //Create
        void AddNewTask(Task newTask);

        //Update
        void UpdateTask();

        //Delete
        void DeleteTask(Task taskToDelete);
    }
}

using DataStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Task = DataStorage.Models.Task;

namespace BackendAPI.Interfaces
{
    public class TaskRepo : ITask
    {
        private readonly SFExpressContext _dbContext;

        public TaskRepo(SFExpressContext dbContext)
        {
            _dbContext = dbContext;

        }
        //Create
        public void AddNewTask(Task newTask)
        {
            _dbContext.Task.Add(newTask);
            _dbContext.SaveChanges();
        }

        //Delete
        public void DeleteTask(Task taskToDelete)
        {
            _dbContext.Task.Remove(taskToDelete);
            _dbContext.SaveChanges();
        }

        //Read
        public IEnumerable<Task> GetAllTasks()
        {
            return _dbContext.Task.ToList();
        }

        //Update
        public void UpdateTask()
        {
            _dbContext.SaveChanges();
        }
    }
}

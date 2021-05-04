using AutoMapper;
using BackendAPI.Interfaces;
using BackendAPI.Models;
using DataStorage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackendAPI.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITask _taskRepo;

        public TaskController(IMapper mapper, ITask taskRepo)
        {
            _mapper = mapper;
            _taskRepo = taskRepo;

        }

        //Get api/tasks
        [HttpGet()]
        public ActionResult<IEnumerable<TaskDTO>> GetAllTasks()
        {
            try
            {
                var taskFromRepo = _taskRepo.GetAllTasks();
                return Ok(_mapper.Map<IEnumerable<TaskDTO>>(taskFromRepo));

            }
            catch (Exception ex)
            {
                LogHelper.LogExceptionMessage(ex);
                return BadRequest(ex.GetBaseException().ToString());
            }
        }

        //Create api/tasks
        [HttpPost()]
        public ActionResult AddNewTask(TaskDTO newTask)
        {
            try
            {
                if (newTask == new TaskDTO())
                {
                    throw new ArgumentException("Input Cannot be Null");
                }
                else
                {
                    _taskRepo.AddNewTask(_mapper.Map<Task>(newTask));
                    return Ok();
                }


            }
            catch (Exception ex)
            {
                LogHelper.LogExceptionMessage(ex);
                return BadRequest(ex.GetBaseException().ToString());
            }
        }

        //Update
        [HttpPut()]
        public ActionResult UpdateTaskInfo(Task taskToUpdate)
        {
            try
            {
                if(taskToUpdate == new Task())
                {
                    throw new ArgumentException("Input Cannot Be Null");
                }
                var id = taskToUpdate.TaskId;
                var taskFromRepo = _taskRepo.GetAllTasks().FirstOrDefault(t => t.TaskId == id);
                _mapper.Map(taskToUpdate, taskFromRepo);
                _taskRepo.UpdateTask();
                return NoContent();

            }
            catch (Exception ex)
            {
                LogHelper.LogExceptionMessage(ex);
                return BadRequest(ex.GetBaseException().ToString());
            }
        }


        //Delete
        [HttpDelete()]
        public ActionResult DeleteTask(Task taskToDelete)
        {
            try
            {
                _taskRepo.DeleteTask(taskToDelete);
                return NoContent();

            }
            catch (Exception ex)
            {
                LogHelper.LogExceptionMessage(ex);
                return BadRequest(ex.GetBaseException().ToString());
            }
        }

    }
}

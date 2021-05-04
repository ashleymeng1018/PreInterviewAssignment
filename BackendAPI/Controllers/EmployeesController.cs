using AutoMapper;
using BackendAPI.Interfaces;
using BackendAPI.Models;
using DataStorage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IEmployee _employeeRepo;
        private readonly IMapper _mapper;
        private readonly ITask _task;

        public EmployeesController(IEmployee employeeRepo,IMapper mapper, ITask task)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
            _task = task;

        }

        //GET api/employees
        [HttpGet()]
        public ActionResult<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            try
            {
                var dataFromRepo = _employeeRepo.GetAllEmployees();
                var dataToView = new List<EmployeeDTO>();
                if (dataFromRepo.Count() == 0)
                {
                    return Ok("No Employee On File");
                }
                else
                {
                    foreach(var item in dataFromRepo)
                    {
                        var itemToView = _mapper.Map<EmployeeDTO>(item);
                        List<TaskDTO> task = _mapper.Map<IEnumerable<TaskDTO>>(JsonConvert.DeserializeObject(item.Tasks)).ToList();
                        itemToView.Tasks = task;
                        dataToView.Add(itemToView);
                    }
                    return Ok(dataToView);
                };

            }
            catch (Exception ex)
            {
                LogHelper.LogExceptionMessage(ex);
                return BadRequest(ex.GetBaseException().ToString());
            }
        }

        //POST api/employees
        [HttpPost()]
        public ActionResult AddNewEmployee(EmployeeDTO newEmployee)
        {
            try
            {
                if(newEmployee == new EmployeeDTO())
                {
                    throw new ArgumentException("Input Value is Empty/Null");
                }
                string task = JsonConvert.SerializeObject(newEmployee.Tasks);
                var employeeToRepo = _mapper.Map<Employee>(newEmployee);
                employeeToRepo.Tasks = task;
                _task.AddNewTask(_mapper.Map<DataStorage.Models.Task>(task));
                _employeeRepo.AddNewEmployee(employeeToRepo);
                return NoContent();
            }
            catch (Exception ex)
            {
                LogHelper.LogExceptionMessage(ex);
                return BadRequest(ex.GetBaseException().ToString());
            }
        }


        //PUT api/employees
        [HttpPut()]
        public ActionResult UpdateEmployeeTask(Employee employeeToUpdate)
        {
            try
            {   
                if(employeeToUpdate == new Employee())
                {
                    throw new ArgumentException("Input Value Is Empty/Null");
                }
                var id = employeeToUpdate.EmployeeId;
                var employeeFromRepo = _employeeRepo.GetAllEmployees().FirstOrDefault(e => e.EmployeeId == id);
                employeeFromRepo.FirstName = employeeToUpdate.FirstName;
                employeeFromRepo.LastName = employeeToUpdate.LastName;
                employeeFromRepo.HiredDate = employeeToUpdate.HiredDate;
                _employeeRepo.UpdateEmployeeInfo();
                return NoContent();                   
            }
            catch (Exception ex)
            {
                LogHelper.LogExceptionMessage(ex);
                return BadRequest(ex.GetBaseException().ToString());
            }
        }


        //DELETE api/employee
        [HttpDelete()]
        public ActionResult DeleteEmployee(Employee employeeToDelete)
        {
            try
            {
                _employeeRepo.DeleteEmployee(employeeToDelete);
                return Ok();

            }
            catch (Exception ex)
            {
                LogHelper.LogExceptionMessage(ex);
                return BadRequest(ex.GetBaseException().ToString());
            }
        }

    }
}

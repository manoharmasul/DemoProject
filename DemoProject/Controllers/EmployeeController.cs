using DemoProject.Model;
using DemoProject.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeAsyncRepository employeeAsync;
        public EmployeeController(IEmployeeAsyncRepository employeeAsync)
        {
            this.employeeAsync = employeeAsync;
        }

        [HttpPost("AddNewEmployee")]
        public async Task<IActionResult> AddNewEmployee(Employee employee)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                var result = await employeeAsync.AddNewEmployee(employee);

                if (result > 0)
                {
                    baseResponse.StatusMassage = $"Employee data added successfully...!";
                    baseResponse.StatusCode = StatusCodes.Status200OK;
                    baseResponse.ResponseData = result;
                    return Ok(baseResponse);
                }
                else
                {
                    baseResponse.StatusMassage = $"Something is wrong...!";
                    baseResponse.StatusCode = StatusCodes.Status409Conflict;
                    baseResponse.ResponseData = result;
                    return Ok(baseResponse);
                }
            }
            catch (Exception ex)
            {
                baseResponse.StatusMassage = ex.Message;
                baseResponse.StatusCode = StatusCodes.Status400BadRequest;  
                return Ok(baseResponse);
            }
        }
        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                var result = await employeeAsync.UpdateEmployee(employee);

                if (result > 0)
                {
                    baseResponse.StatusMassage = $"Employee data updated successfully...!";
                    baseResponse.StatusCode = StatusCodes.Status200OK;
                    baseResponse.ResponseData = result;
                    return Ok(baseResponse);
                }
                else
                {
                    baseResponse.StatusMassage = $"Something is wrong...!";
                    baseResponse.StatusCode = StatusCodes.Status409Conflict;
                    baseResponse.ResponseData = result;
                    return Ok(baseResponse);
                }
            }
            catch (Exception ex)
            {
                baseResponse.StatusMassage = ex.Message;
                baseResponse.StatusCode = StatusCodes.Status400BadRequest;
                return Ok(baseResponse);
            }
        }
        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int Id)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                var result = await employeeAsync.GetEmployeeById(Id);

                if (result != null)
                {
                    baseResponse.StatusMassage = "Employee record fetch successfully...!";
                    baseResponse.StatusCode = StatusCodes.Status200OK;
                    baseResponse.ResponseData = result;
                    return Ok(baseResponse);

                }
                else
                {
                    baseResponse.StatusMassage = $"Employee record not found with Id: {Id}...!";
                    baseResponse.StatusCode = StatusCodes.Status409Conflict;

                    return Ok(baseResponse);
                }
            }
            catch (Exception ex)
            {
                baseResponse.StatusMassage = ex.Message;
                baseResponse.StatusCode = StatusCodes.Status400BadRequest;
                return Ok(baseResponse);
            }
        }
        [HttpGet("GetEmployeeByDepartmetnName")]
        public async Task<IActionResult> GetEmployeeByDepartmetnName(string DepartmentName)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                var result = await employeeAsync.GetEmployeeByDepartmetnName(DepartmentName);
                if (result.Count() > 0)
                {
                    baseResponse.StatusMassage = "Employee records fetch successfully...!";
                    baseResponse.StatusCode = StatusCodes.Status200OK;
                    baseResponse.ResponseData = result;
                    return Ok(baseResponse);

                }
                else
                {
                    baseResponse.StatusMassage = $"No any record found...!";
                    baseResponse.StatusCode = StatusCodes.Status404NotFound;

                    return Ok(baseResponse);
                }
            }
            catch (Exception ex)
            {
                baseResponse.StatusMassage = ex.Message;
                baseResponse.StatusCode = StatusCodes.Status409Conflict;
                return Ok(baseResponse);
            }
        }
        [HttpGet("GetEmployeeBySalaryOrder")]
        public async Task<IActionResult> GetEmployeeBySalaryOrder()
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                var result = await employeeAsync.GetEmployeeBySalaryOrder();
                if (result.Count() > 0)
                {
                    baseResponse.StatusMassage = "Employee records fetch successfully...!";
                    baseResponse.StatusCode = StatusCodes.Status200OK;
                    baseResponse.ResponseData = result;
                    return Ok(baseResponse);

                }
                else
                {
                    baseResponse.StatusMassage = $"No any record found...!";
                    baseResponse.StatusCode = StatusCodes.Status404NotFound;

                    return Ok(baseResponse);
                }
            }
            catch (Exception ex)
            {
                baseResponse.StatusMassage = ex.Message;
                baseResponse.StatusCode = StatusCodes.Status409Conflict;
                return Ok(baseResponse);
            }
        }
        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(long Id)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                var result = await employeeAsync.DeleteEmployee(Id);

                if (result > 0)
                {
                    baseResponse.StatusMassage = $"Employee data deleted successfully...!";
                    baseResponse.StatusCode = StatusCodes.Status200OK;
                    baseResponse.ResponseData = result;
                    return Ok(baseResponse);
                }
                else
                {
                    baseResponse.StatusMassage = $"Something is wrong...!";
                    baseResponse.StatusCode = StatusCodes.Status409Conflict;
                    baseResponse.ResponseData = result;
                    return Ok(baseResponse);
                }
            }
            catch (Exception ex)
            {
                baseResponse.StatusMassage = ex.Message;
                baseResponse.StatusCode = StatusCodes.Status400BadRequest;
                return Ok(baseResponse);
            }
        }
    }
}

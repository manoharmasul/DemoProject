using Dapper;
using DemoProject.Context;
using DemoProject.Model;
using DemoProject.Repository.Interface;

namespace DemoProject.Repository
{
    public class EmployeeAsyncRepository:IEmployeeAsyncRepository
    {
        private readonly DapperContext _dapperContext;
        public EmployeeAsyncRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;

        }

        public async Task<long> AddNewEmployee(Employee employee)
        {
            var query = @"Insert into tblEmployee(first_name, last_name, department, Address, hire_date, dob, joiningDate, salary)
                         values(@first_name, @last_name, @department, @Address, @hire_date, @dob, @joiningDate, @salary)";
           using(var conneciton=_dapperContext.CreateConnection())
            {
                var result=await conneciton.ExecuteAsync(query, employee);
                return result;
            }
        }

        public async Task<long> DeleteEmployee(long Id)
        {
            var query = "Delete tblEmployee where employee_id=@employee_id";
            using (var connection = _dapperContext.CreateConnection())
            {
                var result=await connection.ExecuteAsync(query, new { employee_id =Id});
                return result;
            }
        }

        public async Task<List<Employee>> GetEmployeeByDepartmetnName(string DepartmentName)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var query = @"Select employee_id, first_name, last_name, department, Address, hire_date, dob, joiningDate, salary From tblEmployee where department like '%'+@department+'%'";
                var employee = await connection.QueryAsync<Employee>(query, new { department = DepartmentName });
                return employee.ToList();
            }
        }

        public async Task<Employee> GetEmployeeById(int Id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var query = @"Select employee_id, first_name, last_name, department, Address, hire_date, dob, joiningDate, salary From tblEmployee where employee_id=@Id";
                var employee = await connection.QueryFirstOrDefaultAsync<Employee>(query, new { Id = Id });
                return employee;
            }
        }

        public async Task<List<Employee>> GetEmployeeBySalaryOrder()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var query = @"Select employee_id, first_name, last_name, department, Address, hire_date, dob, joiningDate, salary From tblEmployee";
                var employee = await connection.QueryAsync<Employee>(query);
                return employee.ToList();
            }
        }

        public async Task<long> UpdateEmployee(Employee employee)
        {
            var query = @"Update tblEmployee set first_name=@first_name, last_name=@last_name, department=@department, Address=@Address,
                           hire_date=@hire_date, dob=@dob, joiningDate=@joiningDate, salary=@salary where employee_id=@employee_id";
            using(var connection = _dapperContext.CreateConnection())
            {
                var result=await connection.ExecuteAsync(query,employee);
                return result;
            }
        }
    }
}

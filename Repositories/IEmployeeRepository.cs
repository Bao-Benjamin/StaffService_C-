namespace StaffServices.Repositories;
using StaffServices.Models;
// namespace StaffServices.Models;
public interface IEmployeeRepository{
    Task<IEnumerable<Staff>> GetEmployees();
    Task<Staff> GetEmployee(int id);
    Task<Staff> AddEmployee(Staff staff);
    Task<Staff> UpdateEmployee(Staff staff);
    Task<Staff> DeleteEmployee(int staff);

}
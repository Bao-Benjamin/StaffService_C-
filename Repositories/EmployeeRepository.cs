using Microsoft.EntityFrameworkCore;
using StaffServices.Repositories;
using StaffServices.Models;
// namespace StaffServices.Models;
public class EmployeeRepositoty : IEmployeeRepository
{
    private readonly StaffsContext staffsContext;
    public EmployeeRepositoty(StaffsContext staffsContext){
        this.staffsContext = staffsContext;
    }

     public async Task<Staff> AddEmployee(Staff staff)
    {
        var result = await staffsContext.Staff.AddAsync(staff);
        await staffsContext.SaveChangesAsync();
        return result.Entity;
    }
    
    public async Task<Staff> DeleteEmployee(int staff)
    {
        var result = await staffsContext.Staff.FirstOrDefaultAsync(e=>e.EmployeeId == staff);
        if(result !=null){
            staffsContext.Staff.Remove(result);
            await staffsContext.SaveChangesAsync();
            return result;
        }

        return null;
    }
    public async Task<Staff> GetEmployee(int id)
    {

        return await staffsContext.Staff.Include(e => e.DepartmentId).FirstOrDefaultAsync(e=>e.EmployeeId == id );


    }
      public async Task<Staff> UpdateEmployee(Staff staff)
{
    var result = await staffsContext.Staff
        .FirstOrDefaultAsync(e => e.EmployeeId == staff.EmployeeId);

    if (result != null)
    {
        result.FirstName = staff.FirstName;
        result.LastName = staff.LastName;
        result.Email = staff.Email;
        result.StartingDate = staff.StartingDate;
        result.GenderId = staff.GenderId;
        result.DepartmentId = staff.DepartmentId;
        // result.PhotoPath = employee.PhotoPath;
        await staffsContext.SaveChangesAsync();
        return result;
    }

    return null;
}

    public async Task<IEnumerable<Staff>> GetEmployees()
    {
        return await staffsContext.Staff.ToListAsync();
    }
}
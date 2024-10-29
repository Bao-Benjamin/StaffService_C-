
using Microsoft.AspNetCore.Components;
using StaffServices.Models;
using StaffServices.Repositories;

namespace EmployeeInfo.Models;
public class EmployeeListBase: ComponentBase
{
    [Inject]
    public IEmployeeRepository employeeRepository { get; set; }
    public IEnumerable<Staff> employees { get; set; }

    protected override async Task OnInitializedAsync()
    {
        employees = await employeeRepository.GetEmployees();
    }
}
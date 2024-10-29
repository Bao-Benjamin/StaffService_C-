using Microsoft.AspNetCore.Components;
using StaffServices.Models;
using StaffServices.Repositories;
namespace EmployeeInfo.Models;

public class EmployeeDetailsBase : ComponentBase {
    
    public Staff staff { get; set; } = new Staff();
    [Inject]
    public IEmployeeRepository employeeRepository { get; set; }

    [Parameter]
    public string Id {get; set; }

    protected async override Task OnInitializedAsync()
    {
        Id = Id ?? "1";
        staff = await employeeRepository.GetEmployee(int.Parse(Id));
    }
}
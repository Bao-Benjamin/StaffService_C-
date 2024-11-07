using System;
using System.Collections.Generic;

namespace StaffServices.Models;

public partial class Staff
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public DateTime? StartingDate { get; set; }

    public int? GenderId { get; set; }

    public int? DepartmentId { get; set; }

    public Department department {get; set;}
}

﻿namespace EmployeeAdminPortal.Models.Entities
{
    public class Employees
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string ? phone { get; set; }
        public decimal salary { get; set; }



    }
}

﻿using static EmplooyeesAPI.Entities.GenderOptions;

namespace EmplooyeesAPI.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CompanyId { get; set; }
        public Gender Gender { get; set; }

    }
}

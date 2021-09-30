namespace EmplooyeesAPI.Dtos
{
    public class EmployeeCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CompanyId { get; set; }
        public Entities.GenderOptions.Gender Gender { get; set; }
    }
}

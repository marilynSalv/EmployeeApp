namespace EmployeeApp.Dal.Dtos
{
    public class RequestDto
    {
        public string Transient { get; set; }
        public string Singleton { get; set; }
        public string Scoped { get; set; }
    }
}

namespace Domain
{
    public class StudentDto
    {
        public int IdStudent { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string? Gender { get; set; }
        public string Email { get; set; }
        public bool PC { get; set; }
        public bool Internet { get; set; }
    }
}

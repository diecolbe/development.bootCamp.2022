namespace development.Infrastructure.Repositories
{
    public interface IStudentRepository
    {
        Task SaveStudent(StudentDocument studentDocument);
        Task<List<StudentDocument>> GetStudents();
        bool ExistStudent(int id);
    }
}

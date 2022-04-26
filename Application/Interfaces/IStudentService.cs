using Domain;

namespace development.Application.Interfaces
{
    public interface IStudentService
    {
        Task SaveStudent(StudentDto studentDto);
        Task<List<StudentDto>> GetStudents();
        bool ExistStudent(int id);
        int GetMaxId();
    }
}

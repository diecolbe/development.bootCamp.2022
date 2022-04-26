using development.Application.Interfaces;
using development.Infrastructure;
using development.Infrastructure.Repositories;
using development.Shared;
using development.Shared.JsonHelpers;
using Domain;

namespace development.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public bool ExistStudent(int id)
        {
            return studentRepository.ExistStudent(id);
        }

        public async Task<List<StudentDto>> GetStudents()
        {           
            List<StudentDocument> students = await studentRepository.GetStudents();
            List<StudentDto> result = Mapper.MapperList<StudentDocument, StudentDto>(students);
            return result;
        }

        public async Task SaveStudent(StudentDto studentDto)
        {            
           var document = BsonHelper.BsonSerializereHelper<StudentDto, StudentDocument>(studentDto);
            await studentRepository.SaveStudent(document);
        }

        public int GetMaxId()
        {
            List<StudentDto> students = GetStudents().Result;
            int max = students.Count > 0 ? students.Max(s => s.IdStudent) + 1 : 1;
            return max;
        }
    }
}

using development.Application.Interfaces;
using development.Infrastructure;
using development.Infrastructure.Repositories;
using Domain;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json;

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
            List<StudentDto> result = new List<StudentDto>();
            List<StudentDocument> students = await studentRepository.GetStudents();

            foreach (var student in students)
            {
                result.Add(new StudentDto()
                {
                    IdStudent = student.IdStudent,
                    Name = student.Name,
                    LastName = student.LastName,
                    Birthday = student.Birthday,
                    Gender = student.Gender,
                });
            }

            return result;
        }

        public async Task SaveStudent(StudentDto studentDto)
        {
            string jsonData;
            jsonData = JsonConvert.SerializeObject(studentDto);
            var json = JsonConvert.DeserializeObject(jsonData);
            StudentDocument document = BsonSerializer.Deserialize<StudentDocument>(json.ToString());
            await studentRepository.SaveStudent(document);
        }

        public int GeMaxId()
        {
            List<StudentDto> students = GetStudents().Result;
            int max = students.Count > 0 ? students.Max(s => s.IdStudent) + 1 : 1;
            return max;
        }
    }
}

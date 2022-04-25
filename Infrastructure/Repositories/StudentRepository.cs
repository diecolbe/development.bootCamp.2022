using development.Infrastructure.Interfaces;

namespace development.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IMongoRepository<StudentDocument> studentMongoRepository;

        public StudentRepository(IMongoRepository<StudentDocument> studentMongoRepository)
        {
            this.studentMongoRepository = studentMongoRepository;
        }

        public bool ExistStudent(int id)
        {
            var student = studentMongoRepository.FindOneAsync(d => d.IdStudent == id).Result;
            if (student != null)
                return true;
            else
                return false;
        }

        public async Task<List<StudentDocument>> GetStudents()
        {
            return studentMongoRepository.FilterBy(f => f.IdStudent > 0).ToList();
        }

        public async Task SaveStudent(StudentDocument studentDocument)
        {
            if (studentDocument != null)
            {
                var studentExists = await studentMongoRepository.FindOneAsync(d => d.IdStudent == studentDocument.IdStudent);
                if (studentExists != null)
                {
                    studentExists = studentDocument;
                    await studentMongoRepository.ReplaceOneAsync(studentExists);
                }
                else
                {
                    await studentMongoRepository.InsertOneAsync(new StudentDocument(studentDocument));
                }
            }
        }
    }
}

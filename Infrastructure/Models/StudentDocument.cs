using development.Domain.Interfaces;
using development.Infrastructure.Repositories;
using Domain;
using MongoDB.Bson;

namespace development.Infrastructure
{
    [BsonCollection("Student")]
    public class StudentDocument : Student, IDocument
    {
        public StudentDocument() { }
        public StudentDocument(Student student)
        {
            IdStudent = student.IdStudent;
            Name = student.Name;
            LastName = student.LastName;
            Birthday=student.Birthday;
            Gender= student.Gender;
            Email=student.Email;
            PC=student.PC;
            Internet=student.Internet;
        }
        public ObjectId Id { get; set; }

        public DateTime CreationDate => Id.CreationTime;
    }
}

using RepositoryPattern.Models;

namespace RepositoryPattern.Repositories
{
    public interface IStudentRepository
    {
       List<StudentModel> GetAllStudents();
       StudentModel GetStudentById(int id);

    }
}

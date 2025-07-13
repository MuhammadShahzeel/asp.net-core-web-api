using RepositoryPattern.Models;

namespace RepositoryPattern.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly List<StudentModel> _students;
        // Constructor
        public StudentRepository()
        {
            _students = GetDataSource();
        }
        // Data Source method

        private List<StudentModel> GetDataSource()
        {
            //abhi yah list hy actual my data source database hogi waha sy data aye ga
            return new List<StudentModel>
            {
                new StudentModel { RollNo = 1, Name = "Ali Khan", Gender = "Male", Grade = "A" },
                new StudentModel { RollNo = 2, Name = "Sara Ahmed", Gender = "Female", Grade = "B" },
                new StudentModel { RollNo = 3, Name = "Bilal Sheikh", Gender = "Male", Grade = "A+" },
                new StudentModel { RollNo = 4, Name = "Fatima Noor", Gender = "Female", Grade = "C" }
            };
        }



        public List<StudentModel> GetAllStudents()
        {
            return _students;

        }

        public StudentModel GetStudentById(int id)
        {
            //return _students.Where(s => s.RollNo == id).FirstOrDefault();
            //better way q k hmy sirf yeh aik chahiye
            return _students.FirstOrDefault(s => s.RollNo == id);



        }
    }
}

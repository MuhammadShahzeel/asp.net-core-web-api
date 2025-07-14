using Microsoft.EntityFrameworkCore;

namespace EFCCodeFirstApproach.Models
{
    //step1: inherit it with DbContext
    public class StudentDBContext : DbContext
    {
        //step 2: then create constructor like this
        public StudentDBContext(DbContextOptions options) : base(options) //pass options to base class
            {
        }

        //step 3: create dbset for Student it will represent table in database
        public DbSet<Student> Students { get; set; }  //table name in db is Students
    }
}














//  DbContextOptions
// - Holds configuration info like connection string and database provider.
// - Needed by DbContext to connect to the database.

// DbContext
// - Main class to interact with the database.
// - Manages connection, retrieve/save data.
// - Has DbSet<T> for tables.
// - Coordinates with EF Core to query and save data.





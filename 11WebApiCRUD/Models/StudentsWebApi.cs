using System;
using System.Collections.Generic;

namespace _11WebApiCRUD.Models;

public partial class StudentsWebApi
{
    public int Id { get; set; }

    public string StudentName { get; set; } = null!;

    public string StudentGender { get; set; } = null!;

    public int Age { get; set; }

    public int Standard { get; set; }

    public string FatherName { get; set; } = null!;
}

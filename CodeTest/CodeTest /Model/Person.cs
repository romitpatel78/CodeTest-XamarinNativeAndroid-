using System;
using SQLite;
namespace CodeTest.Model
{
    public class Person
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    
}

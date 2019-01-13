using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library_2.Context
{
    public class LibararyDbconnect:DbContext
    {
        public LibararyDbconnect() : base("Dbconnect")
        {

        }

        public DbSet<Student> Stundets { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categoryes { get; set; }
        public DbSet<Loom> Loam { get; set; }
    }
}

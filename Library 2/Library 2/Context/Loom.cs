using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Library_2.Context
{
    public class Loom
    {
        public int Id { get; set; }
       
       
        public DateTime Date { get; set; }

        [ForeignKey("Books")]
        public int BookId { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        [ForeignKey("Students")]
        public int StudentID { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
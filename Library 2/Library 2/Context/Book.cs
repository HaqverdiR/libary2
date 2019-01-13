using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_2.Context
{
    public class Book
    {
        public int Id { get; set; }
        public string Bookname { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Categories { get; set; }

    }
}
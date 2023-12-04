using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain
{
    public class Book
    {
        public int bookId {  get; set; }

        public string? name { get; set; }

        public string? category { get; set; }

        public decimal price { get; set; }

        public string? description { get; set; }

    }
}

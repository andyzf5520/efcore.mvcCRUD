using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyCoreMvc.Models.BooksModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Content { get; set; }
    }
}

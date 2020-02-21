using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArticleApp.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime DateOfAdding { get; set; }
        public bool Confirm { get; set; }
        public bool Homepage { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArticleApp.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime DateOfAdding { get; set; }
        public Boolean Confirm { get; set; }
        public Boolean Homepage { get; set; }
        public int CategoryId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace LMSystem.Models
{
    public class Book
    {
        public  int id { get; set; }
        [Required]
        public string Title { get; set; }
        public string author { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public String subjectMatter { get; set; }
    }
}
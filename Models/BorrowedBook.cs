using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMSystem.Models
{
    public class BorrowedBook
    {
        public int id { get; set; } = 0;
        public int? sId { get; set; } = 0;
        public int? bId { get; set; } = 0;
        public String StudentId { get; set; }
        public String StudentName { get; set; }
        public string Title { get; set; }
        public string author { get; set; }
        public string Publisher { get; set; }
        public String subjectMatter { get; set; }
        public bool isReturned { get; set; } = false;
    }
}
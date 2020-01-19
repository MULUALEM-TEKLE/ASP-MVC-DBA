using LMSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMSystem.ViewModels
{
    public class BorrowedBag
    {
       public IEnumerable<Student> students { get; set; }
       public IEnumerable<Book>    books { get; set; }
       public BorrowedBook         borrowedBook { get; set; }
    }
}
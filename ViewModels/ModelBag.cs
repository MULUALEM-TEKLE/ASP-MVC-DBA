using LMSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMSystem.ViewModels
{
    public class ModelBag
    {
        public BorrowedBook borrowedBook { get; set; }
        public List<Borrowedstate> borrowedstate { get; set; } = new List<Borrowedstate> {
            new Borrowedstate { isReturned=false,stateName="Not Retured" },
            new Borrowedstate { isReturned=true,stateName=" Retured" }
        };
        public List<SelectListItem> students { get; set; }
        public List<SelectListItem> books { get; set; }

    }
    public class Borrowedstate {
        public int id { get; set; }
        public bool isReturned { get; set; } = false;
        public String stateName { get; set; } = "Not Returned";
    }
}
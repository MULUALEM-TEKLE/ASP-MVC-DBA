using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMSystem.Models;
using LMSystem.ViewModels;

namespace LMSystem.Controllers
{
    public class BorrowedBooksController : Controller
    {
        private LMSystemContext db = new LMSystemContext();

        // GET: BorrowedBooks
        public ActionResult Index()
        {
            return View(db.BorrowedBooks.ToList());
        }

        // GET: BorrowedBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowedBook borrowedBook = db.BorrowedBooks.Find(id);
            if (borrowedBook == null)
            {
                return HttpNotFound();
            }
            return View(borrowedBook);
        }

        // GET: BorrowedBooks/Create
        public ActionResult Create()
        {
            var booksList = db.Books.ToList();
            var studentsList = db.Students.ToList();
            var bag = new ModelBag();
            List<SelectListItem> students_list = new List<SelectListItem>();
            List<SelectListItem> books_list = new List<SelectListItem>();
            for (var i=0;i< studentsList.ToArray().Length;i++)
            {
                students_list.Add(new SelectListItem { Text = studentsList[i].studendID, Value = studentsList[i].studendID });
            }

            for (var i = 0; i < booksList.ToArray().Length; i++)
            {
                books_list.Add(new SelectListItem { Text = booksList[i].Title, Value = booksList[i].Title });
            }

            ViewBag.book_selected = books_list;
            ViewBag.student_selected = students_list;
            ViewBag.borrowedBook = new BorrowedBook();
            return View();
        }

        // POST: BorrowedBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "id,sId,bId,StudentId,StudentName,Title,author,Publisher,subjectMatter,isReturned")] BorrowedBook borrowedB
        public ActionResult Create(string student_selected,string book_selected)
        {
            try
            {
                var booksList = db.Books.Single(b => b.Title == book_selected);
                var students = db.Students.Single(s => s.studendID == student_selected);
                var borrowedB = new BorrowedBook();
                borrowedB.sId = booksList.id;
                borrowedB.bId = students.id;
                borrowedB.StudentId = students.studendID;
                borrowedB.StudentName = students.Name;
                borrowedB.Title = booksList.Title;
                borrowedB.Publisher = booksList.Publisher;
                borrowedB.author = booksList.author;
                borrowedB.subjectMatter = booksList.subjectMatter;
                var brdBooks = db.BorrowedBooks;
                brdBooks.Add(borrowedB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            // if (ModelState.IsValid)
            // {
            //      db.BorrowedBooks.Add(borrowedBook);
            //      db.SaveChanges();
            //      return RedirectToAction("Index");
            //  }

            //return View(borrowedBook);
        }

        // GET: BorrowedBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowedBook borrowedBook = db.BorrowedBooks.Find(id);
            if (borrowedBook == null)
            {
                return HttpNotFound();
            }
            return View(borrowedBook);
        }

        // POST: BorrowedBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,sId,bId,StudentId,StudentName,Title,author,Publisher,subjectMatter,isReturned")] BorrowedBook borrowedBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(borrowedBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(borrowedBook);
        }

        // GET: BorrowedBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowedBook borrowedBook = db.BorrowedBooks.Find(id);
            if (borrowedBook == null)
            {
                return HttpNotFound();
            }
            return View(borrowedBook);
        }

        // POST: BorrowedBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BorrowedBook borrowedBook = db.BorrowedBooks.Find(id);
            db.BorrowedBooks.Remove(borrowedBook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

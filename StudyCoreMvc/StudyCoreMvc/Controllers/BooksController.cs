using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyCoreMvc.Models;
using StudyCoreMvc.Models.BooksModels;

namespace StudyCoreMvc.Controllers
{
    public class BooksController : Controller
    {
        private readonly StudyCoreMvcContext _context;
        int A;
        public BooksController(StudyCoreMvcContext context,int  a)
        {
            A = a;
            _context = context;
        }
        //这是使用EntityFramwork的 MVC控制器添加创建的 是一套自动的增删改查
        // GET: Books
        public async Task<IActionResult> Index()
        {

            //StudyCoreMvcContext _context = new StudyCoreMvcContext();

           var book= _context.Book;

            //TransactionScope sc = new TransactionScope()  // 不用ef 的时候执行的事务处理
            //using (TransactionScope sc = new TransactionScope())
            //{
            //    try
            //    {

            //        _context.Book.Add(new Book { Name = "AAAAA", Content = "呢绒" });
            //        _context.SaveChanges();

            //        sc.Complete();//放在catch上面，否则不能回滚
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            //return View(await _context.Book.ToListAsync());
            using (var tran = _context.Database.BeginTransaction()) 
            {
                //efcore中的事物
                try
                {
                    _context.Book.Add(new Book { Name = "AAAAA", Content = "呢绒" });
                  
                    _context.SaveChanges();
                 
                    tran.Commit();
                    //throw new Exception("模拟异常");
                }
                catch (Exception)
                {
                    tran.Rollback();
                    // TODO: Handle failure
                }
            }
            return View(await _context.Book.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Content")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Content")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}

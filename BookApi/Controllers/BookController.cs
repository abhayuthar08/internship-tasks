using BookApi.Models;
using BookApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly BookService bookService;

        public BookController(BookService book)
        {
            this.bookService = book;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult AddBook(Book book)
        {
            this.bookService.AddBook(book);
            return Ok("Book Created");
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            return Ok(this.bookService.GetAll());
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById(int id)
        {
            var res = this.bookService.GetBookById(id);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("Book Not Found");
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(int id)
        {
            var result = this.bookService.DeleteBook(id);
            if (result)
            {
                return Ok("Book Deleted");
            }
            return NotFound("Book Not Found");
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Update(int id, Book book)
        {
            var result = this.bookService.UpdateBook(id, book);
            if (result)
            {
                return Ok("Book Updated");
            }
            return NotFound("Book Not Found");
        }
    }
}

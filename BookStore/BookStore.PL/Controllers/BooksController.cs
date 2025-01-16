using BookStore.BLL.Services;
using BookStore.BLL.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServerApp.BLL.Services;

namespace BookStore.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get-all-books")]
        public async Task<ActionResult<IEnumerable<BookVm>>> GetBooks()
        {
            var result = await _bookService.GetAllBookAsync();
            return Ok(result); 
        }


        [HttpGet("get-all-books-by-page")]
        public async Task<ActionResult<IEnumerable<BookVm>>> GetBooks([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _bookService.GetAllBookAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<BookVm>>> FilterBooks([FromBody] FilterRequest filterRequest)
        {
            try
            {
                var filteredBooks = await _bookService.FilterBooksAsync(filterRequest);
                return Ok(filteredBooks);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Lỗi máy chủ nội bộ: {e.Message}");
            }
        }

        [HttpGet("get-book-by-id/{id}")]
        public async Task<ActionResult<BookVm>> GetBook(int id)
        {
            var result = await _bookService.GetByBookIdAsync(id);

            if (result == null)
            {
                return NotFound(new { Message = $"Sách với ID {id} không tìm thấy." }); 
            }

            return Ok(result); 
        }

        [HttpPost("add-new-book")]
        public async Task<ActionResult<BookVm>> PostBook(InputBookVm bookVm)
        {
            var result = await _bookService.AddBookAsync(bookVm);

            if (result == null)
            {
                return BadRequest(new { Message = "Không tạo được sách." }); 
            }

            return CreatedAtAction(nameof(GetBook), new { id = result.BookId }, result); 
        }

        [HttpPut("update-book/{id}")]
        public async Task<IActionResult> PutBook(int id, InputBookVm bookVm)
        {
            var result = await _bookService.UpdateBookAsync(id, bookVm);
            if (result == null)
            {
                return NotFound(new { Message = $"Sách với ID {id} không tìm thấy." });
            }

            return Ok(result);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);
            if (result == null)
            {
                return NotFound(new { Message = $"Sách với ID  {id}  không tìm thấy." }); 
            }

            return NoContent(); 
        }
        
        

    }
}

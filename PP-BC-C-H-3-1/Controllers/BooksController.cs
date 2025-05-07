using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.MediatR.Commands;
using WebApi.MediatR.Queries;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBookById(int id)
        {
            var result = await _mediator.Send(new GetBookByIdQuery { BookId = id });
            
            if (result == null)
                return NotFound();
                
            return Ok(result);
        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookCommand command)
        {
            command.BookId = id;
            
            var result = await _mediator.Send(command);

            if (result == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}

using MediatR;
using WebApi.BookOperations.GetBookById;

namespace WebApi.MediatR.Queries
{
    public class GetBookByIdQuery : IRequest<BookDetailViewModel>
    {
        public int BookId { get; set; }
    }
}

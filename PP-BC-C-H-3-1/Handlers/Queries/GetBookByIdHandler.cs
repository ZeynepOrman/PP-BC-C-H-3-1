using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.BookOperations.GetBookById;
using WebApi.DBOperations;
using WebApi.MediatR.Queries;

namespace PP_BC_C_H_3_1.MediatR.Queries
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookDetailViewModel>
    {
        private readonly BookStoreDbContext _dbContext;

        public GetBookByIdHandler(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<BookDetailViewModel> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == request.BookId);
            
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadý");

            BookDetailViewModel vm = new BookDetailViewModel
            {
                Id = book.Id,
                Title = book.Title,
                PageCount = book.PageCount,
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                GenreId = book.GenreId
            };

            return Task.FromResult(vm);
        }
    }
}

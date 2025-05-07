using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.MediatR.Commands;

namespace PP_BC_C_H_3_1.MediatR.Commands
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly BookStoreDbContext _dbContext;

        public UpdateBookHandler(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var book = _dbContext.Books.SingleOrDefault(x => x.Id == request.BookId);

                if (book is null)
                    throw new InvalidOperationException("Kitap bulunamadý");

                book.Title = request.Title;
                book.GenreId = request.GenreId;
                book.PageCount = request.PageCount;
                book.PublishDate = request.PublishDate;
                _dbContext.Update(book);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
    }
}

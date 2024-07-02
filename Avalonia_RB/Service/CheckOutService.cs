using Avalonia_RB.Persistence;
using System.Collections.Generic;
using System.Linq;
using Avalonia_RB.Model;
using Avalonia_RB.ViewModels;
using System.Threading.Tasks;
using System;

namespace Avalonia_RB.Service
{
    public class CheckOutService
    {
        private readonly IAppDbContext _appDbContext;
        private MainWindowViewModel _mainWindowViewModel;
        private BookService _bookService;

        public CheckOutService(MainWindowViewModel mainWindowViewModel, IAppDbContext appDbContext, BookService bookService)
        {
            _appDbContext = appDbContext;
            _mainWindowViewModel = mainWindowViewModel;
            _bookService = bookService;
        }

        public IEnumerable<CheckOuts> GetCheckedOutBooks()
        {
            return _appDbContext.CheckOuts.Where( w=> w.User.Id == _mainWindowViewModel.CurrentUser.Id).Where(w => w.ReturnDate == null).ToList();
        }

        public async Task AddCheckOut(int bookId)
        {
            var book = _appDbContext.Books.FirstOrDefault(b => b.Id == bookId);

            if (book != null)
            {
                var checkOut = new CheckOuts
                {
                    Book = book,
                    User = _mainWindowViewModel.CurrentUser,
                    CheckOutDate = DateTime.Now
                };
                _appDbContext.CheckOuts.Add(checkOut);

                await _bookService.SetBookAvailable(bookId, false);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task ReturnBook(int checkOutId)
        {
            var checkOut = _appDbContext.CheckOuts.Where(w => w.ReturnDate == null).FirstOrDefault(c => c.BookId == checkOutId);

            if (checkOut != null)
            {
                await _bookService.SetBookAvailable(checkOut.BookId, true);
                checkOut.ReturnDate = DateTime.Now;
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}

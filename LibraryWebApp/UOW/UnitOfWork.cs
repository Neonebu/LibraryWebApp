﻿using LibraryWebApp.Context;
using LibraryWebApp.Models;
using LibraryWebApp.Repository;

namespace LibraryWebApp.UOW
{
    public class UnitOfWork : IDisposable
    {
        private LibraryContext _context = new LibraryContext();
        private Repository<User>? userRepo;
        private Repository<Book>? bookRepo;
        public Repository<User> UserRepository
        {
            get
            {

                if (this.userRepo == null)
                {
                    this.userRepo = new Repository<User>(_context);
                }
                return userRepo;
            }
        }
        public Repository<Book> BookRepository
        {
            get
            {
                if (this.bookRepo == null)
                {
                    this.bookRepo = new Repository<Book>(_context);
                }
                return bookRepo;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

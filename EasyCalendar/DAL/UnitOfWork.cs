using EasyCalendar.DAL.Context;
using EasyCalendar.DAL.Repositories.Events;
using System;

namespace EasyCalendar.DAL
{
    public class UnitOfWork : IDisposable
    {
        #region Properties and Constructors

        internal DatabaseContext _dbContext;

        public UnitOfWork()
        {
            _dbContext = new DatabaseContext();
            _disposed = false;
        }

        public DatabaseContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        #endregion

        #region Disposing logic

        private static bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed || !disposing) return;

            _dbContext.Dispose();
            _disposed = true;
        }

        #endregion Disposing logic

        #region Repository fields

        private EventsDataRepository _eventsDataRepository;
        private EventsRepository _eventsRepository;

        #endregion

        #region Repository Properties

        public EventsDataRepository EventsDataRepository
        {
            get
            {
                return _eventsDataRepository ?? (_eventsDataRepository = new EventsDataRepository(_dbContext));
            }
        }

        public EventsRepository EventsRepository
        {
            get
            {
                return _eventsRepository ?? (_eventsRepository = new EventsRepository(_dbContext));
            }
        }

        #endregion
    }
}

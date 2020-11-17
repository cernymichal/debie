using System;
using System.Collections.Generic;

namespace Debie.Services.Repositories.DB {
    public abstract class DBRepository<T> : IRepository<T> {
        protected DebieDBContext _Context;
        private bool _Disposed = false;
        public abstract IEnumerable<T> GetAll();
        public abstract T GetByID(int id);
        public abstract void Insert(T entity);
        public abstract void Delete(T entity);
        public abstract void Update(T entity);
        public void Save() {
            _Context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing) {
            if (!_Disposed) {
                if (disposing) {
                    _Context.Dispose();
                }
            }
            _Disposed = true;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
using System;
using System.Collections.Generic;

using Debie.Models.DB;

namespace Debie.Services.Repositories {
    public interface IRepository<T> : IDisposable {
        IEnumerable<T> GetAll();
        T GetByID(params object[] keys);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();
    }

    public interface IArticleRepository : IRepository<Article> {
    }

    public interface ICategoryRepository : IRepository<Category> {
    }

    public interface IImageRepository : IRepository<Image> {
    }

    public interface IOrderRepository : IRepository<Order> {
    }

    public interface IProductRepository : IRepository<Product> {
    }

    public interface ITagRepository : IRepository<Tag> {
    }

    public interface IUserRepository : IRepository<User> {
    }

    public interface IVendorRepository : IRepository<Vendor> {
    }
}
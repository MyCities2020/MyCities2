using MyCities2API.Models;
using System.Collections.Generic;

namespace MyCities2API.Services
{
    //CRUD :  Create, Read, Update, Delete
    //Q : Query
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll<T>() where T : class;

        T GetOne<T>(int id) where T : class;

        void Insert<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;
        public List<T> GetItems(AppSettings settings);

        public T GetItem(string id="", string partitionKey="");

        public T InsertItem(T item);

        public T UpdateItem(T item);

        public void DeleteItem(string id, string PartitionKey ="");
        List<Batiment> GetItems(string id);
      
    }
}

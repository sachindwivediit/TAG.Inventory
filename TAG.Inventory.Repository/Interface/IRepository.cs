using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAG.Inventory.Entities;

namespace TAG.Inventory.Repository.Interface
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);

        Task Add(T product);

        Task Update(T product);
        Task Delete(T product);
    }
}

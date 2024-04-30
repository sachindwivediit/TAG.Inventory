using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAG.Inventory.Entities;

namespace TAG.Inventory.Repository.Interface
{
    public interface IRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);

        Task Add(Product product);

        Task Update(Product product);
        Task Delete(Product product);
    }
}

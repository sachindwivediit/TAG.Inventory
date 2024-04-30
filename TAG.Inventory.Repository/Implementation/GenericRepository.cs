using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAG.Inventory.Entities;
using TAG.Inventory.Repository.Interface;

namespace TAG.Inventory.Repository.Implementation
{
    public class GenericRepository : IRepository<Product>
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Product product)
        {
            _context.products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _context.products.FindAsync(id);
            return product;
        }

        public async Task Update(Product product)
        {
            _context.products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}

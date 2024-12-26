using Internet_1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_1.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        // Şehir bazlı ürünleri getiren yöntem
        public async Task<IEnumerable<Product>> GetProductsByCityAsync(string city)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Where(p => p.City == city)
                .ToListAsync();
        }

        // Ürünleri kategorileriyle birlikte getiren yöntem
        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string categoryName)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Where(p => p.Category.Name == categoryName)
                .ToListAsync();
        }

        // Tüm ürünleri kategorileriyle birlikte getiren yöntem
        public async Task<IEnumerable<Product>> GetAllWithCategoryAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
        }
    }
}

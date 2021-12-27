using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayerProject.Data.Repositories
{
    //Categorye özel fonk iiçn Repository işimizi  görüyor
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public CategoryRepository(DbContext context) : base(context)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categotyId)
        {
            return await appDbContext.Categories.Include(x => x.Products).SingleOrDefaultAsync(x => x.Id == categotyId);
        }
    }
}

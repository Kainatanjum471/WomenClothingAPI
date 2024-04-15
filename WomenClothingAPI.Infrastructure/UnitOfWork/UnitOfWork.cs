using WomenClothingAPI.Infrastructure.Data;
using WomenClothingAPI.Infrastructure.Repositories;

namespace WomenClothingAPI.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
        }
        public IProductRepository Products { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

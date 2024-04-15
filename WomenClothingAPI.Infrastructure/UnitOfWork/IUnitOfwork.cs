using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WomenClothingAPI.Infrastructure.Repositories;

namespace WomenClothingAPI.Infrastructure.UnitOfWork.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        int Complete();
    }
}

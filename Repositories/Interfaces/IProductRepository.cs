using AdventureCore.Data;
using AdventureCore.Models;

namespace AdventureCore.Repositories.Interfaces
{
  public interface IProductRepository
  {
    // 1. Lista básica de productos
    Task<IEnumerable<Product>> GetBasicProductListAsync();

    Task<ProductBasic>GetProductByIdAsync(int id);
  }
}

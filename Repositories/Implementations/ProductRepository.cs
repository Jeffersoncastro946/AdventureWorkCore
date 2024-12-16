using AdventureCore.Data;
using AdventureCore.Models;
using AdventureCore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdventureCore.Repositories.Implementations
{
  public class ProductRepository : IProductRepository
  {
    private readonly ContextoAdventure BdContexto;
    public ProductRepository(ContextoAdventure contexto)
    {
      BdContexto = contexto;
    }
    public async Task<IEnumerable<Product>> GetBasicProductListAsync()
    {
      IEnumerable<Product> productBasic = await BdContexto.Products.ToListAsync();
      return productBasic;
    }

    public async Task<ProductBasic> GetProductByIdAsync(int id)
    {
      //BdContexto.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync().
      ProductBasic? productoDetail = await BdContexto.Products.Where(x => x.ProductId == id).
        Select(x => new ProductBasic()
        {
          IdProductID = x.ProductId,
          ProductName = x.Name,
          ProductNumber = x.ProductNumber,
          color = x.Color,
          ListPrince = x.ListPrice,
          StandartCost = x.StandardCost,
          Size = x.Size,
          ModifiedDate = x.ModifiedDate
        }).FirstOrDefaultAsync();

      if (productoDetail == null)
      {
        throw new Exception($"No se encontró el producto con ID {id}");
      }

      return productoDetail;
    }
  }
}

using AdventureCore.Data;
using AdventureCore.Models;
using AdventureCore.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdventureCore.Controllers
{
  public class ProductController : Controller
  {
    private readonly IProductRepository productRepository;
    public ProductController(IProductRepository Repo)
    {
      productRepository = Repo;
    }
    public IActionResult Index()
    {
      return View();
    }
    public async Task<JsonResult> GetLisSimple()
    { 
        var _Productos = await productRepository.GetBasicProductListAsync();
        var productBasic = _Productos.
           Select(x => new ProductBasic
           {
             IdProductID = x.ProductId,
             ProductName = x.Name,
             ProductNumber=x.ProductNumber,
             color=x.Color,
             ListPrince = x.ListPrice,
             StandartCost=x.StandardCost,
             Size=x.Size,
             ModifiedDate=x.ModifiedDate
           });
        return Json(productBasic);
    }

    [HttpGet]
    public async Task<IActionResult> GetProduct(int id)
    {
      var productoDetail =await productRepository.GetProductByIdAsync(id);
      // Log para verificar los datos
      Console.WriteLine($"Producto encontrado: {productoDetail.ProductName}");
      return PartialView("~/Views/Product/_DetalleProducto.cshtml", productoDetail);
    }

  }
}
